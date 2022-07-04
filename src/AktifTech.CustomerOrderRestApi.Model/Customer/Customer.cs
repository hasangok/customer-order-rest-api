namespace AktifTech.CustomerOrderRestApi.Model
{
    public class Customer : Entity<long>, IHasCreationTime, IHasModificationTime
    {
        public string Name { get; set; }
        public ICollection<CustomerAddress> Addresses { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}