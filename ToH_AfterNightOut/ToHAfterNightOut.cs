using System;
using ToH_AfterNightOut.Helpers;

namespace ToH_AfterNightOut
{
    public class ToHAfterNightOut
    {
        static void Main(string[] args)
        {
            int n, k, a, b, c;
            MathematicalSolution mathematicalSoln = new MathematicalSolution();

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
            Console.WriteLine($"Number of steps count for ∑1≤n≤10000 E(n,10n,3n,6n,9n):\t{mathematicalSoln.mathematicallySolve(n, k, a, b, c)}");

            Console.WriteLine($"Number of steps count for n=2 E(2,5,1,3,5):\t{mathematicalSoln.StepsCountForFixedDiskCount(2, 5, 1, 3, 5)}");

            Console.WriteLine($"Number of steps count for n=3 E(3,20,4,9,17):\t{mathematicalSoln.StepsCountForFixedDiskCount(3, 20, 4, 9, 17)}");


            //Not Feasible Computationally.[MemoryOutofBoundException] (for more info refer readme file)
            //computationllyExpensiveSolution(n, k*n, a*n, b*n, c*n);
            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
