using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoNumberSum.MySolutions
{
    public class ThirdSolution_Correct_CopyArrayToHashTableThenLoopOnlyOnce
    {
        /* Algorithm Analysis
         * 
         * Time Complexity = O(2N) ~= O(N)
         * Create Dictionary From Array = N
         * Looping Through Dictionary To Add Numbers = N
         * 
         * Space Complexity = O(2N) ~= O(N) 
         * Dictionary = N
         * Output List = N
         * 
         * Can Get More Smart Solution ?
         * See Second Solution On AlgoExpert Folder That Cost Only Time Complexity = O(N) and Space Complexity = O(N)
         * 
         * */


        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            List<int> outPut = new List<int>();

            Dictionary<int, int> Dictionary = CreateDictionaryFromArray(array, targetSum);

            foreach(var item in Dictionary)
            {
                int firstNumber = item.Key;
                int secondNumber = item.Value;
                bool isSecondNumberExistAsKey = Dictionary.ContainsKey(secondNumber);
                if (isSecondNumberExistAsKey && item.Key != item.Value)
                {
                    outPut.Add(firstNumber);
                }
            }

            return outPut.ToArray();
        }


        private static Dictionary<int, int> CreateDictionaryFromArray(int[] array, int targetSum)
        {
            Dictionary<int, int> Dictionary = new Dictionary<int, int>();

            foreach (int number in array)
            {
                int firstNumber = number;
                int secondNumber = targetSum - firstNumber;
                Dictionary.Add(firstNumber, secondNumber);
            }

            return Dictionary;
        }


    }
}
