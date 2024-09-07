
using SharedCalculator;

List<string> VALID_OPERATORS = new List<string>() { "+", "-", "*", "/", "quit" };
Calculator calculator = new Calculator();
double x;
double y;
double result;

Console.WriteLine("Welcome to the C.A.L.C.U.L.A.T.O.R.");
Console.WriteLine("To quit type \"quit\"");

bool isRunning = true;
do
{
    Console.Write("\nWhich calculation do you want to do (+, -, *, /): ");
    string? @operator = Console.ReadLine()?.ToLower();

    if (!string.IsNullOrEmpty(@operator) && VALID_OPERATORS.Contains(@operator))
    {
        if (@operator == "quit")
        {
            isRunning = false;
            break;
        }

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
                result = calculator.Multiply(x, y);
                Console.WriteLine($"{x} {@operator} {y} = {result}");
                break;

            case "/":
                result = calculator.Divide(x, y);
                Console.WriteLine($"{x} {@operator} {y} = {result}");
                break;
        }
    }
}
while (isRunning);

Console.WriteLine("\nThanks for using C.A.L.C.U.L.A.T.O.R.");