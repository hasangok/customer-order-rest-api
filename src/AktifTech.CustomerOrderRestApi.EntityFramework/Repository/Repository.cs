using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AktifTech.CustomerOrderRestApi.EntityFramework
{
    public class Repository<T, TPrimaryKey> : IRepository<T, TPrimaryKey>
        where T : class
        where TPrimaryKey : struct
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext can not be null.");
            }

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var data = _dbSet.Where(predicate);
            return includes.Aggregate(data, (current, includeProperty) => current.Include(includeProperty));
        }

        public T GetById(TPrimaryKey id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var data = _dbSet.Where(predicate);
            return includes.Aggregate(data, (current, includeProperty) => current.Include(includeProperty)).SingleOrDefault();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity.GetType().GetProperty("IsDeleted") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("IsDeleted").SetValue(_entity, true);

                this.Update(_entity);
            }
            else
            {
                EntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
            _dbContext.SaveChanges();
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = GetById(id);
            if (entity == null) throw new Exception("This record does not exists in db!");
            else
            {
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("IsDeleted").SetValue(_entity, true);

                    this.Update(_entity);
                }
                else
                {
                    Delete(entity);
                }
                _dbContext.SaveChanges();
            }
        }
    }
}