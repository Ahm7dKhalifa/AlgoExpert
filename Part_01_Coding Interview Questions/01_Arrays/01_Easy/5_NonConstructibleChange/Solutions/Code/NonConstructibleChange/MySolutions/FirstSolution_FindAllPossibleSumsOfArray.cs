using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonConstructibleChange.MySolutions
{
    public class FirstSolution_FindAllPossibleSumsOfArray
    {
        /* algorithm analysis :
         * 
         * Time Complexity :
         * 1- FindAllPossibleSumsOfArray : o(t) = m = 2 power n     where n the size of array
         * 2- sort                       : o(t) = m log m           where m = 2 power n , n the size of array 
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
            HashSet<int> AllPossibleSums;
            public FindAllPossibleSumsOfArray()
            {
                AllPossibleSums = new HashSet<int>();
            }

            public HashSet<int> GetAsHashSet(int[] array)
            {
                FindAllPossibleSums( array, 0, 0);

                return AllPossibleSums;
            }


       
            public void FindAllPossibleSums( int[] array, int currentIndex , int sum = 0 )
            {
                //base case
                if (currentIndex == array.Length)
                {
                    AllPossibleSums.Add(sum);
                    return;
                }

                //include the element at current index
                FindAllPossibleSums(array, currentIndex + 1 , sum + array[currentIndex]);

                //does not include the element at current index
                FindAllPossibleSums(array, currentIndex + 1, sum);
            }

        }
        #endregion


    }


}
