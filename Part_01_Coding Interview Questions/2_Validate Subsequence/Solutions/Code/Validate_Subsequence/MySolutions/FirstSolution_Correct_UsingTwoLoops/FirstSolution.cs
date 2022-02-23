using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validate_Subsequence.MySolutions
{
    public class FirstSolution_Correct_UsingTwoLoops
    {
        //algorithm analysis :
        // O(n^2) time | O(1) space - where n is the length of the array
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int StartPosition = 0;

            if(array != null && sequence != null)
            {
                if(array.Count < sequence.Count)
                {
                    return false;
                }

                for(int i = 0; i < sequence.Count; i++)
                {
                    
                    IsSubsequenceItemExistResult IsItemExistOnArrayResult = IsItemExistOnArray(sequence[i], array, StartPosition);
                    if (IsItemExistOnArrayResult.IsExist)
                    {
                        StartPosition = IsItemExistOnArrayResult.SubsequenceItemIndex + 1;

                    }
                    else
                    {
                        return false;
                    }
                    /*
                        var isCurrentItemIndexGreaterThanPreviosIndex = IsItemExistOnArrayResult.SubsequenceItemIndex >= i;
                        if (!isCurrentItemIndexGreaterThanPreviosIndex)
                        {
                            return false;
                        }
                   */
                }

                return true;
            }

            return false;
        }

        static IsSubsequenceItemExistResult IsItemExistOnArray(int item , List<int> array , int startPosition)
        {
            IsSubsequenceItemExistResult result = new IsSubsequenceItemExistResult();

            for(int i = startPosition; i < array.Count; i++)
            {
                if(array[i] == item)
                {
                    result.IsExist = true;
                    result.SubsequenceItemIndex = i;
                    break;
                }
            }
           
            return result;
        }

        public class IsSubsequenceItemExistResult
        {
            public bool IsExist = false;
            public int SubsequenceItemIndex = 0;
        }
    }
}
