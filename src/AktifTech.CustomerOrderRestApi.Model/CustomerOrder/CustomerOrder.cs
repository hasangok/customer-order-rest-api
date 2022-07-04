namespace AktifTech.CustomerOrderRestApi.Model
{
    public class CustomerOrder : Entity<long>, IHasCreationTime, IHasModificationTime
    {
        public CustomerOrder(long customerId)
        {
            CustomerId = customerId;
        }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long AddressId { get; set; }
        public CustomerAddress Address { get; set; }
        public ICollection<ProductInOrder> Products { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}