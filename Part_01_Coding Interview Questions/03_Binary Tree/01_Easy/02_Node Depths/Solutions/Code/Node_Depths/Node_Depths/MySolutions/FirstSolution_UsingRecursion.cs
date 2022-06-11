using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Depths.MySolutions
{
    public class FirstSolution_UsingRecursion
	{
		#region Algorithm Design
		/* - NodeDepthsHelper(BinaryTree CurrentNode , int ParentDepth , NodeDepthsResult Result)
		    Base Case :
		    if (CurrentNode == null)
				return;

		    Business Logic :
			CurrentNode.CurrentDepth = ParentDepth + 1;
			Result.TotalSumOfDepths += CurrentNode.CurrentDepth;

		    Recursion Cases :
			NodeDepthsHelper(CurrentNode.left,  CurrentNode.CurrentDepth , Result);
			NodeDepthsHelper(CurrentNode.right, CurrentNode.CurrentDepth , Result);
         */
		#endregion
		#region Algorithm Analysis
		/*
         * Time Complexity : 
            Base Case :
		    if (CurrentNode == null) --> O(1)
				return;

		    Business Logic :
			CurrentNode.CurrentDepth = ParentDepth + 1;  --> O(1)
			Result.TotalSumOfDepths += CurrentNode.CurrentDepth;  --> O(1)

		    Recursion Cases :
			NodeDepthsHelper(CurrentNode.left,  CurrentNode.CurrentDepth , Result); --> T(n/2)
			NodeDepthsHelper(CurrentNode.right, CurrentNode.CurrentDepth , Result); --> T(n/2)
           
		    total time complexity = O(1) + O(1) + O(1) + T(n/2) + T(n/2)
                                  = 2T(n/2) + O(3)
                                  = T(n) + C
                                  = O(n)
         
		 * Space Complexity : O(h)
           where h is the max height of the tree
		   when the tree is balanced : h = log n
		   when the tree is skewed : h = n
         
         */
		#endregion
		#region Algorithm Implementation
		public static int NodeDepths(BinaryTree root)
		{
			NodeDepthsResult Result = new NodeDepthsResult();
			NodeDepthsHelper(root, -1, Result);
			return Result.TotalSumOfDepths;
		}

		public static void NodeDepthsHelper(BinaryTree CurrentNode , int ParentDepth , NodeDepthsResult Result)
        {
			if (CurrentNode == null)
				return;

			CurrentNode.CurrentDepth = ParentDepth + 1;
			Result.TotalSumOfDepths += CurrentNode.CurrentDepth;

			NodeDepthsHelper(CurrentNode.left,  CurrentNode.CurrentDepth , Result);
			NodeDepthsHelper(CurrentNode.right, CurrentNode.CurrentDepth , Result);

		}
		
		public class BinaryTree
		{
			public int value;
			public int CurrentDepth;
			public BinaryTree left;
			public BinaryTree right;

			public BinaryTree(int value)
			{
				this.value = value;
				left = null;
				right = null;
			}
		}

		public class NodeDepthsResult
		{
			public int TotalSumOfDepths;
		}
		#endregion
	}
}
