using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.AlgoExpertSolutions
{
    public class SecondSolution
    {
        // Copyright © 2022 AlgoExpert LLC. All rights reserved
        public static int[] TwoNumberSum(int[] array, int targetSum)
        { 

            HashSet<int> nums = new HashSet<int>();
            
            foreach (int num in array)
            {
                int potentialMatch = targetSum - num;
                if (nums.Contains(potentialMatch)) 
                {
                    return new int[] { potentialMatch, num };
                }
                else
                {
                    nums.Add(num);
                }
            }
                   
            return new int[0];
        }

    }
}
