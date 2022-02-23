using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validate_Subsequence.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved
    public class FirstSolution_UsingOneLoopWithTwoIndexes
    {
        //algorithm analysis :
        // O(n) time | O(1) space - where n is the length of the array
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        { 
       
            int arrIdx = 0;
            int seqIdx = 0;
            while ( arrIdx < array.Count && seqIdx < sequence.Count)
            {
                if (array[arrIdx] == sequence[seqIdx])
                {
                    seqIdx++;
                }
                arrIdx++;
            }

            return seqIdx == sequence.Count;
        }

    }
}
