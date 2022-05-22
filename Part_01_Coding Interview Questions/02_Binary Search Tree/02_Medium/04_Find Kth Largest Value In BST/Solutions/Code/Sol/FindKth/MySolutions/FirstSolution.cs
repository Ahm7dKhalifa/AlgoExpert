using System;
using System.Collections.Generic;
using System.Text;

namespace FindKth
{
    public class FirstSolution
    {

		#region algorithm design
		/*
		 * - Define Sorted List
		 * - Define KIndex
		 * - Define SortedListLength
		 * - Build Sorted List From Binary Search Tree By InOrder Traverse
		 * - If K <= SortedListLength
		 * -    KIndex = SortedListLength - K
		 * -    return SortedListLength[KIndex]
		 * - else
		 * -    return -1
		 */
		#endregion

		#region algorithm analysis
		/*
		 * Time Complexity 
		 * - Define Sorted List = O(1)
		 * - Define KIndex = O(1)
		 * - Define SortedListLength = O(1)
		 * - Build Sorted List From Binary Search Tree By InOrder Traverse = O(N)
		 * - If K <= SortedListLength = O(1)
		 * -    KIndex = SortedListLength - K = O(1)
		 * -    return SortedListLength[KIndex] = O(1)
		 * - else = O(1)
		 * -    return -1 = O(1)
		 * 
		 * Total Time Complexity = O(1) + O(1) + O(1) + O(N) + O(1) + O(1) + O(1)
		 *                       = O(N) + O(6)
		 *                       = O(N)
		 *                       
		 * Space Complexity :
		 * - Sorted List = O(N)
		 * - KIndex = O(1)
		 * - SortedListLength = O(1)
		 */
		#endregion

		#region algorithm Implementation
		public int FindKthLargestValueInBst(BST tree, int k)
		{
			List<BST> SortedList = new List<BST>();
			int SortedListLength;
			int KIndex;
			BinarySearchTree.InOrderTraverse(tree, SortedList);
			SortedListLength = SortedList.Count - 1;
			if (k <= SortedListLength)
            {
				KIndex = SortedListLength - k;
				return SortedList[KIndex].value;
			}
			return -1;
		}

		
		public class BST
		{
			public int value;
			public BST left = null;
			public BST right = null;

			public BST(int value)
			{
				this.value = value;
			}
		}

		public class BinarySearchTree
		{
			BST Root;


			public static void InOrderTraverse(BST Node, List<BST> Result)
			{
				if (Node == null)
					return;

				InOrderTraverse(Node.left, Result);

				Result.Add(Node);

				InOrderTraverse(Node.right, Result);
			}



		}

        #endregion
    }
}
