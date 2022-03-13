using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonConstructibleChange.MySolutions
{
    public class FirstSolution_UsingDictionary
    {
        /* algorithm analysis :
         * 
         * Time Complexity :
         * 1- FindAllPossibleSumsOfArray : o(t) = m = 2 power n     where n the size of array
         * 2- sort                       : o(t) = m = n log n       where n the size of array
         * 3- loop                       : o(t) = m = 2 power n     where n the size of array
         * 
         * Space Complexity :
         * HashSet : o(s) = m = 2 power n     where n the size of array
         */
        public int NonConstructibleChange(int[] coins)
        {
            if (IsArrayHasNotAnyCoins(coins))
                return 1;
               
            FindAllPossibleSumsOfArray FindAllPossibleSumsOfArray = new FindAllPossibleSumsOfArray();
            HashSet<int> AllPossibleSumsOfArray = FindAllPossibleSumsOfArray.GetAsHashSet(coins);

            AllPossibleSumsOfArray = AllPossibleSumsOfArray.OrderBy( key => key).ToHashSet();


            for (int i = 1; i <= AllPossibleSumsOfArray.Last(); i++)
            {
                int currentNumber = i;

                bool isNumberExist = AllPossibleSumsOfArray.Contains(currentNumber);

                if (!isNumberExist)
                    return currentNumber;


            }

            return AllPossibleSumsOfArray.Last() + 1;


        }

        #region IsArrayHasNotAnyCoins
        private bool IsArrayHasNotAnyCoins(int[] coins)
        {
            return coins != null && coins.Length == 0;
        }
        #endregion


        #region FindAllPossibleSumsOfArray
        public class FindAllPossibleSumsOfArray
        {
            public HashSet<int> GetAsHashSet(int[] array)
            {
                HashSet<int> AllPossibleSums = new HashSet<int>();

                FindAllPossibleSums(array, 0, AllPossibleSums);

                return AllPossibleSums;
            }


            public void FindAllPossibleSums(int[] array, int startIndex, HashSet<int> AllPossibleSums)
            {
                //base case
                if (startIndex == array.Length - 1)
                {
                    return;
                }


                int currentElement = array[startIndex];
                AllPossibleSums.Add(currentElement);

                int totalSum = 0;


                for (int i = startIndex; i < array.Length - 1; i++)
                {
                    int nextElement = array[i + 1];
                    AllPossibleSums.Add(nextElement);

                    int currentSum = currentElement + nextElement;
                    AllPossibleSums.Add(currentSum);

                    totalSum += currentSum;
                    AllPossibleSums.Add(totalSum);
                }

                FindAllPossibleSums(array, startIndex + 1, AllPossibleSums);
            }

        }
        #endregion


    }


}
