using System.Linq.Expressions;

namespace AktifTech.CustomerOrderRestApi.EntityFramework
{
    public interface IRepository<T, TPrimaryKey>
        where T : class
        where TPrimaryKey : struct
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T GetById(TPrimaryKey id);
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(TPrimaryKey id);
    }
}