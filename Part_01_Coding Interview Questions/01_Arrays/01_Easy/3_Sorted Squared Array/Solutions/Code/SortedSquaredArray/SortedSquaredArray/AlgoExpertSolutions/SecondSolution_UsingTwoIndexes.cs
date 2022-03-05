using System;
using System.Collections.Generic;
using System.Text;

namespace SortedSquaredArray.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved.
    public class SecondSolution_UsingTwoIndexes
    {
        // O(n) time | O(n) space - where n is the length of the input array
        public int[] SortedSquaredArray(int[] array)
        {
            int[] sortedSquares = new int[array.Length];
            int smallerValueIdx = 0;
            int largerValueIdx = array.Length - 1;
            for (int idx = array.Length - 1; idx >= 0; idx--)
            {
                int smallerValue = array[smallerValueIdx];
                int largerValue = array[largerValueIdx];
                if (Math.Abs(smallerValue) > Math.Abs(largerValue))
                {
                    sortedSquares[idx] = smallerValue * smallerValue;
                    smallerValueIdx++;
                }
                else
                {
                    sortedSquares[idx] = largerValue * largerValue;
                    largerValueIdx--;
                }
            }
            return sortedSquares;
        }


    }
}
