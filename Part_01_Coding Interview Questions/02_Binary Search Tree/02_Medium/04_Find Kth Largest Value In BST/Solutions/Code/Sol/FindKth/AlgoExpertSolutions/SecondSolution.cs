using System;
using System.Collections.Generic;
using System.Text;

namespace FindKth.AlgoExpertSolutions
{
	// Copyright © 2022 AlgoExpert LLC. All rights reserved
	public class SecondSolution
	{
		// O(h + k) time | O(h) space - where h is the height
		// input parameter
		public class TreeInfo
		{
			public int numberOfNodesVisited;
			public int latestVisitedNodeValue;
			public TreeInfo(int numberOfNodesVisited, int latestVisitedNodeValue)
			{

				this.numberOfNodesVisited = numberOfNodesVisited;
				this.latestVisitedNodeValue = latestVisitedNodeValue;
			}
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

		public int FindKthLargestValueInBst(BST tree, int k) 
		{ 
		      TreeInfo treeInfo = new TreeInfo(0, -1);
		      reverseInOrderTraverse(tree, k, treeInfo);
			  return treeInfo.latestVisitedNodeValue;
		}

	    public void reverseInOrderTraverse(BST node, int k, TreeInfo treeInfo) 
		{ 

			 if (node == null || treeInfo.numberOfNodesVisited >= k )
				return;
			 reverseInOrderTraverse(node.right, k, treeInfo);
			 if (treeInfo.numberOfNodesVisited < k) {
				 treeInfo.numberOfNodesVisited += 1;
				 treeInfo.latestVisitedNodeValue = node.value;
				 reverseInOrderTraverse(node.left, k, treeInfo);
		     }
        }    
	}
}
