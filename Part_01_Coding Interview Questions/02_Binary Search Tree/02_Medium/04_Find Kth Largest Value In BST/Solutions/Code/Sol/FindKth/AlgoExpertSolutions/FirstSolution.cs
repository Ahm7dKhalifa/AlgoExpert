using System;
using System.Collections.Generic;
using System.Text;

namespace FindKth.AlgoExpertSolutions
{
	// Copyright © 2022 AlgoExpert LLC. All rights reserved
	public class FirstSolution
    {
		// O(n) time | O(n) space - where n is the number of
		public int FindKthLargestValueInBst(BST tree, int k)
		{
			List<int> sortedNodeValues = new List<int>();
			inOrderTraverse(tree, sortedNodeValues);
			return sortedNodeValues[sortedNodeValues.Count - k];

		}

		public void inOrderTraverse(BST node, List<int> sortedNodeValues) 
		{ 
			if (node == null)
				return;
			inOrderTraverse(node.left, sortedNodeValues);
			sortedNodeValues.Add(node.value);
		    inOrderTraverse(node.right, sortedNodeValues);
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
		



	
		

	


    }
}
