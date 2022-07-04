using AktifTech.CustomerOrderRestApi.Model;
using AktifTech.CustomerOrderRestApi.EntityFramework;
using AutoMapper;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public class CustomerService : CrudServiceBase<long, Customer, GetCustomerOutput, CreateCustomerInput, UpdateCustomerInput>
    {
        public CustomerService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public GetCustomerOutput CreateCustomerAddress(long customerId, CreateCustomerAddressInput input)
        {
            var customer = _repository.Get(p => p.Id == customerId);
            customer.Addresses.Add(new CustomerAddress(input.Name, input.Address));
            _repository.Update(customer);
            return _mapper.Map<GetCustomerOutput>(customer);
        }
        public GetCustomerOutput DeleteCustomerAddress(long customerId, DeleteCustomerAddressInput input)
        {
            var customer = _repository.Get(p => p.Id == customerId);
            var address = customer.Addresses.FirstOrDefault(p => p.Id == input.AddressId);
            if (address == null) throw new Exception("This is not your address!");
            customer.Addresses.Remove(address);
            _repository.Update(customer);
            return _mapper.Map<GetCustomerOutput>(customer);
        }
    }
}