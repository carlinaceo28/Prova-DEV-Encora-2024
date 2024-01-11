using System;
using System.Collections.Generic;
using System.Linq;
namespace Encora
{
    class Program
    {
        private static readonly int quarter = 25;
        private static readonly int dime = 10;
        private static readonly int nickel = 5;
        /// <summary>
        /// In the main function we will:
        /// -> read the input
        /// -> call MakeChange to get the resultant set
        /// -> call PrintHashSet to print the result
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Write the amount to be converted into coins");
            int amount = int.Parse(Console.ReadLine());
            var changes = MakeChange(amount);
            PrintHashSet(changes);
        }
        private static void PrintHashSet(HashSet<int[]> changesSet)
        {
            var changesArr = changesSet.ToArray();
            string result = "";
            result += "[";
            for (int i = 0; i < changesArr.Length; i++)
            {
                var change = changesArr[i];
                result += string.Format("[{0},{1},{2},{3}]", change[0], change[1], change[2], change[3]);
                if (i < changesArr.Length - 1)
                {
                    result += ", ";
                }
            }
            result += "]";
            Console.WriteLine(result);
        }
        /// <summary>
        /// Here we find all the possible sets iteratively adding the different coin values:
        /// We iterate using first the pennies then the nickels and so on
        /// When we find a coin combination that is lesser than the desired coin amount we add
        /// to the set the current amount of each coin
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static HashSet<int[]> MakeChange(int amount)
        {
            HashSet<int[]> result = new HashSet<int[]>();
            for (int quarters = 0; quarters * quarter <= amount; ++quarters)
            {
                for (int dimes = 0; dimes * dime <= amount; ++dimes)
                {
                    for (int nickels = 0; nickels * nickel <= amount; ++nickels)
                    {
                        int total = quarters * quarter + dimes * dime + nickels * nickel;
                        if (total <= amount)
                        {
                            int[] currentSolution = new[] { quarters, dimes, nickels, amount - total };
                            result.Add(currentSolution);
                        }
                    }
                }
            }
            return result;
        }
    }
}