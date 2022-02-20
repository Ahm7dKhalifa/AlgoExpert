using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.AlgoExpertSolutions
{
    public class FirstSolution
    {
        // Copyright © 2022 AlgoExpert LLC. All rights reserved
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int firstNum = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int secondNum = array[j];
                    if (firstNum + secondNum == targetSum)
                    {
                        return new int[] { firstNum, secondNum };
                    }
                }
            }

            return new int[0];
        
        }

    }
}
