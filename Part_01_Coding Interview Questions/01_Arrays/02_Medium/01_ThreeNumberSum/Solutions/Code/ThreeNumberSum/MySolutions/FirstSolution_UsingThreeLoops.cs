using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeNumberSum.MySolutions
{
    public class FirstSolution_UsingThreeLoops
    {
        /* algorithm analysis :
         * Time Complexity : O(N3)   ---> Three Loops
         * Space Complexity : O(N)
         */
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            int firstNumber;
            int secondNumber;
            int thirdNumber;
            int currentSum;
            List<int[]> result = new List<int[]>();

            //this Sorting step in current Solution is not required to solve the problem 
            //but required to pass automation tests case only
            //ex : same numbers with different orders causes problem :
            //expected :
            //[
            //[-8, 2, 6],
            //[-8, 3, 5],
            // [-6, 1, 5]
            //]
            //actual :
            //[
            //[3, 5, -8],
            //[1, -6, 5],
            //[2, -8, 6]
            //]
            Array.Sort(array);

            if (array.Length >= 2)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    firstNumber = array[i];
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        secondNumber = array[j];
                        for (int k = j + 1; k < array.Length; k++)
                        {
                            thirdNumber = array[k];

                            currentSum = firstNumber + secondNumber + thirdNumber;

                            if (currentSum == targetSum)
                            {
                                int[] threeNumbers = { firstNumber, secondNumber, thirdNumber };
                                result.Add(threeNumbers);
                                break;
                            }
                        }
                    }
                }
            }


            return result;
        }
    }
}
