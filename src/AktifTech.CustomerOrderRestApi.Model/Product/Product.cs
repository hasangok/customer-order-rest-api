namespace AktifTech.CustomerOrderRestApi.Model
{
    public class Product : Entity<long>, IHasCreationTime, IHasModificationTime
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}