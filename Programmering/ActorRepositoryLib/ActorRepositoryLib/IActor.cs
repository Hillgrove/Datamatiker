namespace ActorRepositoryLib
{
    public interface IActor : IEntity, IHasName, IHasBirthYear
    {
        void ValidateBirthYear();
        void ValidateName();
    }
}