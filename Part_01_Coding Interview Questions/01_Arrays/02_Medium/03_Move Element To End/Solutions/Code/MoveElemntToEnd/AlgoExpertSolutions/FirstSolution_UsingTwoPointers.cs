using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveElemntToEnd.AlgoExpertSolutions
{
    public class FirstSolution_UsingTwoPointers
    {
        // O(n) time | O(1) space - where n is the length of the array
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            int i = 0;
            int j = array.Count - 1;
            while (i < j)
            {
                while (i < j && array[j] == toMove) j--;
                if (array[i] == toMove) Swap(i, j, array);
                i++;
            }
            return array;
        }
        public static void Swap(int i, int j, List<int> array)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
