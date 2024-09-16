
namespace ActorRepositoryLib
{
    public interface IActorRepository
    {
        Actor Add(Actor actor);
        Actor? Delete(int id);
        List<Actor> Get(int? minBirtYear = null, string? name = null, string? sortBy = null);
        Actor? GetById(int id);
        Actor? Update(int id, Actor actor);
    }
}