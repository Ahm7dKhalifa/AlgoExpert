using System;
using System.Collections.Generic;
using System.Text;

namespace SortedSquaredArray.MySolutions
{
    public class FirstSolution_LoopThenSort
    {
        /* Algorithm Analysis :
         * 
         * Time Complexity = 
         * Loop  = n
         * Sort  = n log n
         * O(t)  = n + n log n ---> n log n
         * 
         * Space Complexity : 
         * based on the requirement of the problem
         * O(s) = n when we create new array -> SequradArray
         * O(s) = 1 when we use same array directly
         * */
        public int[] SortedSquaredArray(int[] array)
        {
            int[] SequradArray = null;
            
            if (array != null)
            {
                SequradArray = new int[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    SequradArray[i] = array[i] * array[i];
                }

                Array.Sort(SequradArray);
            }
           
            return SequradArray;
        }

        /*
        public int[] SortedSquaredArray(int[] array)
        {
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i] * array[i];
                }

                Array.Sort(array);
            }

            return SequradArray;
        }
        */
    }
}
