namespace AktifTech.CustomerOrderRestApi.Model
{
    public class CustomerAddress : Entity<long>, IHasCreationTime, IHasModificationTime
    {
        public CustomerAddress(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}