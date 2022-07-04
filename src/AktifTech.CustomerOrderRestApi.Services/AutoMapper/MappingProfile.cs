using AktifTech.CustomerOrderRestApi.Model;
using AutoMapper;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, GetCustomerOutput>().ReverseMap();
            CreateMap<Customer, CreateCustomerInput>().ReverseMap();
            CreateMap<Customer, UpdateCustomerInput>().ReverseMap();

            CreateMap<CustomerAddress, GetCustomerAddressOutput>().ReverseMap();
            CreateMap<CustomerAddress, CreateCustomerAddressInput>().ReverseMap();

            CreateMap<Product, GetProductOutput>().ReverseMap();
            CreateMap<Product, CreateProductInput>().ReverseMap();
            CreateMap<Product, UpdateProductInput>().ReverseMap();

            CreateMap<ProductInOrder, GetProductInOrderOutput>()
                .ForMember(x => x.ProductName, opt => opt.MapFrom(o => o.Product.Description));
            CreateMap<ProductInOrder, CreateProductInOrderInput>().ReverseMap();

            CreateMap<CustomerOrder, GetCustomerOrderOutput>()
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(o => o.Customer.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(o => o.Address.Address))
                .ForMember(x => x.AddressName, opt => opt.MapFrom(o => o.Address.Name))
                .ForMember(x => x.TotalPrice, opt => opt.MapFrom(o => o.Products.Sum(p => p.Quantity * p.Product.Price)))
                .ReverseMap();
            CreateMap<CustomerOrder, CreateCustomerOrderInput>().ReverseMap();
        }
    }
}