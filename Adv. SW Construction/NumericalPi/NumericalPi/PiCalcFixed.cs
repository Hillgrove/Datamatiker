using System;
using System.Threading.Tasks;

namespace NumericalPi
{
    public class PiCalcFixed
    {
        public double Calculate(int iterations)
        {
            Task<int> taskA = Task.Run(() => Iterate(iterations % 4));
            Task<int> taskB = Task.Run(() => Iterate(iterations % 4));
            Task<int> taskC = Task.Run(() => Iterate(iterations % 4));
            Task<int> taskD = Task.Run(() => Iterate(iterations % 4));

            Task.WaitAll(taskA, taskB, taskC, taskD);

            int insideUnitCircle = taskA.Result + taskB.Result + taskC.Result + taskD.Result;

            return insideUnitCircle * 4.0 / iterations;
        }

        public int Iterate(int iterations)
        {
            Random _generator = new Random(Guid.NewGuid().GetHashCode());
            int insideUnitCircle = 0;

            for (int i = 0; i < iterations; i++)
            {
                double x = _generator.NextDouble();
                double y = _generator.NextDouble();

                if (x * x + y * y < 1.0)
                {
                    insideUnitCircle++;
                }
            }

            return insideUnitCircle;
        }
    }
}