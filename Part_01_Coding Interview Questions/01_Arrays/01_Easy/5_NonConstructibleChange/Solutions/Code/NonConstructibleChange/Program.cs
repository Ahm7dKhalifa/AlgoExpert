using NonConstructibleChange.MySolutions;
using System;

namespace NonConstructibleChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = {5, 7, 1, 1, 2, 3, 22};

            FirstSolution_UsingDictionary sol = new FirstSolution_UsingDictionary();
            
             sol.NonConstructibleChange(coins);

            //FindAllPossibleSumsOfArray FindAllPossibleSumsOfArray = new FindAllPossibleSumsOfArray();

             //var result = FindAllPossibleSumsOfArray.GetAsHashSet(coins);

            Console.WriteLine("hello");
        }
    }
}
