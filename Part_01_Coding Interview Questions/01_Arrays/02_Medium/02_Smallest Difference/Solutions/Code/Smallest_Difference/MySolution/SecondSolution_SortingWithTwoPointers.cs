using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_Difference.AlgoExpertSolutions
{
    public class SecondSolution_SortingWithTwoPointers
    {
        /* Algorithm Analysis :
         * 
         * Time Complexity :
         * Sorting Firt Array : nlog(n) Where N is The Size Of Array One
         * Sorting Second Array : mlog(m) Where M is The Size Of Array Two
         * Loop : Smallest Value From ( N Or M) --> Assume It By N 
         * Total = O(nlog(n) +  mlog(m) + n ) ~= O(nlog(n) +  mlog(m))
         *  
         * Space Complexity : O(1) 
         * */
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            int IndexOfFirstArray = 0;
            int IndexOfSecondArray = 0;

            int SmallestDifference= Int32.MaxValue;
            
            int CurrentDifference = Int32.MaxValue;
            int[] SmallestPair = new int[2];

            while (IndexOfFirstArray < arrayOne.Length && IndexOfSecondArray < arrayTwo.Length)
            {
                int currentNumberOfArrayOne = arrayOne[IndexOfFirstArray];
                int currentNumberOfArrayTwo = arrayTwo[IndexOfSecondArray];
                
                if (currentNumberOfArrayOne < currentNumberOfArrayTwo)
                {
                    CurrentDifference = currentNumberOfArrayTwo - currentNumberOfArrayOne;
                    IndexOfFirstArray++;
                }
                else if (currentNumberOfArrayTwo < currentNumberOfArrayOne)
                {
                    CurrentDifference = currentNumberOfArrayOne - currentNumberOfArrayTwo;
                    IndexOfSecondArray++;
                }
                else
                {
                    return new int[] { currentNumberOfArrayOne, currentNumberOfArrayTwo };
                }

                if (SmallestDifference > CurrentDifference)
                {
                    SmallestDifference = CurrentDifference;
                    SmallestPair = new int[] { currentNumberOfArrayOne, currentNumberOfArrayTwo };
                }

            }

            return SmallestPair;

        }
    }
}
