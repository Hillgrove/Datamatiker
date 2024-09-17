
using System.Linq.Expressions;

namespace ActorRepositoryLib
{
    public class ActorRepositoryList<T> : IRepository<T> where T : IActor
    { 
        private int _nextId = 1;
        private List<T> _entities = new();

        public T Add(T entity)
        {
            entity.Validate();
            entity.Id = _nextId++;
            _entities.Add(entity);
            return entity;
        }

        public T? GetById(int id)
        {
            return _entities.Find(entity => entity.Id == id);
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> queryableData = _entities.AsQueryable();

            // Apply predicates if any
            if (predicate != null)
            {
                queryableData = queryableData.Where(predicate);
                
            }

            // Apply sorting if any
            if (orderBy != null)
            {
                queryableData = orderBy(queryableData);
            }

            return queryableData;
        }

        public T? Update(int id, T entity)
        {
            entity.Validate();
            T? existingEntity = GetById(id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            existingEntity.Name = entity.Name;
            existingEntity.BirthYear = entity.BirthYear;
            return existingEntity;
        }

        public T? Delete(int id)
        {
            T? entity = GetById(id);

            if (entity == null)
            {
                return default(T); // null
            }

            _entities.Remove(entity);
            return entity;
        }
    }
}
