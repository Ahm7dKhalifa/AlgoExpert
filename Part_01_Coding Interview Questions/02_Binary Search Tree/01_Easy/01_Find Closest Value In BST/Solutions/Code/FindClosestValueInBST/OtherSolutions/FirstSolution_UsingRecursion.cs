using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST.OtherSolutions
{
    public class FirstSolution_UsingRecursion
    {
		/*

		this greet and simple solution i get and learn  from this link
		https://www.callicoder.com/find-closest-element-binary-search-tree/

       */

		public static int FindClosestValueInBst(BST tree, int target)
		{
			var closestNode = findClosestNode(tree, target);
			return closestNode.value;
		}

		private static BST findClosestNode(BST node, int target)
		{
			if (target < node.value && node.left != null)
			{
				// Closest node is either the current node or a node in the left subtree
				BST closestNodeLeftSubtree = findClosestNode(node.left, target);
				return getClosestNode(node, closestNodeLeftSubtree, target);
			}
			else if (target > node.value && node.right != null)
			{
				// Closest node is either the current node or a node in the right subtree
				BST closestNodeRightSubtree = findClosestNode(node.right, target);
				return getClosestNode(node, closestNodeRightSubtree, target);
			}
			else
			{
				return node;
			}
		}


		private static BST getClosestNode(BST node1, BST node2, int target)
		{
			if (Math.Abs(target - node1.value) < Math.Abs(target - node2.value))
			{
				return node1;
			}
			else
			{
				return node2;
			}
		}

		public class BST
		{
			public int value;
			public BST left;
			public BST right;

			public BST(int value)
			{
				this.value = value;
			}
		}
	}
}
