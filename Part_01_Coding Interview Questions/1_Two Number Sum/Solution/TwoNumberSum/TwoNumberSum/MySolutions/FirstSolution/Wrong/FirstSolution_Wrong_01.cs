using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.MySolutions.FirstSolution
{
    public class FirstSolution_Wrong_01
    {
        /*wrong reasons :
            test case 1 :
                target sum : 10
                array : [3, 5, -4, 8, 11, 1, -1, 6]
                excepted output : [11,-1]
                actual output   : [11,-1,0,0,0,0,0,0]
        */

        /*bad practices :
          1- no need to use the flag : isFirstNumberAddeddToOutPutArray because every pair of number is unique
          2- no need to continue in the second loop after targetSum = sumOfTwoNumber , we must back to the first loop
       */
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            int[] outPut = new int[0];
            int indexOfOutPutArray = 0;

            if (array != null && array.Length > 1)
            {
                outPut = new int[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    int firstNumber = array[i];
                    bool isFirstNumberAddeddToOutPutArray = false;

                    for (int j = 1; i < array.Length; j++)
                    {
                        int secondNumber = array[j];
                        int sumOfTwoNumber = firstNumber + secondNumber;
                        if (targetSum == sumOfTwoNumber)
                        {
                            if (!isFirstNumberAddeddToOutPutArray)
                            {
                                outPut[indexOfOutPutArray] = firstNumber;
                                indexOfOutPutArray++;
                                isFirstNumberAddeddToOutPutArray = true;
                            }
                            outPut[indexOfOutPutArray] = secondNumber;
                            indexOfOutPutArray++;
                        }
                    }
                }
            }

            return outPut;
        }
    }
}
