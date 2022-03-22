using MoveElemntToEnd.MySolutions;
using System;
using System.Linq;

namespace MoveElemntToEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 2, 1, 2, 2, 2, 3, 4, 2 };

            FirstSolution_UsingTwoPointers.MoveElementToEnd(testArray.ToList(), 2);


        }
    }
}
