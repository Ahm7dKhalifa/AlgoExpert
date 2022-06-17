using System;
using System.Collections.Generic;
using System.Text;

namespace Invert_Binary_Tree.MySolutions
{
    public class SecondSolution_UsingQueue
	{
		#region Algorithm Design
		/*
		 - Define Queue Of Nodes
		 - If Root Is Not Null
		      - Enqueue Root To Queue
		      - While Queue Is Not Empty
		            - Define Variable To Store The Current Node Which Dequeued From The Queue
		            - if Current Node Is Not Null
		            - Define Variable To Store Left
		            - Define Variable To Store Right
		            - Swap Left And Right
		            - Enqueue Left To Queue
		            - Enqueue Right To Queue
		        
         */
		#endregion
		#region Algorithm Analysis
		/*
         **********************
         Time Complexity : O(N)
		 **********************
		
         
		 ************************
		 Space Complexity : O(1)
		 ************************

         
         */
		#endregion
		#region Algorithm Implementation
		public static void InvertBinaryTree(BinaryTree tree)
		{
			BinaryTree Root = tree;
			Queue<BinaryTree> QueueOfNodes = new Queue<BinaryTree>();
            if (tree != null)
            {
				QueueOfNodes.Enqueue(Root);
			    while(QueueOfNodes.Count > 0)
			    {
					BinaryTree CurrentNode = QueueOfNodes.Dequeue();
					if(CurrentNode != null)
                    {
						SwapLeftAndRight(CurrentNode);
						EnqueueLeftAndRight(CurrentNode, QueueOfNodes);
					}

				}
			}			
		}

		public static void SwapLeftAndRight(BinaryTree Node)
        {
			BinaryTree Left = Node.left;
			BinaryTree Right = Node.right;

			Node.left = Right;
			Node.right = Left;

        }

		public static void EnqueueLeftAndRight(BinaryTree Node,Queue<BinaryTree> QueueOfNodes)
		{
			QueueOfNodes.Enqueue(Node.left);
			QueueOfNodes.Enqueue(Node.right);
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
