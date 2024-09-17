
namespace ActorRepositoryLib
{
    public class ActorRepositoryList<T> : IActorRepository<T> where T : IActor
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

        public List<T> Get(Func<T, bool>? filter = null)
        {
            var result = _entities.AsEnumerable();
            if (filter != null)
            {
                result = result.Where(filter);
            }

            return result.ToList();
        }

        public List<T> Get(int? minBirtYear = null, string? name = null, string? sortBy = null)
        {
            List<T> result = new List<T>(_entities);
            if (minBirtYear != null)
            {
                result = result.FindAll(e => e.BirthYear >= minBirtYear);
            }

            if (name != null)
            {
                result = result.FindAll(e => e.Name == name);
            }

            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        result.Sort((t1, t2) => t1.Name.CompareTo(t2.Name));
                        break;

                    case "namedesc":
                        result.Sort((t1, t2) => t2.Name.CompareTo(t1.Name));
                        break;

                    case "birthyear":
                        result.Sort((t1, t2) => t1.BirthYear.CompareTo(t2.BirthYear));
                        break;
                }
            }

            return result;
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
