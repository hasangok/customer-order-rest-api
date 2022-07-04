using System.ComponentModel.DataAnnotations;

namespace AktifTech.CustomerOrderRestApi.Model
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Key]
        public virtual TPrimaryKey Id { get; set; }
    }
}