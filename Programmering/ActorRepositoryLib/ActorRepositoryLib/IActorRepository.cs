
namespace ActorRepositoryLib
{
    public interface IActorRepository<T> where T : IActor
    {
        T Add(T entity);
        T? Delete(int id);
        List<T> Get(Func<T, bool>? filter = null);
        //List<T> Get(int? minBirtYear = null, string? name = null, string? sortBy = null);
        T? GetById(int id);
        T? Update(int id, T entity);
    }
}