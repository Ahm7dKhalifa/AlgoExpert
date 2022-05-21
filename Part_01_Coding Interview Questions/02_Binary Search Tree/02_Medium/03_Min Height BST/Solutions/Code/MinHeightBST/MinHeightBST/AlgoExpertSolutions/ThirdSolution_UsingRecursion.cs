using System;
using System.Collections.Generic;
using System.Text;

namespace MinHeightBST.AlgoExpertSolutions
{
    public class ThirdSolution_UsingRecursion
    {
        // O(n) time | O(n) space - where n is the length of the array
        public static BST MinHeightBst(List<int> array)
        {
            return constructMinHeightBst(array, 0, array.Count - 1);
        }
        public static BST constructMinHeightBst(List<int> array, int startIdx, int endIdx)
        {
            if (endIdx < startIdx) return null;
            int midIdx = (startIdx + endIdx) / 2;
            BST bst = new BST(array[midIdx]);
            bst.left = constructMinHeightBst(array, startIdx, midIdx - 1);
            bst.right = constructMinHeightBst(array, midIdx + 1, endIdx);
            return bst;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }

            public void insert(int value)
            {
                if (value < this.value)
                {
                    if (left == null)
                    {
                        left = new BST(value);
                    }
                    else
                    {
                        left.insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new BST(value);
                    }
                    else
                    {
                        right.insert(value);
                    }
                }
            }
        }
    }
}
