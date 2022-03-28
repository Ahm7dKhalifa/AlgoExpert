using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monotonic_Array.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved.
    public class FirstSolution_OneLoop
    {

        // O(n) time | O(1) space - where n is the length of the array
        public static bool IsMonotonic(int[] array)
        {
            if (array.Length <= 2) return true;
            var direction = array[1] - array[0];
            for (int i = 2; i < array.Length; i++)
            {
                if (direction == 0)
                {
                    direction = array[i] - array[i - 1];
                    continue;
                }
                if (breaksDirection(direction, array[i - 1], array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool breaksDirection(int direction, int previous, int current) 
        { 
            var difference = current - previous;
            if (direction > 0) return difference< 0;
            return difference > 0;
        }


    }
}
