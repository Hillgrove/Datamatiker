
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

        public Actor? Get(int id)
        {
            return _actors.Find(actor => actor.Id == id);
        }

        public IEnumerable<Actor> GetAll()
        {
            IEnumerable<Actor> actors = new List<Actor>(_actors);
            return actors;
        }

        public Actor? Update(int id, Actor actor)
        {
            actor.Validate();
            Actor? existingActor = Get(id);

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
            Actor? actor = Get(id);

            if (actor == null)
            {
                return null;
            }

            _actors.Remove(actor);
            return actor;
        }
    }
}
