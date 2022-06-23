using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Diameter.MySolutions
{
    public class FirstSolution
    {
		#region Algorithm Design
		/*
		- BinaryTreeDiameterHelper(BinaryTree node , MaxHeightResult MaxHeightResult)
		 
		 //Base Case 1 :
		  if( node == null )
		      return;
		 
		 //Base Case 2 :
		 if( node.left == null && node.right == null )
		 ---> CurrentNodeHeight = 1
		 ---> Return 

		 //Recursion Cases : 
		 BinaryTreeDiameterHelper( node.left , MaxHeightResult MaxHeightResult)
		 BinaryTreeDiameterHelper( node.right , MaxHeightResult MaxHeightResult)

		 //Business Logic :
		 node.CalculateTotalHieght()
			 int LeftSubreeHeight =  node.left != null ? node.left.CurrentNodeHeight : 0;
			 int RightSubreeHeight =  node.right != null ? node.right.CurrentNodeHeight : 0;
			 CurrentNodeHeight = LeftSubreeHeight + RightSubreeHeight
		 
		 MaxHeightResult.CalculateMaxHeight(CurrentNodeHeight) 
		
		*/
		#endregion
		public int BinaryTreeDiameter(BinaryTree tree)
		{
			BinaryTreeDiameterHelper(tree);
			return MaxBinaryTreeDiameterResult.GetMaxDiameter();
		}

		public void BinaryTreeDiameterHelper(BinaryTree node)
		{
			//Base Case 1 :
			if (node == null)
				return;

			//Base Case 2 :
			if (node.left == null && node.right == null)
            {
				node.currentHeight = 1;
				return;
			}

			//Recursion Cases : 
			BinaryTreeDiameterHelper(node.left);
			BinaryTreeDiameterHelper(node.right);

			//Business Logic :
			node.CalculateTotalSumOfLeftAndRight();
			MaxBinaryTreeDiameterResult.SetIfMax(node.totalSumOfLeftAndRight);
		}

		public class BinaryTree
		{
			public int value;
			public BinaryTree left;
			public BinaryTree right;
			public int currentHeight;
			public int leftHeight;
			public int rightHeight;
			public int totalSumOfLeftAndRight;

			public BinaryTree(int value)
			{
				this.value = value;
			}

			public void CalculateTotalSumOfLeftAndRight()
            {
				leftHeight = this.left != null ? this.left.currentHeight : 0;
				rightHeight = this.right != null ? this.right.currentHeight : 0;
				totalSumOfLeftAndRight = leftHeight + rightHeight;
			}

		
		}

		public class MaxBinaryTreeDiameterResult
		{
			public static int MaxHeight;

			public static void SetIfMax(int currentTotalSumOfLeftAndRight)
            {
				if (currentTotalSumOfLeftAndRight > MaxHeight)
					MaxHeight = currentTotalSumOfLeftAndRight;
			}

			public static int GetMaxDiameter()
			{
				return MaxHeight - 1;
			}

		}
	}
}
