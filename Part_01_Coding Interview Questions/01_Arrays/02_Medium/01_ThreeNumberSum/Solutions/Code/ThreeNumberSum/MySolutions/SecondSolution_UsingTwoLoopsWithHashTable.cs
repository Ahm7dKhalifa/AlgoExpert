using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeNumberSum.MySolutions
{
    public class SecondSolution_UsingTwoLoopsWithHashTable
    {
        /* algorithm analysis :
         * Time Complexity : 
         * - Convert Array To Hash Set = N
         * - Two Loops : N^2
         * - Total : O(N^2 + N) ~= O(N^2)
         * 
         * Space Complexity : O(2N)
         * Hash Set : N
         * Result : N
         * Total = O(2N) ~= O(N)
         */
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            int firstNumber;
            int secondNumber;
            int expectedThirdNumber;

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

            HashSet<int> HashSet = array.ToHashSet();
            if (array.Length >= 2)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    firstNumber = array[i];
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        secondNumber = array[j];

                        expectedThirdNumber = targetSum - (firstNumber + secondNumber);

                        bool isExpectedThirdNumberExist = HashSet.Contains(expectedThirdNumber) ;

                        if (isExpectedThirdNumberExist)
                        {
                            int[] threeNumbers = { firstNumber, secondNumber, expectedThirdNumber };
                            result.Add(threeNumbers);
                            break;
                        }

                    }
                }
            }


            return result;
        }
    }
}
