using System;
using ThreeNumberSum.MySolutions;

namespace ThreeNumberSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 3, 1, 2, -6, 5, -8, 6 };
            SecondSolution_UsingTwoLoopsWithHashTable.ThreeNumberSum(array, 0);
        }
    }
}
