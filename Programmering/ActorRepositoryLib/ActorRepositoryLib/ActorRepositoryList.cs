
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
            Expression<Func<T, bool>>[]? predicates = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? sortBy = null)
        {
            IQueryable<T> queryableData = _entities.AsQueryable();

            // Apply predicates if any
            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    queryableData = queryableData.Where(predicate);
                }
            }

            // Apply sorting if any
            if (sortBy != null)
            {
                queryableData = sortBy(queryableData);
            }

            return queryableData.AsEnumerable().AsQueryable();
        }

        public T? Update(int id, T entity)
        {
            entity.Validate();
            T? existingEntity = GetById(id);

            if (existingEntity == null)
            {
                return default(T); // null
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
