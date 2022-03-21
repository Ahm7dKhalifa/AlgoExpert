using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_Difference.AlgoExpertSolutions
{
    public class FirstSolution_TwoLoops
    {
        /* algorithm analysis :
         * 
         * Time Complexity :
         * Two Loops --> O(N*M) --> Where N Size Of Array One , M Size Of Array Two
         * 
         * 
         * Space Complexity :
         * O(1)
         * 
         * 
         * */
        
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {

            int[] SmallestPair = new int[2];
            int SmallestDifference = int.MaxValue;

            for (int i = 0; i < arrayOne.Length; i++)
            {
                int currentNumberOfArrayOne = arrayOne[i];
                int currentDifference = 0;
                
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    int currentNumberOfArrayTwo = arrayTwo[j];

                    if(currentNumberOfArrayTwo > currentNumberOfArrayOne)
                    {
                        currentDifference = Math.Abs(currentNumberOfArrayTwo - currentNumberOfArrayOne);
                    }
                    else if (currentNumberOfArrayOne > currentNumberOfArrayTwo)
                    {
                        currentDifference = Math.Abs(currentNumberOfArrayOne - currentNumberOfArrayTwo );
                    }
                    else if (currentNumberOfArrayOne == currentNumberOfArrayTwo)
                    {
                        SmallestPair[0] = currentNumberOfArrayOne;
                        SmallestPair[1] = currentNumberOfArrayTwo;

                        return SmallestPair;
                    }

                    if(SmallestDifference > currentDifference)
                    {
                        SmallestDifference = currentDifference;
                        SmallestPair[0] = currentNumberOfArrayOne;
                        SmallestPair[1] = currentNumberOfArrayTwo;
                    }
                }
            }


            return SmallestPair;
        }
    }
}
