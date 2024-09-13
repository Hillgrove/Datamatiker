
namespace ActorRepositoryLib
{
    public class ActorRepository
    {
        private int _nextId = 1;
        private List<Actor> _actors = new();

        public Actor Add(Actor actor)
        {
            actor.Validate();
            actor.Id = _nextId++;
            _actors.Add(actor);
            return actor;
        }

        public Actor? GetById(int id)
        {
            return _actors.Find(actor => actor.Id == id);
        }

        public List<Actor> Get(int? minBirtYear = null, string? name=null, string? sortBy = null)
        {
            List<Actor> result = new List<Actor>(_actors);
            if (minBirtYear != null)
            {
                result = result.FindAll(a => a.BirthYear >= minBirtYear);
            }

            if (name != null)
            {
                result = result.FindAll(a => a.Name == name);
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

        public Actor? Update(int id, Actor actor)
        {
            actor.Validate();
            Actor? existingActor = GetById(id);

            if (existingActor == null)
            {
                return null;
            }

            existingActor.Name = actor.Name;
            existingActor.BirthYear = actor.BirthYear;
            return existingActor;
        }

        public Actor? Delete(int id)
        {
            Actor? actor = GetById(id);

            if (actor == null)
            {
                return null;
            }

            _actors.Remove(actor);
            return actor;
        }
    }
}
