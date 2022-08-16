using System;
using System.Collections.Generic;
using System.Text;

namespace HeightBalancedBinaryTree.MySolutions
{
    public class FirstSolution
    {
		#region Algorithm Analysis
		/*
           **********************************
           * Time Complexity
           **********************************
           //base case 1 --> O(1)
			if (node == null) 
			{
				return 0;
			}

			//base case 2 --> O(1)
			if (node.left == null && node.right == null) 
			{
				return 0;
			}

			int leftHeight = 0;
			int rightHeight = 0;
			int differenceHeight = 0;

			//Recursion Cases : 
			if (node.left != null)
				leftHeight = HeightBalancedBinaryTreeHelper(node.left, result) + 1; --> O(T(n/2))
			if (node.right != null)
				rightHeight = HeightBalancedBinaryTreeHelper(node.right, result) + 1; --> O(T(n/2))

			//Business Logic
			differenceHeight = leftHeight - rightHeight; --> O(1)

			result.CheckIsTreeBalanced(differenceHeight); --> O(1)

			int Height = Math.Max(leftHeight, rightHeight); --> O(1)

			return Height;
           
		   Total Time Complexity = O(1) +  O(1) +  O(T(n/2)) + O(T(n/2)) +  O(1)  + O(1) 
		                         = 2*O(T(n/2)) + 2*O(5)
		                         = N + C
		                         ~= N

           **********************************
           * Space Complexity
           **********************************
           O(H) --> Height Of Tree (Frames In Recursion)

           Total Space = O(H)  

                    
        */
		#endregion
		#region Algorithm Implementation 
		public bool HeightBalancedBinaryTree(BinaryTree tree)
		{
			var result = HeightBalancedBinaryTreeResult.Create();
			HeightBalancedBinaryTreeHelper(tree, result);
			return result.IsTreeBalanced;
		}

		public int HeightBalancedBinaryTreeHelper(BinaryTree node, HeightBalancedBinaryTreeResult result)
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

			int leftHeight = 0;
			int rightHeight = 0;
			int differenceHeight = 0;

			//Recursion Cases : 
			if (node.left != null)
				leftHeight = HeightBalancedBinaryTreeHelper(node.left, result) + 1;
			if (node.right != null)
				rightHeight = HeightBalancedBinaryTreeHelper(node.right, result) + 1;

			//Business Logic
			differenceHeight = leftHeight - rightHeight;

			result.CheckIsTreeBalanced(differenceHeight);

			int Height = Math.Max(leftHeight, rightHeight);

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

		public class HeightBalancedBinaryTreeResult
		{
			public bool IsTreeBalanced = true;

			public void CheckIsTreeBalanced(int currentDifferenceBetweenLeftAndRight)
			{
				if (currentDifferenceBetweenLeftAndRight > 1 || currentDifferenceBetweenLeftAndRight < -1)
					IsTreeBalanced = false;
			}

			public static HeightBalancedBinaryTreeResult Create()
            {
				return new HeightBalancedBinaryTreeResult();

			}

		}
		#endregion
	}
}
