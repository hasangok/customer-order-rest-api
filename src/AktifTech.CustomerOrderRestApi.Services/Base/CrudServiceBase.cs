using System.Linq.Expressions;
using AktifTech.CustomerOrderRestApi.EntityFramework;
using AktifTech.CustomerOrderRestApi.Model;
using AutoMapper;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public abstract class CrudServiceBase<TPrimaryKey, TEntity, TGetDto, TCreateDto, TUpdateDto> : ICrudServiceBase<TPrimaryKey, TEntity, TGetDto, TCreateDto, TUpdateDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TGetDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TPrimaryKey : struct
    {
        protected readonly Repository<TEntity, TPrimaryKey> _repository;
        protected readonly IMapper _mapper;

        public CrudServiceBase(AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _repository = new Repository<TEntity, TPrimaryKey>(dbContext);
        }

        public IEnumerable<TGetDto> Get()
        {
            return _mapper.Map<IEnumerable<TGetDto>>(_repository.GetAll());
        }

        public IEnumerable<TGetDto> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TGetDto>>(_repository.GetAll(predicate));
        }

        public IEnumerable<TGetDto> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return _mapper.Map<IEnumerable<TGetDto>>(_repository.GetAll(predicate, includes));
        }

        public TGetDto Get(TPrimaryKey id)
        {
            return _mapper.Map<TGetDto>(_repository.GetById(id));
        }

        public TGetDto Create(TCreateDto input)
        {
            var entity = _mapper.Map<TEntity>(input);
            _repository.Add(entity);
            return _mapper.Map<TGetDto>(entity);
        }

        public TGetDto Update(TPrimaryKey id, TUpdateDto input)
        {
            var entity = _repository.GetById(id);
            _repository.Update(_mapper.Map<TUpdateDto, TEntity>(input, entity));
            return _mapper.Map<TGetDto>(entity);
        }
        public TGetDto Remove(TPrimaryKey id)
        {
            var entity = _repository.GetById(id);
            _repository.Delete(id);
            return _mapper.Map<TGetDto>(entity);
        }
    }
}