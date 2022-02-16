using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.MySolutions.FirstSolution.Correct
{
    public class _1
    {
        /* algorithm analysis :
         * 1- time complexity :
         * two loops --> o(T) = n~2
         * 
         * 
         * 2- space complexity :
         * o(S) = n
         * worst case example :
         * array : [6,3,7,4,8,1,9,2]
         * target sum : 10
         * outPut = [6,4,3,7,8,2,9,1]
         * we need extra list to store outPut , the size of outPut will equal size of array 
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
