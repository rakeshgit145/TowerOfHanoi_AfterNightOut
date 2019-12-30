using System;
using System.Collections.Generic;

namespace ToH_AfterNightOut
{
    class ToHAfterNightOut
    {
        static void Main(string[] args)
        {
            int n = 3;  //Number of Disks
            int k = 3, a = 1, b = 2, c = 3; //testing for the best case values, for optimum solution, which 

            Console.WriteLine($"\n{"----------------------------"} Tower of Hanoi {"----------------------------"}\n\n");

            var stats = new TowerOfHanoiAlgo().playToHGame(n, k, a, b, c);
            var stepsCount = countStepsFromStats(stats);

            Console.WriteLine($"Number of steps count for n=3 E({n},{k},{a},{b},{c}):\t{stepsCount}\n");

            Console.WriteLine("The stats of each the movement & the sum of steps count of each of them are:-");
            printToHStats(n, stats);    //For Printing the stats data
        }

        private static long countStepsFromStats(Dictionary<Tuple<int, int>, int> stats)
        {
            long totalStepsCount = 0;
            foreach (var stepsSum in stats.Values)
            {
                totalStepsCount += stepsSum;
            }
            return totalStepsCount;
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
