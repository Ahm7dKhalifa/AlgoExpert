using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonConstructibleChange.AlgoExpertSolutions
{
    public class FirstSolution_UsingOneLoop
    {
        // O(nlogn) time | O(1) space - where n is the number of coins
        public int NonConstructibleChange(int[] coins)
        {
            Array.Sort(coins);
            int currentChangeCreated = 0;
            foreach (var coin in coins)
            {
                if (coin > currentChangeCreated + 1)
                {
                    return currentChangeCreated + 1;
                }
                currentChangeCreated += coin;
            }
            return currentChangeCreated + 1;
        }

    }

}



