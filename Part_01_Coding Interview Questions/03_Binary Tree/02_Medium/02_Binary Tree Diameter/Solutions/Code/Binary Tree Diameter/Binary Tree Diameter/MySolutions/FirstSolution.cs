using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Diameter.MySolutions
{
    public class FirstSolution
	{
		#region Algorithm Analysis
		/*
		******************************************
		* Time Complexity
		* ****************************************
		public int BinaryTreeDiameterHelper(BinaryTree node, DiameterResult diameterResult)
		{
		   //base case 1
		   if (node == null) --> O(1)
		   {
			   return 0;
		   }

		   //base case 2
		   if (node.left == null && node.right == null) --> O(1)
		   {
			   return 0;
		   }

		   int leftDiamter = 0;  --> O(1)
		   int rightDiamter = 0; --> O(1)
		   int totalDiamter = 0; --> O(1)

		   //Recursion Cases : 
		   if (node.left != null)
			   leftDiamter = BinaryTreeDiameterHelper(node.left, diameterResult) + 1;    --> O(T(N/2))
		   if (node.right != null)
			   rightDiamter = BinaryTreeDiameterHelper(node.right, diameterResult) + 1;  --> O(T(N/2));

		   //Business Logic
		   totalDiamter = leftDiamter + rightDiamter; --> O(1)
		   diameterResult.SetIfMax(totalDiamter);     --> O(1)
		   int Height = Math.Max(leftDiamter, rightDiamter); --> O(1)

		   return Height;
		}

		Total Time = O(T(N/2)) + O(T(N/2)) + O(8);
		           = 2(T(N/2)) + C
		           = N


		*/
		#endregion
		public int BinaryTreeDiameter(BinaryTree tree)
		{
		   DiameterResult diameterResult = new DiameterResult();
		   BinaryTreeDiameterHelper(tree, diameterResult);
		   return diameterResult.Max;
		}

		public int BinaryTreeDiameterHelper(BinaryTree node, DiameterResult diameterResult)
		{
		   //base case 1
		   if (node == null)
		   {
			   return 0;
		   }

		   //base case 2
		   if (node.left == null && node.right == null)
		   {
			   return 0;
		   }

		   int leftDiamter = 0;
		   int rightDiamter = 0;
		   int totalDiamter = 0;

		   //Recursion Cases : 
		   if (node.left != null)
				leftDiamter  = BinaryTreeDiameterHelper(node.left, diameterResult) + 1;
		   if (node.right != null)
			   rightDiamter = BinaryTreeDiameterHelper(node.right, diameterResult) + 1;

		   //Business Logic
		   totalDiamter = leftDiamter + rightDiamter;
		   diameterResult.SetIfMax(totalDiamter);
		   int Height = Math.Max(leftDiamter, rightDiamter);

		   return Height;
		}

		public class BinaryTree
		{
		   public int value;
		   public BinaryTree left;
		   public BinaryTree right;

		   public BinaryTree(int value)
		   {
			   this.value = value;
		   }

		}

		public class DiameterResult
		{
		   public int Max;

		   public void SetIfMax(int currentTotalSumOfLeftAndRight)
		   {
			   if (currentTotalSumOfLeftAndRight > Max)
				   Max = currentTotalSumOfLeftAndRight;
		   }

		}
    }
}
