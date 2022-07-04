namespace AktifTech.CustomerOrderRestApi.Services
{
    public class GetCustomerOutput
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetCustomerAddressOutput> Addresses { get; set; }
        public DateTime Created { get; set; }
    }
}