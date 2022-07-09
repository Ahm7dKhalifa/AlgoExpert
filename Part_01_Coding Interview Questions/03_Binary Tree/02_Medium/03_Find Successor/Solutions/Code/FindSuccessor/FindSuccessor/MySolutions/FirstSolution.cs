using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSuccessor.MySolutions
{
    public class FirstSolution
    {
        #region Algorithm Design
        /*

           1- Convert Tree To List By InOrder Traverse
           2- Find Successor From List Of Nodes

        */
        #endregion

        #region Algorithm Analysis
        /*
           **********************************
           * Time Complexity
           **********************************
           1- Convert Tree To List By InOrder Traverse --> O(N)
           2- Find Successor From List Of Nodes --> O(N)

           Total Time = O(N) + O(N) = 2O(N) 
           
           **********************************
           * Space Complexity
           **********************************
           O(H) --> Height Of Tree (Frames In Recursion)
           O(N) --> List Of All Nodes

           Total Space = O(H) + O(N) 

           
           *****************************************
           * In My Second Solution : 
           * ***************************************
           We Will See Another Solution 
           That Optimaize Time And Space Than Current Solution


           
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
            public List<BinaryTree> AllNodes = new List<BinaryTree>();
        }


        public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
        {
            FindSuccessorInfo FindSuccessorInfo = new FindSuccessorInfo();
            FindSuccessorInfo.TargetNode = node;
            
            ConvertTreeToListByInOrderTraverse(tree,FindSuccessorInfo);
            FindSuccessorFromListOfNodes(FindSuccessorInfo);

            return FindSuccessorInfo.SuccessorNode;
        }

        public void ConvertTreeToListByInOrderTraverse(BinaryTree CurrentNode , FindSuccessorInfo Info)
        {
            //Base Case 1 :
            if (CurrentNode is null)
                return;

            //Recursion Case 1 
            ConvertTreeToListByInOrderTraverse(CurrentNode.left, Info);

            //Business Logic
            Info.AllNodes.Add(CurrentNode);

            //Recursion Case 2
            ConvertTreeToListByInOrderTraverse(CurrentNode.right, Info);

        }

        public void FindSuccessorFromListOfNodes(FindSuccessorInfo info)
        {
            foreach(var node in info.AllNodes)
            {
                if (info.IsTargetNodeFound)
                {
                    info.SuccessorNode = node;
                    break;
                }
                    

                if (node.value == info.TargetNode.value)
                    info.IsTargetNodeFound = true;
      
            }

        }
        #endregion
    }

}
