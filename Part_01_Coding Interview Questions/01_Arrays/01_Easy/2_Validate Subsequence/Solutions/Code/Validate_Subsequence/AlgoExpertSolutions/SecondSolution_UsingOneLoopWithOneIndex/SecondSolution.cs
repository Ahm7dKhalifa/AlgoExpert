using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validate_Subsequence.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved
    public class SecondSolution_UsingOneLoopWithOneIndex
    {
        //algorithm analysis :
        // O(n) time | O(1) space - where n is the length of the array
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {

            int seqIdx = 0;
            foreach (var val in array)
            {
                if (seqIdx == sequence.Count)
                {
                    break;
                }
                if (sequence[seqIdx] == val)
                {
                    seqIdx++;
                }
            }
            return seqIdx == sequence.Count;
        }

    }
}
