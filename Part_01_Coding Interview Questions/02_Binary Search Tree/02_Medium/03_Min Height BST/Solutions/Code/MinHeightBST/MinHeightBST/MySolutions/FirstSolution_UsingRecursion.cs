using System;
using System.Collections.Generic;
using System.Text;

namespace MinHeightBST.MySolutions
{
    public class FirstSolution_UsingRecursion
    {
		#region Algorithm Design
		/* BuildBinarySearchTreeFromSortedList(List , start , end)
		 * 1- Calculate Middle = start + end / 2
		 * 2- Create Root Node
		 * 3- Left Child = BuildBinarySearchTreeFromSortedList( List , start , Middle - 1 )
		 * 4- Right Child = BuildBinarySearchTreeFromSortedList( List , Middle + 1 , end )
		 * 5- Return Root
		 * 
		 */
		#endregion
		#region Algorithm Analysis
		/* Time Complexity : O(N)
		 * Space Complexity : O(Log N)
		 */
		#endregion
		public static BST MinHeightBst(List<int> array)
		{
			return BuildBinarySearchTreeFromSortedList(array ,0, array.Count - 1);
		}

		public static BST BuildBinarySearchTreeFromSortedList(List<int> array, int start, int end)
		{

			if (start > end)
			{
				return null;
			}

			int middle = (start + end) / 2;
			
			BST node = new BST(array[middle]);

			node.left = BuildBinarySearchTreeFromSortedList(array, start, middle - 1);

			node.right = BuildBinarySearchTreeFromSortedList(array, middle + 1, end);

			return node;
		}

		public class BST
		{
			public int value;
			public BST left;
			public BST right;

			public BST(int value)
			{
				this.value = value;
				left = null;
				right = null;
			}

			public void insert(int value)
			{
				if (value < this.value)
				{
					if (left == null)
					{
						left = new BST(value);
					}
					else
					{
						left.insert(value);
					}
				}
				else
				{
					if (right == null)
					{
						right = new BST(value);
					}
					else
					{
						right.insert(value);
					}
				}
			}
		}
	}
}
