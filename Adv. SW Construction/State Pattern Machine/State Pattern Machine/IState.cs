namespace State_Pattern_Machine
{
    public enum InputType
    {
        Left,
        Right,
        Forward
    }

    public record Move(int Row, int Col);

    public interface IState
    {
        Move NextMove(InputType input);
    }
}
