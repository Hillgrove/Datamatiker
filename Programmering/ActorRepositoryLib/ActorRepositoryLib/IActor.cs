namespace ActorRepositoryLib
{
    public interface IActor : IEntity
    {
        string? Name { get; set; }
        int BirthYear { get; set; }
        void ValidateBirthYear();
        void ValidateName();
    }
}