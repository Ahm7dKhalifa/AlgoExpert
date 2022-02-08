using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.MySolutions.FirstSolution
{
    public class FirstSolution_Correct
    {
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
                        int sumOfTwoNumber = firstNumber + secondNumber;
                        if (targetSum == sumOfTwoNumber)
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
