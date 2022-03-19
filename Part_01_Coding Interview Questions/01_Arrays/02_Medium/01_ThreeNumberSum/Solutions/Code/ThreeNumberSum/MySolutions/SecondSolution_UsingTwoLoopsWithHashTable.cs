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
         * - Two Loops : N^2
         * - Total : O(N^2)
         * 
         * Space Complexity : O(2N)
         * Hash Set : N
         * Result : N
         * Total = O(2N) ~= O(N)
         */
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            List<int[]> result = new List<int[]>();
      
            if (array.Length >= 2)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    HashSet<int> HashSet = new HashSet<int>();

                    int firstNumber = array[i];

                    int currentSum = targetSum - array[i];

                    for (int j = i + 1; j < array.Length; j++)
                    {
         
                        int secondNumber = array[j];

                        int expectedThirdNumber =  currentSum- secondNumber;

                        bool isExpectedThirdNumberExist = HashSet.Contains(expectedThirdNumber);

                        if (isExpectedThirdNumberExist)
                        {
                            int[] threeNumbers = { firstNumber, secondNumber, expectedThirdNumber };
                            result.Add(threeNumbers);  
                        }
                        else
                        {
                            HashSet.Add(secondNumber);
                        }

                    }
                }
            }

            return result;
        }


        
    }
}
