using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Depths.MySolutions
{
    public class FirstSolution
    {
		public static int NodeDepths(BinaryTree root)
		{
			NodeDepthsResult Result = new NodeDepthsResult();
			NodeDepthsHelper(root, ParentDepth: -1, Result);
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
	}
}
