using System;
using System.Collections.Generic;

namespace ToH_AfterNightOut
{
    class ToHAfterNightOut
    {
        static void Main(string[] args)
        {
            int n = 10000;  //Number of Disks
            int k = 10, a = 3, b = 6, c = 9; //testing for the best case values, for optimum solution

            Console.WriteLine($"\n{"----------------------------"} Tower of Hanoi {"----------------------------"}\n\n");

            //-----------Mathematical Approach----------//
            Console.WriteLine($"Number of steps count for ∑1≤n≤10000 E(n,10n,3n,6n,9n):\t{mathematicallySolve(n, k, a, b, c)}");


            //computationllyExpensiveSolution(n, k*n, a*n, b*n, c*n); //Not Feasible Computationally.[MemoryOutofBoundException] (for more info refer readme file)
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
        static int mathematicallySolve(int noOfDisk, int kSquareTiles, int source, int auxiliary, int destination)
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

        private static long countStepsFromStats(Dictionary<Tuple<int, int>, int> stats)
        {
            long stepsCount = 0;
            foreach (var stepsSum in stats.Values)
            {
                stepsCount += stepsSum;
            }
            return stepsCount;
        }

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
