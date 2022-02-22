using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.AlgoExpertSolutions
{
    public class ThirdSolution
    {
        // Copyright © 2022 AlgoExpert LLC. All rights reserved
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                int currentSum = array[left] + array[right];
                if (currentSum == targetSum)
                {
                    return new int[] { array[left], array[right] };
                }
                else if (currentSum < targetSum)
                {
                    left++;
                }
                else if (currentSum > targetSum)
                {
                    right--;
                }
            }
            return new int[0];
        }

    }
}
