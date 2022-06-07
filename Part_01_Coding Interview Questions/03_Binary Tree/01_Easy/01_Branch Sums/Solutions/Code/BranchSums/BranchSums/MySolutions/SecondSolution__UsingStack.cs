using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchSums.MySolutions
{
    public class SecondSolution
    {

        #region Algorithm Analysis
        /*
         * Time Complexity : 
         * - O(N)
         * 
         * Space Complexity :
         * TotalSumsOfAllBranchesList = O(N)
         * StackNodes =  O(N)
         * Total Space Complexity = O(2N) ~= O(N)
         * 
         */
        #endregion
        #region Algorithm Implementation
        public static List<int> BranchSums(BinaryTree root)
        {
            List<int> TotalSumsOfAllBranchesList = new List<int>();
            Stack<BinaryTree> StackNodes = new Stack<BinaryTree>();


            if (root != null)
            {
                StackNodes.Push(root);
                

                while(StackNodes.Count() > 0)
                {
                    var currentNode = StackNodes.Pop();

                    if (currentNode == null)
                        continue;

                    currentNode.CurrentTotalSum = currentNode.CurrentTotalSum + currentNode.value;

                    if (IsLeafNode(currentNode))
                    {
                        TotalSumsOfAllBranchesList.Add(currentNode.CurrentTotalSum);
                        continue;
                    }

                    if (currentNode.right != null)
                    {
                        currentNode.right.CurrentTotalSum = currentNode.CurrentTotalSum;
                        StackNodes.Push(currentNode.right);
                    }

                    if (currentNode.left != null)
                    {
                        currentNode.left.CurrentTotalSum = currentNode.CurrentTotalSum;
                        StackNodes.Push(currentNode.left);
                    }

                  

                }

            }

            return TotalSumsOfAllBranchesList;
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
            public int CurrentTotalSum;
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
