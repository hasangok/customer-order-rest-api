namespace AktifTech.CustomerOrderRestApi.Model
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}