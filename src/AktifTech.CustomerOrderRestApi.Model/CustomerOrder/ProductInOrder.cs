namespace AktifTech.CustomerOrderRestApi.Model
{
    public class ProductInOrder : Entity<long>
    {
        public long CustomerOrderId { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}