
using SharedCalculator;

List<string> VALID_OPERATORS = new List<string>() { "+", "-", "*", "/" };
Calculator calculator = new Calculator();
double x;
double y;
double result;

Console.WriteLine("Welcome to the C.A.L.C.U.L.A.T.O.R");

bool isRunning = true;
do
{
    Console.Write("Which calculation do you want to do (+, -, *, /): ");
    string? @operator = Console.ReadLine();

    if (!string.IsNullOrEmpty(@operator) && VALID_OPERATORS.Contains(@operator))
    {
        Console.Write("Value of x: ");
        x = double.Parse(Console.ReadLine()!);
        Console.Write("Value of y: ");
        y = double.Parse(Console.ReadLine()!);


        switch (@operator)
        {
            case "+":
                result = calculator.Add(x, y);
                Console.WriteLine($"{x} {@operator} {y} = {result}");
                break;

            case "-":
                result = calculator.Subtract(x, y);
                Console.WriteLine($"{x} {@operator} {y} = {result}");
                break;

            case "*":
                // TODO
                break;

            case "/":
                // TODO
                break;

            default:
                // TODO
                break;
        }
    }

}
while (isRunning);