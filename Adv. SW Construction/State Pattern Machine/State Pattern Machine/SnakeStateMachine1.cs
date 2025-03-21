namespace State_Pattern_Machine
{
    public class NorthState : IState
    {
        public static readonly NorthState Instance = new NorthState();

        public Move NextMove(InputType input)
        {
            switch (input)
            {
                case InputType.Left:
                    SnakeStateMachine1.CurrentState = WestState.Instance;
                    return WestState.Instance.Offset;
                case InputType.Right:
                    SnakeStateMachine1.CurrentState = EastState.Instance;
                    return EastState.Instance.Offset;
            }

            return Offset;
        }

        public Move Offset => new Move(-1, 0);
    }

    public class EastState : IState
    {
        public static readonly EastState Instance = new EastState();

        public Move NextMove(InputType input)
        {
            switch (input)
            {
                case InputType.Left:
                    SnakeStateMachine1.CurrentState = NorthState.Instance;
                    return NorthState.Instance.Offset;
                case InputType.Right:
                    SnakeStateMachine1.CurrentState = SouthState.Instance;
                    return SouthState.Instance.Offset;
            }

            return Offset;
        }
        public Move Offset => new Move(0, 1);
    }

    public class SouthState : IState
    {
        public static readonly SouthState Instance = new SouthState();

        public Move NextMove(InputType input)
        {
            switch (input)
            {
                case InputType.Left:
                    SnakeStateMachine1.CurrentState = EastState.Instance;
                    return EastState.Instance.Offset;
                case InputType.Right:
                    SnakeStateMachine1.CurrentState = WestState.Instance;
                    return WestState.Instance.Offset;
            }

            return Offset;
        }
        public Move Offset => new Move(1, 0);
    }

    public class WestState : IState
    {
        public static readonly WestState Instance = new WestState();

        public Move NextMove(InputType input)
        {
            switch (input)
            {
                case InputType.Left:
                    SnakeStateMachine1.CurrentState = SouthState.Instance;
                    return SouthState.Instance.Offset;
                case InputType.Right:
                    SnakeStateMachine1.CurrentState = NorthState.Instance;
                    return NorthState.Instance.Offset;
            }

            return Offset;
        }
        public Move Offset => new Move(0, -1);
    }

    public class SnakeStateMachine1
    {
        public static IState CurrentState { get; set; }

        public SnakeStateMachine1(IState initialState)
        {
            CurrentState = initialState;
        }

        public Move NextMove(InputType input)
        {
            return CurrentState.NextMove(input);
        }
    }

    public class SnakePlayground
    {
        readonly int rows, cols;
        public (int Row, int Col) SnakeHead { get; private set; }

        public SnakePlayground(int rows = 20, int cols = 20)
        {
            this.rows = rows;
            this.cols = cols;
            SnakeHead = (rows / 2, cols / 2);
        }

        public void MoveSnake(Move move)
        {
            int newRow = SnakeHead.Row + move.Row;
            int newCol = SnakeHead.Col + move.Col;

            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                throw new Exception("Snake hit the wall");

            SnakeHead = (newRow, newCol);
        }

        public string GetBoard()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(i == SnakeHead.Row && j == SnakeHead.Col ? "0" : ".");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}