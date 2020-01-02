using System;
using System.Collections.Generic;

namespace ToH_AfterNightOut
{
    public class ToHAfterNightOut
    {
        static void Main(string[] args)
        {
            int n, k, a, b, c;
            if (args.Length > 5)
            {
                try
                {
                    n = Convert.ToInt32(args[0]);
                    k = Convert.ToInt32(args[1]);
                    a = Convert.ToInt32(args[2]);
                    b = Convert.ToInt32(args[3]);
                    c = Convert.ToInt32(args[4]);
                }
                catch (Exception exe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The arguments supplied wasn't of proper format.\n" + exe.Message);
                    Console.WriteLine("Setting default values for n,k,a,b,c");
                    n = 10000;  //Number of Disks
                    k = 10; a = 3; b = 6; c = 9; //testing for the required problem statement.
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                n = 10000;  //Number of Disks
                k = 10; a = 3; b = 6; c = 9; //testing for the required problem statement.
            }

            Console.WriteLine($"\n{"----------------------------"} Tower of Hanoi {"----------------------------"}\n\n");

            //-----------Mathematical Approach----------//
            Console.WriteLine($"Number of steps count for ∑1≤n≤10000 E(n,10n,3n,6n,9n):\t{mathematicallySolve(n, k, a, b, c)}");

            Console.WriteLine($"Number of steps count for n=2 E(2,5,1,3,5):\t{StepsCountForFixedDiskCount(2, 5, 1, 3, 5)}");

            Console.WriteLine($"Number of steps count for n=2 E(3,20,4,9,17):\t{StepsCountForFixedDiskCount(3, 20, 4, 9, 17)}");


            //computationllyExpensiveSolution(n, k*n, a*n, b*n, c*n); //Not Feasible Computationally.[MemoryOutofBoundException] (for more info refer readme file)
            Console.Write("Press any key to exit: ");
            Console.ReadKey();
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
        public static int mathematicallySolve(int noOfDisk, int kSquareTiles, int source, int auxiliary, int destination)
        {
            int mod = (int)Math.Pow(10, 9);
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
        /// <param name="lastSofN"></param>
        /// <param name="currentSofN"></param>
        /// <returns name="bobStepCount"></returns>
        public static long StepsCountForFixedDiskCount(int diskCount, int kSquareTiles, int source, int auxiliary, int destination)
        {
            int mod = (int)Math.Pow(10, 9);

            long currentSofN = (long)(Math.Pow(2, (int)(diskCount + 2)) - 3 - Math.Pow((-1), (int)diskCount)) / 6;  //Math.Pow functions fails to return correct value, for large value of diskCount.
            int result = (int)(2 * currentSofN * (destination - source) * (kSquareTiles - 1) - (2 * kSquareTiles - auxiliary - destination) * (destination - auxiliary)) % 1000000000;
            return result;
        }

        /// <summary>
        /// Not feasible. This problem belongs to set of those problems, which are only feasible with infinite Time & Resource. 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private static void computationllyExpensiveSolution(int n, int k, int a, int b, int c)
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
        private static long countStepsFromStats(Dictionary<Tuple<int, int>, int> stats)
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
        public static void printToHStats(int n, Dictionary<Tuple<int, int>, int> StepStats)
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

    /// <summary>
    /// This class contains has ToHAlgo Implementation, with modification to count the stepsCount & store each move.
    /// </summary>
    class TowerOfHanoiAlgo
    {
        public List<Tuple<int, int>> movement = new List<Tuple<int, int>>();

        /// <summary>
        /// This function is to play tower of hanoi game with modified rules.
        /// It takes 'k' Square Tiles into account & plays for steps count.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns name="stats">dsfsdf</returns>
        public Dictionary<Tuple<int, int>, int> playToHGame(int n, int k, int a, int b, int c)
        {
            movement.Add(new Tuple<int, int>(b, b));    //For handling the 1st move of 'B' to 'A'; marking starting point as b,b
            moveTower(n, a, c, b);
            return gameStats(a, b, c);
        }

        /// <summary>
        /// This function implements ToH Algorithm.
        /// </summary>
        /// <param name="height" type="int"></param>
        /// <param name="fromPeg" type="int"></param>
        /// <param name="toPeg" type="int"></param>
        /// <param name="withPeg" type="int"></param>
        public void moveTower(int height, int fromPeg, int toPeg, int withPeg)
        {
            if (height >= 1)
            {
                moveTower(height - 1, fromPeg, withPeg, toPeg);
                moveDisk(fromPeg, toPeg);
                moveTower(height - 1, withPeg, toPeg, fromPeg);
            }
        }

        /// <summary>
        /// This Method is for storing movement of each disk from 'fromPeg' to 'toPeg'.
        /// </summary>
        /// <param name="fromPeg" type="int"></param>
        /// <param name="toPeg" type="int"></param>
        public void moveDisk(int fromPeg, int toPeg)
        {
            movement.Add(new Tuple<int, int>(fromPeg, toPeg));
        }

        /// <summary>
        /// This Method is for storing sum of each difference of movement from 'fromPeg' to 'toPeg'.
        /// Basically it stores the sum of step count for each unique movement.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns name="stats"></returns>
        public Dictionary<Tuple<int, int>, int> gameStats(int a, int b, int c)
        {
            Dictionary<Tuple<int, int>, int> stats = new Dictionary<Tuple<int, int>, int>();
            int movement_count = movement.Count;
            int currFromPeg, currToPeg, nextFromPeg, nextToPeg;
            for (int i = 0; i < movement_count - 1; i++)
            {
                currFromPeg = movement[i].Item1;
                currToPeg = movement[i].Item2;
                nextFromPeg = movement[i + 1].Item1;
                nextToPeg = movement[i + 1].Item2;
                foreach (var currMovement in new List<Tuple<int, int>>() { new Tuple<int, int>(currFromPeg, currToPeg), new Tuple<int, int>(currToPeg, nextFromPeg) })
                {
                    if (!stats.ContainsKey(currMovement))
                        stats[currMovement] = 0;
                    stats[currMovement] += Math.Abs(currMovement.Item1 - currMovement.Item2);
                }
            }
            var currMovementLast = movement[movement.Count - 1];
            if (!stats.ContainsKey(currMovementLast))
                stats[currMovementLast] = 0;
            stats[currMovementLast] += Math.Abs(currMovementLast.Item1 - currMovementLast.Item2);
            return stats;
        }
    }
}
