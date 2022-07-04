namespace AktifTech.CustomerOrderRestApi.Model
{
    public interface IHasModificationTime
    {
        DateTime? Modified { get; set; }
    }
}