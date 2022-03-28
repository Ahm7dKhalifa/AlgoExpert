using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monotonic_Array.MySolutions
{
    public class FirstSolution_OneLoop
    {
        #region Algorithm Design Steps 
        //if array has less than 3 element 
        //     return true;

        //find type of monotonic order
        //  loop on array 
        //        if current element less than next element
        //           return increasing type 
        //        else if current element greater than next element
        //             return decreasing type 
        //         else if current element equal next element
        //             increment startIndex
        //             --> this step for more optimaiztion when array start with equal elements like [2,2,2,2,3,4,5]
        // 
        //  return all array elements is equal
        //  

        //if type of monotonic order = increasing type 
        //   check is array has increasing monotonic order
        //if type of monotonic order = decreasing type   
        //   check is array has decreasing monotonic order
        //
        #endregion

        #region Algorithm Analysis
        /*
         * Time Complexity : 
         * 
         * IsArrayHasLessThanThreeElement = O(1)
         * FindTheTypeOfMonotonicOrder = O(N)
         * CheckIsArrayHasMonotonicOrder = O(N)
         * 
         * Total = O(1) + O(N) +  O(N) = O(2N) + O(1) ~= O(N) 
         * Space Complexity = O(1)
         * 
         */
        #endregion

        #region Algorithm Implementation
        public static bool IsMonotonic(int[] array)
        {
            if (IsArrayHasLessThanThreeElement(array))
                return true;

            MonotonicOrderTypeResult MonotonicOrderTypeResult = FindTheTypeOfMonotonicOrder(array);

            if (MonotonicOrderTypeResult.MonotonicOrderType == MonotonicOrderType.Increasing)
            {
                return CheckIsArrayHasIncreasingMonotonicOrder(array, MonotonicOrderTypeResult.StartIndex);
            }
            else if (MonotonicOrderTypeResult.MonotonicOrderType == MonotonicOrderType.Decreasing)
            {
                return CheckIsArrayHasDecreasingMonotonicOrder(array, MonotonicOrderTypeResult.StartIndex);
            }
            else if (MonotonicOrderTypeResult.MonotonicOrderType == MonotonicOrderType.AllArrayElementsAreEqual)
            {
                return true;
            }

            return false;
        }

        private static bool IsArrayHasLessThanThreeElement(int[] array)
        {
            return array != null && array.Length < 2;
        }

        private static MonotonicOrderTypeResult FindTheTypeOfMonotonicOrder(int[] array)
        {
            MonotonicOrderTypeResult Result = new MonotonicOrderTypeResult();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int currentElement = array[i];
                int nextElement = array[i + 1];

                if (currentElement < nextElement)
                {
                    Result.MonotonicOrderType = MonotonicOrderType.Increasing;
                    return Result;
                }
                else if (currentElement > nextElement)
                {
                    Result.MonotonicOrderType = MonotonicOrderType.Decreasing;
                    return Result;
                }
                else
                {
                    Result.StartIndex++;
                }
            }

            Result.MonotonicOrderType = MonotonicOrderType.AllArrayElementsAreEqual;
            return Result;
        }

        private static bool CheckIsArrayHasIncreasingMonotonicOrder(int[] array, int startIndex)
        {
            for (int i = startIndex; i < array.Length - 1; i++)
            {
                int currentElement = array[i];
                int nextElement = array[i + 1];

                if (currentElement > nextElement)
                {
                    return false;
                }

            }

            return true;
        }

        private static bool CheckIsArrayHasDecreasingMonotonicOrder(int[] array, int startIndex)
        {
            for (int i = startIndex; i < array.Length - 1; i++)
            {
                int currentElement = array[i];
                int nextElement = array[i + 1];

                if (currentElement < nextElement)
                {
                    return false;
                }

            }

            return true;
        }

        public static class MonotonicOrderType
        {
            public static int Increasing = 1;
            public static int Decreasing = 2;
            public static int AllArrayElementsAreEqual = 3;
        }

        public class MonotonicOrderTypeResult
        {
            public int MonotonicOrderType;
            public int StartIndex;
        }
        #endregion

    }
}
