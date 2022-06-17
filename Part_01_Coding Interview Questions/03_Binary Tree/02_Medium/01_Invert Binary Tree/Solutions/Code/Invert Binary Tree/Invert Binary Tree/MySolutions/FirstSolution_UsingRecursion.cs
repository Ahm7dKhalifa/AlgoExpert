using System;
using System.Collections.Generic;
using System.Text;

namespace Invert_Binary_Tree.MySolutions
{
    public class FirstSolution_UsingRecursion
    {
		#region Algorithm Design
		/* - InvertBinaryTreeHelper(BinaryTree CurrentNode)
		    Base Case :
		    if (CurrentNode == null)
				return;

		    Business Logic :
		    swap left and right childs :
		    - define variable to store left child
		    - define variable to store right child
			- CurrentNode left child = right child
		    - CurrentNode right child = left child
			

		    Recursion Cases :
			InvertBinaryTreeHelper(CurrentNode.left);
			InvertBinaryTreeHelper(CurrentNode.right);
         */
		#endregion
		#region Algorithm Analysis
		/*
         **********************
         Time Complexity :
		 **********************
            Base Case :
		    if (CurrentNode == null) --> O(1)
				return;

		    Business Logic :
		    swap left and right childs :
		    - define variable to store left child -->  O(1)
		    - define variable to store right child --> O(1)
			- CurrentNode left child = right child --> O(1)
		    - CurrentNode right child = left child --> O(1)
			

		    Recursion Cases :
			InvertBinaryTreeHelper(CurrentNode.left);  --> O(T(n/2))
			InvertBinaryTreeHelper(CurrentNode.right); --> O(T(n/2))
           
		    total time complexity = O(5) + T(n/2) + T(n/2)
                                  = 2T(n/2) + O(5)
                                  = T(n) + C
                                  = O(n)
         
		 ************************
		 Space Complexity : O(h)
		 ************************
           where h is the max height of the tree
		   when the tree is balanced : h = log n
		   when the tree is skewed : h = n
         
         */
		#endregion
		#region Algorithm Implementation
		public static void InvertBinaryTree(BinaryTree tree)
		{
			InvertBinaryTreeHelper(tree);
		}

		public static void InvertBinaryTreeHelper(BinaryTree CurrentNode)
		{
			//Base Case :
		    if (CurrentNode == null)
				return;

			//Business Logic :
			//swap left and right childs:
			BinaryTree leftChild = CurrentNode.left;
			BinaryTree rightChild = CurrentNode.right;
			CurrentNode.left = rightChild;
			CurrentNode.right = leftChild;


			//Recursion Cases:
			InvertBinaryTreeHelper(CurrentNode.left);
			InvertBinaryTreeHelper(CurrentNode.right);
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
		#endregion
	}

}
