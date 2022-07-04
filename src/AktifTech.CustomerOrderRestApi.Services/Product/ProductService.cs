using AktifTech.CustomerOrderRestApi.Model;
using AktifTech.CustomerOrderRestApi.EntityFramework;
using AutoMapper;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public class ProductService : CrudServiceBase<long, Product, GetProductOutput, CreateProductInput, UpdateProductInput>
    {
        public ProductService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}