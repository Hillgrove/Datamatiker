using System.Linq.Expressions;

namespace ActorRepositoryLib
{
    public interface IRepository<T> where T : IEntity
    {
        T Add(T entity);
        T? GetById(int id);
        IQueryable<T> Get(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
        T? Update(int id, T entity);
        T? Delete(int id);
    }
}