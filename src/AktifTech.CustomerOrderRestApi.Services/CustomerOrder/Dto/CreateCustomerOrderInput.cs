namespace AktifTech.CustomerOrderRestApi.Services
{
    public class CreateCustomerOrderInput
    {
        public long AddressId { get; set; }
        public ICollection<CreateProductInOrderInput> Products { get; set; }
    }
}