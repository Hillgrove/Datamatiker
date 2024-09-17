
namespace ActorRepositoryLib
{
    public interface IEntity
    {
        int Id { get; set; }
        
        void Validate();
    }
}
