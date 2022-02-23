using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNumberSum.AlgoExpertSolutions
{
    public class SecondSolution_UsingHashTableDirectly
    {
        // Copyright © 2022 AlgoExpert LLC. All rights reserved

        /* Algorithm Analysis
        * 
        * Time Complexity = O(N)
        * 
        * 
        * Space Complexity = O(1) If the Problem Required To Return First Pair Only
        * Space Complexity = O(N) If the Problem Required To Return All Pairs 
        * 
        * */
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
