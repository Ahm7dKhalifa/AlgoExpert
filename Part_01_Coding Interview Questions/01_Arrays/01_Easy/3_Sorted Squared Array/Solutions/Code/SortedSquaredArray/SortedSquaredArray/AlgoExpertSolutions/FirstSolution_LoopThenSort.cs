using System;
using System.Collections.Generic;
using System.Text;

namespace SortedSquaredArray.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved.
    public class FirstSolution_LoopThenSort
    {
        // O(nlogn) time | O(n) space - where n is the length of the input array
        public int[] SortedSquaredArray(int[] array)
        {
            int[] sortedSquares = new int[array.Length];
            for (int idx = 0; idx < array.Length; idx++)
            {
                int value = array[idx];
                sortedSquares[idx] = value * value;
            }
            Array.Sort(sortedSquares);
            return sortedSquares;
        }

    }
}
