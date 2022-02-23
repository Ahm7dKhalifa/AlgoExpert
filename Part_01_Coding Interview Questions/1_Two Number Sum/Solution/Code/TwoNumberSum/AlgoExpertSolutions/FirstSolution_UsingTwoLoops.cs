using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.AlgoExpertSolutions
{
    public class FirstSolution_UsingTwoLoops
    {
        // Copyright © 2022 AlgoExpert LLC. All rights reserved

        /* Algorithm Analysis
        * 
        * Time Complexity = O(N^2) 
        *      
        * Space Complexity = O(1) If the Problem Required To Return First Pair Only
        * Space Complexity = O(N) If the Problem Required To Return All Pairs 
        * */

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
