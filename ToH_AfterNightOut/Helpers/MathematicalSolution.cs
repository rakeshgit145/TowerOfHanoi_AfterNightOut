using System;
using System.Collections.Generic;

namespace ToH_AfterNightOut.Helpers
{
    public class MathematicalSolution
    {
        int mod;

        public MathematicalSolution()
        {
            mod = (int)Math.Pow(10, 9);
        }

        /// <summary>
        /// Working mathemetical approach for computing ToH for each n for O(1).
        /// So over all the Time Complexity of the algo becomes O(n).(see readme file)
        /// </summary>
        /// <param name="noOfDisk"></param>
        /// <param name="kSquareTiles"></param>
        /// <param name="source"></param>
        /// <param name="auxiliary"></param>
        /// <param name="destination"></param>
        /// <returns name="finalStepCount"></returns>
        public int mathematicallySolve(int noOfDisk, int kSquareTiles, int source, int auxiliary, int destination)
        {
            int finalStepCount = 0;
            long lastSofN = 0, currentSofN = 1;

            for (int i = 1; i <= noOfDisk; i++)
            {
                long bobStepCount = (2 * currentSofN * (destination - source) * (kSquareTiles - 1) - (2 * kSquareTiles - auxiliary - destination) * (destination - auxiliary)) % mod;
                finalStepCount = (int)(finalStepCount + bobStepCount) % mod;

                var temp = lastSofN;
                lastSofN = currentSofN;
                currentSofN = (currentSofN + 2 * temp + 1) % mod;

                kSquareTiles = (10 * i) % mod;
                source = (3 * i) % mod;
                auxiliary = (6 * i) % mod;
                destination = (9 * i) % mod;
            }
            return finalStepCount;
        }

        /// <summary>
        /// Computes StepCount for a specified number of disk count.
        /// </summary>
        /// <param name="diskCount"></param>
        /// <param name="kSquareTiles"></param>
        /// <param name="source"></param>
        /// <param name="auxiliary"></param>
        /// <param name="destination"></param>
        /// <returns name="result"></returns>
        public int StepsCountForFixedDiskCount(int diskCount, int kSquareTiles, int source, int auxiliary, int destination)
        {
            int currentSofN = (customPowFun(2, (diskCount + 2)) - 3 - customPowFun((-1), diskCount)) / 6;  //customPowFun() functions fails to return correct value, for large value of diskCount, for diskCount>3024

            int result = (int)(2 * currentSofN * (destination - source) * (kSquareTiles - 1) - (2 * kSquareTiles - auxiliary - destination) * (destination - auxiliary)) % mod;
            return result;
        }

        /// <summary>
        /// This function is to calculate power related to the our use case.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="toPow"></param>
        /// <returns name="val"></returns>
        int customPowFun(int num, int toPow)
        {
            int val = num;
            for (int i = 1; i < toPow; i++)
            {
                val = (val * 2) % mod;
            }
            return val;
        }

        /// <summary>
        /// Not feasible for large number of disk. This problem belongs to set of those problems, which are only feasible with infinite Time & Resource. 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private void computationllyExpensiveSolution(int n, int k, int a, int b, int c)
        {
            long totalStepsCount = 0;
            for (int i = 1; i <= n; i++)
            {
                var stats = new TowerOfHanoiAlgo().playToHGame(i, k, a, b, c);
                var stepsCount = countStepsFromStats(stats);
                totalStepsCount += stepsCount;

                Console.WriteLine($"Number of steps count for n=3 E({i},{k},{a},{b},{c}):\t{stepsCount}\n");

                Console.WriteLine("The stats of each the movement & the sum of steps count of each of them are:-");
                printToHStats(i, stats);    //For Printing the stats data 
            }
            Console.WriteLine($"Total number of steps = {totalStepsCount}");
            Console.WriteLine($"Last 9 digits of total Number of steps count for ∑1≤n≤10000 E(n,10n,3n,6n,9n):\t{(totalStepsCount % Math.Pow(10, 9))}");
        }

        /// <summary>
        /// This Method counts total steps by adding total step count for each unique steps.
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        private long countStepsFromStats(Dictionary<Tuple<int, int>, int> stats)
        {
            long stepsCount = 0;
            foreach (var stepsSum in stats.Values)
            {
                stepsCount += stepsSum;
            }
            return stepsCount;
        }

        /// <summary>
        /// This Method prints the stats data in readable format
        /// </summary>
        /// <param name="n"></param>
        /// <param name="StepStats"></param>
        public void printToHStats(int n, Dictionary<Tuple<int, int>, int> StepStats)
        {
            Console.Write($"{n} => ");
            foreach (var item in StepStats)
            {
                Console.Write("{");
                Console.Write($"({ item.Key.Item1}, {item.Key.Item2}) : {item.Value}");
                Console.Write("}");
            }
            Console.WriteLine();
        }
    }
}
