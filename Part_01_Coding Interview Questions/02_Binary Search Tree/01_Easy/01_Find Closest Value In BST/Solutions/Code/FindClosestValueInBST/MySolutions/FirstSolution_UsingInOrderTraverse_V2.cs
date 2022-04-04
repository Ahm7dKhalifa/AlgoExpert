using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST.MySolutions
{
    public class FirstSolution_UsingInOrderTraverse_V2
    {
        #region Algorithm Design
        /*
         * 1. Traverse Binary Search Tree InOrder To Get It As Sorted List
         * 
         * 2. Loop On Sorted List
         * 
         *    2.1 If Current Value = Tareget
         *           Return Target
         *           
         *    2.2 If Current Value > Target 
         *           If Current Node Has Previous Node
         *              DF1 = Calculate Difference Betweeen Target And Previous Node
         *              DF2 = Calculate Difference Betweeen Current Node And Target
         *              if DF1 >= DF2  
         *                 Return Previos Node Value
         *              else 
         *                 Return Current Node Value
         *            else 
         *                 Return Current Node Value  
         * 
         */
        #endregion

        #region Algorithm Analysis
        /*
         * Time Complexity : 
         * Traverse Binary Search Tree : O(N)
         * Traverse Binary Search Tree : O(N)
         * Total = O(2N) ~= O(N)
         * 
         * 
         * Space Complexity = O(N) --> Sorted List
         * 
         */
        #endregion

        #region Algorithm Implementation
        public static int FindClosestValueInBst(BST BST, int target)
        {
          
            BinarySearchTree BinarySearchTree = new BinarySearchTree();

            List<BST> BinarySearchTreeAsList = new List<BST>();

            BinarySearchTree.InOrderTraverse(BST, BinarySearchTreeAsList);

            for (int i = 0; i < BinarySearchTreeAsList.Count; i++)
            {
                var CurrentNode = BinarySearchTreeAsList[i];
                if (CurrentNode.value == target)
                {
                    return CurrentNode.value;
                }
                else if (CurrentNode.value > target)
                {
                    var PreviosNodeIndex = i - 1;

                    if (PreviosNodeIndex >= 0)
                    {
                        var PreviosNode = BinarySearchTreeAsList[PreviosNodeIndex];
                        if (target - PreviosNode.value < CurrentNode.value - target)
                        {
                            return PreviosNode.value;
                        }
                        else
                        {
                            return CurrentNode.value;
                        }
                    }
                    else
                    {
                        return CurrentNode.value;
                    }

                }
            }

            return -1;
           
        }

        public class BinarySearchTree
        {
            BST Root;


            public void InOrderTraverse(BST Node , List<BST> Result)
            {
                if (Node == null)
                    return;

                InOrderTraverse(Node.left , Result);

                Result.Add(Node);

                InOrderTraverse(Node.right , Result);
            }



        }

        //BST Is Not Binary Search Tree But BST Is Just Binary Search Tree Node
        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }

        #endregion

    }
}
