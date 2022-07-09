using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSuccessor.MySolutions
{
    public class SecondSolution
    {
        #region Algorithm Design
        /*
            //Base Case 1 :
            if (CurrentNode is null)
                return;

            //Base Case 2 : 
            if (Info.IsTargetNodeFound)
            {
                Info.SuccessorNode = CurrentNode;
                return;
            }
           
            //Recursion Case 1 
            InOrderTraverse(CurrentNode.left, Info);

            //Business Logic
            if (CurrentNode.value == Info.TargetNode.value)
            {
                Info.IsTargetNodeFound = true;
            }

            //Recursion Case 2
            InOrderTraverse(CurrentNode.right, Info);

         */
        #endregion

        #region Algorithm Analysis
        /*
         ***********************************************
         * Time Complexity
         ***********************************************
            //Base Case 1 :
            if (CurrentNode is null) --> O(1)
                return;

            //Base Case 2 : 
            if (Info.IsTargetNodeFound) --> O(1)
            {
                Info.SuccessorNode = CurrentNode;
                return;
            }
           
            //Recursion Case 1 
            InOrderTraverse(CurrentNode.left, Info); --> O(T(N/2))

            //Business Logic
            if (CurrentNode.value == Info.TargetNode.value) --> O(1)
            {
                Info.IsTargetNodeFound = true;
            }

            //Recursion Case 2
            InOrderTraverse(CurrentNode.right, Info); --> O(T(N/2))

            Total Time = O(1) + O(1) + O(T(N/2)) + O(1) + O(T(N/2))
                       = 2*O(T(N/2)) + O(3)
                       = O(N) + C
                       = N

            ***********************************************
            * Space Complexity = O(H)
            ***********************************************
            H is The Height Of The Tree 
            H = O(Log N) When Tree IsBalanced
            H = N When Tree Is Skewed 
         */
        #endregion

        #region Algorithm Implementation
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;
            public BinaryTree parent = null;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }

        public class FindSuccessorInfo
        {
            public BinaryTree TargetNode = null;
            public BinaryTree SuccessorNode = null;
            public bool IsTargetNodeFound = false;
            public bool IsSuccessorNodeFound = false;

        }


        public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
        {
            FindSuccessorInfo FindSuccessorInfo = new FindSuccessorInfo();
            FindSuccessorInfo.TargetNode = node;
            InOrderTraverse(tree,FindSuccessorInfo);
            return FindSuccessorInfo.SuccessorNode;
        }

        public void InOrderTraverse(BinaryTree CurrentNode , FindSuccessorInfo Info)
        {
            //Base Case 1 :
            if (CurrentNode is null)
                return;

            //Recursion Case 1 
            InOrderTraverse(CurrentNode.left, Info);

            //Base Case 2 : 
            if (Info.IsTargetNodeFound && !Info.IsSuccessorNodeFound)
            {
                Info.SuccessorNode = CurrentNode;
                Info.IsSuccessorNodeFound = true;
                return;
            }

            //Business Logic
            if (CurrentNode.value == Info.TargetNode.value)
            {
                Info.IsTargetNodeFound = true;
            }

            //Recursion Case 2
            InOrderTraverse(CurrentNode.right, Info);

        }

        #endregion
    }

}
