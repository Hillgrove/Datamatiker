
/// <summary>
/// This class manages the execution of a calculation simulation
/// </summary>
public class Manager
{    
    /// <summary>
    /// Runs the simulation
    /// </summary>
    public static void Run(int maxX, int maxY, int maxIterations, bool useCache)
    {
        Simulator theSimulator = new Simulator(maxX, maxY, useCache);
        Random theGenerator = new Random();

        // Runs the simulation maxIterations times
        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            int x = theGenerator.Next(0, maxX);
            int y = theGenerator.Next(0, maxY);
            int? value = theSimulator.Calculate(x, y);
            Console.WriteLine($"Iteration {iteration:000} :   ({x},{y}) => {value}");
        }
    }
}
