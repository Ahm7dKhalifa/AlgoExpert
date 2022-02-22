using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoNumberSum.MySolutions.SecondSolution
{
    public class SecondSolution_Bad_01
    {
        /* Why This Is Bad Soluation ?
         * Because The Time Complexity = O(2N)
         * Create Dictionary From Array = N
         * Looping Through Dictionary To Add Numbers = N
         * 
         * We Can Get More Smart Solution That Cost Only = O(N)
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
