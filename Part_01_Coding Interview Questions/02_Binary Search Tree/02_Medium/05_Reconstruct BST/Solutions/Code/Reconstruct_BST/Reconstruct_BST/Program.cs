using Microsoft.VisualBasic.CompilerServices;
using Reconstruct_BST.MySolutions;
using System;
using System.Collections.Generic;
using System.Linq;
using static Reconstruct_BST.MySolutions.FirstSolution;

namespace Reconstruct_BST
{
    class Program
    {
		//[Test]
		static void Main(string[] args)
        {
			List<int> preOrderTraversalValues = new List<int> {
			10, 4, 2, 1, 3, 17, 19, 18
		    };
			BST tree = new BST(10);
			tree.left = new BST(4);
			tree.left.left = new BST(2);
			tree.left.left.left = new BST(1);
			tree.left.right = new BST(3);
			tree.right = new BST(17);
			tree.right.right = new BST(19);
			tree.right.right.left = new BST(18);
			List<int> expected = getDfsOrder(tree, new List<int>());
			var actual = new FirstSolution().ReconstructBst(preOrderTraversalValues);
			List<int> actualValues = getDfsOrder(actual, new List<int>());
			//Utils.AssertTrue(Enumerable.SequenceEqual(expected, actualValues));

		}

		public static List<int> getDfsOrder(BST node, List<int> values)
		{
			values.Add(node.value);
			if (node.left != null)
			{
				getDfsOrder(node.left, values);
			}
			if (node.right != null)
			{
				getDfsOrder(node.right, values);
			}
			return values;
		}
	}
}
