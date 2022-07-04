namespace AktifTech.CustomerOrderRestApi.Services
{
    public class GetCustomerOrderOutput
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string AddressName { get; set; }
        public string Address { get; set; }
        public ICollection<GetProductInOrderOutput> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}