using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.MySolutions._1
{
    public class FirstSolution
    {
        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array == null || array.Length == 0)
                return 0;
            else if (array.Length == 1)
                return array[0];

            int[] MaxSums = (int[])array.Clone();
            MaxSums[1] = Math.Max(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                MaxSums[i] = Math.Max(MaxSums[i - 1], MaxSums[i - 2] + array[i]);
            }

            return MaxSums[array.Length - 1];
        }
    }
}
