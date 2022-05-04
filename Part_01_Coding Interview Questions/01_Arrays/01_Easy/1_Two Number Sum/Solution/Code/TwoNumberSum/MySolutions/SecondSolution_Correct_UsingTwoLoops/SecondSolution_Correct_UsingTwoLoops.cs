using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.MySolutions
{
    public class SecondSolution_Correct_UsingTwoLoops
    {

        /* algorithm analysis :
         * 
         * 1- time complexity :
         * two loops --> O(t) = n^2
         * where n is the size of array
         * 
         * 2- space complexity :
         * based on the requirement of the problem
         * O(s) = n when we need to find all pairs of sums
         * O(s) = 1 when we need to find first pair of sums
         * where n is the size of array
         * 
         */
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {

            List<int> outPut = new List<int>();

            if (array != null && array.Length > 1)
            {
                for (int i = 0; i < array.Length -1; i++)
                {
                    int firstNumber = array[i];

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        int secondNumber = array[j];
                        int currentSum = firstNumber + secondNumber;
                        if (targetSum == currentSum)
                        {
                            outPut.Add(firstNumber);
                            outPut.Add(secondNumber);
                            break;
                        }
                    }
                }
            }

            return outPut.ToArray();
        }
    }
}
