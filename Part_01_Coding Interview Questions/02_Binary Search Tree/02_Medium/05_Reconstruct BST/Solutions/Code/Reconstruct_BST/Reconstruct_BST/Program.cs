using Microsoft.VisualBasic.CompilerServices;
using Reconstruct_BST.MySolutions;
using System;
using System.Collections.Generic;
using System.Linq;
using static Reconstruct_BST.MySolutions.SecondSolution;

namespace Reconstruct_BST
{
    class Program
    {
		//[Test]
		static void Main(string[] args)
        {
			
			//Test Case 1
			List<int> preOrderTraversalValues = new List<int> {
			10, 4, 2, 1, 5, 17, 19, 18
		    };
			BST tree = new BST(10);
			tree.left = new BST(4);
			tree.left.left = new BST(2);
			tree.left.left.left = new BST(1);
			tree.left.right = new BST(5);
			tree.right = new BST(17);
			tree.right.right = new BST(19);
			tree.right.right.left = new BST(18);
			List<int> expected = getDfsOrder(tree, new List<int>());
			var actual = new SecondSolution().ReconstructBst(preOrderTraversalValues);
			//Utils.AssertTrue(Enumerable.SequenceEqual(expected, actualValues));
			

			/*
			//Test Case 8
		
			List<int> preOrderTraversalValues = new List<int> {
			     2, 0, 1
			};
			BST tree = new BST(2);
			tree.left = new BST(0);
			tree.left.right = new BST(1);

			//var actual = new FirstSolution().ReconstructBst(preOrderTraversalValues);
			var actual = new SecondSolution().ReconstructBst(preOrderTraversalValues);
			List<int> actualValues = getDfsOrder(actual, new List<int>());
			//Utils.AssertTrue(Enumerable.SequenceEqual(expected, actualValues));
			*/

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
