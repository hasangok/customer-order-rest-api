namespace AktifTech.CustomerOrderRestApi.Services
{
    public class GetProductOutput
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}