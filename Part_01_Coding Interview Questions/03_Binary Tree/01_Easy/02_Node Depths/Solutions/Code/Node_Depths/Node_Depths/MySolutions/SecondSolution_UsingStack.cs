using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Depths.MySolutions
{
    public class SecondSolution_UsingStack
	{
		#region Algorithm Design
		/* 1- Define Variable To Store TotalSumOfDepths
         * 2- Define And Create Nodes Stack List
         * 3- if Root Node is Not Null
         *       3.1 Push Root Node To Stack
         *       3.2 While Stack Is Not Empty
         *                1.Define Variable Called Current Node 
         *                2.Pop Last Node From Stack And Store it in Current Node Variable
         *                3.Increment TotalSumOfDepths By Current Node Depth
         *                4.If Left Node Of Current Node  != Null
         *                     4.1 Set Depth Of Left Node  = Current Node Depth + 1
         *                     4.2 Push Left Node To Stack
         *                5.If Right Node Of Current Node  != Null
         *                     5.1 Set Depth Of Right Node  = Current Node Depth + 1
         *                     5.2 Push Right Node To Stack
         * 
         * 4- return TotalSumOfDepths
         * 
         */
		#endregion
		#region Algorithm Analysis
		/*
         * Time Complexity : 
         * - O(N)
         * 
         * Space Complexity :
         * StackNodes =  O(N)
         * Total Space Complexity = O(N)
         * 
         */
		#endregion
		#region Algorithm Implementation
		public static int NodeDepths(BinaryTree root)
		{
			int TotalSumOfDepths = 0;
			Stack<BinaryTree> NodesStack = new Stack<BinaryTree>();
			if(root != null)
            {
				NodesStack.Push(root);
				while(NodesStack.Count > 0)
                {
					BinaryTree CurrentNode = NodesStack.Pop();
					TotalSumOfDepths += CurrentNode.Depth;
					AddChildNodeToStack(CurrentNode.left, CurrentNode, NodesStack);
					AddChildNodeToStack(CurrentNode.right, CurrentNode, NodesStack);
					/*
					if(CurrentNode.left != null)
                    {
						CurrentNode.left.Depth = CurrentNode.Depth + 1;
						NodesStack.Push(CurrentNode.left);
					}
					if (CurrentNode.right != null)
					{
						CurrentNode.right.Depth = CurrentNode.Depth + 1;
						NodesStack.Push(CurrentNode.right);
					}
					*/


				}

			}
			return TotalSumOfDepths;
		}

		public static void AddChildNodeToStack(BinaryTree childNode, BinaryTree parentNode,Stack<BinaryTree> NodesStack)
        {
			if(childNode != null && parentNode != null && NodesStack != null)
            {
				childNode.Depth = parentNode.Depth + 1;
				NodesStack.Push(childNode);
			}
        }

		public class BinaryTree
		{
			public int value;
			public int Depth;
			public BinaryTree left;
			public BinaryTree right;

			public BinaryTree(int value)
			{
				this.value = value;
				left = null;
				right = null;
			}
		}
		#endregion
	}
}
