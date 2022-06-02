using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchSums.MySolutions
{
    public class FirstSolution
    {
        #region Algorithm Design
        /*
         * - BranchSumsHelper(sumList , currentNode , currentBranchTotalSum)
         * Base Case
         * 1- If currentNode == null
         *    add currentBranchTotalSum To SumList
         *    currentBranchTotalSum = 0
         * 
         * currentBranchTotalSum += currentNode
         * 
         * BranchSumsHelper(sumList , currentNode.Left , currentBranchTotalSum)
         * BranchSumsHelper(sumList , currentNode.Right , currentBranchTotalSum)
         * 
         */
        #endregion
        #region Algorithm Analysis
        /*
         * - BranchSumsHelper(sumList , currentNode , currentBranchTotalSum)
         * 1- If currentNode == null
         *    add currentBranchTotalSum To SumList
         *    currentBranchTotalSum = 0
         * 
         * currentBranchTotalSum += currentNode
         * 
         * BranchSumsHelper(sumList , currentNode.Left , currentBranchTotalSum)
         * BranchSumsHelper(sumList , currentNode.Right , currentBranchTotalSum)
         * 
         */
        #endregion
        #region Algorithm Implementation
        public static List<int> BranchSums(BinaryTree root)
        {
            List<int> TotalSumsOfAllBranchesList = new List<int>();
            BranchSumsHelper(root, TotalSumsOfAllBranchesList, 0);
            return TotalSumsOfAllBranchesList;
        }

        public static void BranchSumsHelper(BinaryTree currentNode , List<int> TotalSumsOfAllBranchesList , int currentTotalBranchSum)
        {
            //base case 1
            if (currentNode  == null )
            { 
                return;
            }

            currentTotalBranchSum += currentNode.value;

            //base case 2 
            if (IsLeafNode(currentNode))
            {
                TotalSumsOfAllBranchesList.Add(currentTotalBranchSum);
                return;
            }

           

            BranchSumsHelper(currentNode.left , TotalSumsOfAllBranchesList, currentTotalBranchSum);
            BranchSumsHelper(currentNode.right, TotalSumsOfAllBranchesList, currentTotalBranchSum);


        }

        public static bool IsLeafNode(BinaryTree currentNode)
        {
            return currentNode.left == null && currentNode.right == null;
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }

      
        #endregion

    }
}
