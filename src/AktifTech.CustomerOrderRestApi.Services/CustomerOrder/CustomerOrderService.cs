using AktifTech.CustomerOrderRestApi.Model;
using AktifTech.CustomerOrderRestApi.EntityFramework;
using AutoMapper;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public class CustomerOrderService
    {
        public Repository<CustomerOrder, long> _repository { get; set; }
        public IMapper _mapper { get; set; }
        public CustomerOrderService(AppDbContext dbContext, IMapper mapper)
        {
            _repository = new Repository<CustomerOrder, long>(dbContext);
            _mapper = mapper;
        }

        public GetCustomerOrderOutput SaveOrder(long customerId, CreateCustomerOrderInput input)
        {
            var customerOrder = new CustomerOrder(customerId);
            customerOrder = _mapper.Map<CreateCustomerOrderInput, CustomerOrder>(input, customerOrder);
            _repository.Add(customerOrder);
            customerOrder = _repository.Get(p => p.Id == customerOrder.Id, p => p.Customer, p => p.Products);
            return _mapper.Map<GetCustomerOrderOutput>(customerOrder);
        }

        public GetCustomerOrderOutput AddOrUpdateProduct(long customerId, long orderId, AddOrUpdateProductInput input)
        {
            if (input.Quantity < 0) throw new Exception("You cannot set negative amounts!");
            if (input.Quantity == 0)
            {
                return RemoveProductFromOrder(customerId, orderId, input.ProductId);
            }
            else
            {
                var customerOrder = _repository.Get(p => p.Id == orderId);
                if(customerOrder.CustomerId != customerId) throw new Exception("You cannot delete others' orders!");
                var product = customerOrder.Products.FirstOrDefault(p => p.ProductId == input.ProductId);
                if (product != null)
                {
                    product.Quantity = input.Quantity;
                }
                else
                {
                    customerOrder.Products.Add(new ProductInOrder
                    {
                        ProductId = input.ProductId,
                        Quantity = input.Quantity
                    });
                }

                _repository.Update(customerOrder);
                return _mapper.Map<GetCustomerOrderOutput>(_repository.Get(p => p.Id == orderId));
            }
        }

        public GetCustomerOrderOutput RemoveProductFromOrder(long customerId, long orderId, long productId)
        {
            var customerOrder = _repository.Get(p => p.Id == orderId);
            var product = customerOrder.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null) throw new Exception("This product is not in your order!");
            customerOrder.Products.Remove(product);
            _repository.Update(customerOrder);
            return _mapper.Map<GetCustomerOrderOutput>(customerOrder);
        }

        public GetCustomerOrderOutput DeleteOrderById(long customerId, long orderId)
        {
            var order = _repository.Get(p => p.Id == orderId);
            if(order.CustomerId != customerId) throw new Exception("You cannot delete others' orders!");
            _repository.Delete(orderId);
            return _mapper.Map<GetCustomerOrderOutput>(order);
        }

        public GetCustomerOrderOutput UpdateOrderAddress(long customerId, long orderId, long addressId)
        {
            var order = _repository.Get(p => p.Id == orderId);
            if(order.CustomerId != customerId) throw new Exception("You cannot update others' orders!");
            order.AddressId = addressId;
            _repository.Update(order);
            return _mapper.Map<GetCustomerOrderOutput>(order);
        }
    }
}