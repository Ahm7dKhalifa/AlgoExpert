using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveElemntToEnd.MySolutions
{
    public class FirstSolution_UsingTwoPointers
    {
        /* Algorithm Analysis :
         * 
         * Time Complexity : O(n) Where N Is The Size Of Array
         * Space Complexity : O(1) 
         *
         */
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {

            int NumberToMove = toMove;

            int LeftIndex = 0;
            int RightIndex = array.Count - 1;

            while (LeftIndex < RightIndex)
            {
                int CurrentElementAtRight = array[RightIndex];
                int CurrentElementAtLeft = array[LeftIndex];

                while (CurrentElementAtRight == NumberToMove && RightIndex != 0)
                {
                    RightIndex--;
                    CurrentElementAtRight = array[RightIndex];
                }

                while (CurrentElementAtLeft != NumberToMove && LeftIndex < array.Count - 1)
                {
                    LeftIndex++;
                    CurrentElementAtLeft = array[LeftIndex];
                }

                if (LeftIndex < RightIndex && CurrentElementAtLeft == NumberToMove && CurrentElementAtRight != NumberToMove)
                {
                    int temp = array[RightIndex];
                    array[RightIndex] = array[LeftIndex];
                    array[LeftIndex] = temp;

                    RightIndex--;
                    LeftIndex++;
                }
          
            }

            return array;
        }
    }
}
