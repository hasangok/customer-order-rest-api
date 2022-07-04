using System.Linq.Expressions;
using AktifTech.CustomerOrderRestApi.Model;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public interface ICrudServiceBase<TPrimaryKey, TEntity, TGetDto, TCreateDto, TUpdateDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TPrimaryKey : struct
    {
        
        IEnumerable<TGetDto> Get();
        IEnumerable<TGetDto> Get(Expression<Func<TEntity, bool>> predicate);
        TGetDto Get(TPrimaryKey id);
        TGetDto Create(TCreateDto input);
        TGetDto Update(TPrimaryKey id, TUpdateDto input);
        TGetDto Remove(TPrimaryKey id);
    }
}