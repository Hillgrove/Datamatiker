using System;
using System.Diagnostics;

namespace NumericalPi
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            PiCalc calculatorOrg = new PiCalc();
            PiCalcFixed calculatorFixed = new PiCalcFixed();
            PiCalcListOfTasks calculatorListofTasks = new PiCalcListOfTasks();
            PiCalcParallel calculcatorParallel = new PiCalcParallel();

            Console.WriteLine("Started");
            watch.Start();
            double numPi = calculcatorParallel.Calculate(100000000, 16);
            watch.Stop();
            Console.WriteLine("Done");

            Console.WriteLine($"Numeric PI = {numPi:0.000000}");
            Console.WriteLine($"Real PI    = {Math.PI:0.000000}");
            Console.WriteLine($"Took {watch.ElapsedMilliseconds} milliSecs");
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");

            Console.ReadKey();
        }
    }
}
