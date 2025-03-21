using State_Pattern_Machine;

var stateMachine = new SnakeStateMachine1(NorthState.Instance);
var playground = new SnakePlayground();

Console.CursorVisible = false;

while (true)
{
    // Build the board as a string and write it in one go
    Console.SetCursorPosition(0, 0);
    Console.Write(playground.GetBoard());

    InputType input = InputType.Forward;
    if (Console.KeyAvailable)
    {
        char key = Console.ReadKey(true).KeyChar;
        switch (key)
        {
            case 'a': input = InputType.Left; break;
            case 'd': input = InputType.Right; break;
        }
    }
    try
    {
        Move move = stateMachine.NextMove(input);
        playground.MoveSnake(move);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        break;
    }
    System.Threading.Thread.Sleep(200);
}