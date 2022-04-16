using System;
using System.Collections.Generic;
using System.Text;

namespace Validate_BST.MySolutions
{
	public class FirstSolution_UsingRecursion
	{
		#region Algorithm Design
		/*
		 * 1- Check If Node = Null
		 *    Return True
		 *    
		 * 2- Check If Left Child != Null and Parent Value < Left Child Value
		 *    return false
		 * 
		 * 3- Check If Right Child != Null and Parent Value > Right Child Value
		 *    return false 
		 * 
		 * 4- Check If Left Sub Tree Valid --> Using Recursion Of Left Child
		 *
		 * 5- Check If Right Sub Tree Valid --> Using Recursion Of Right Child
		 * 
		 * 6- if Left Sub Tree Valid and Right Sub Tree Valid 
		 *    return true
		 *    else 
		 *    return false
		 * 
		 * 
		 */
		#endregion

		#region Algorithm Analysis
		/*
		 * Time Complexity :
		 * Step1 --> O(1)
		 * Step2 --> O(1) 
		 * Step3 --> O(1) 
		 * Step4 --> O(log n) 
		 * Step5 --> O(log n) 
		 * Step6 --> O(1)  
		 */
		#endregion
		public static bool ValidateBst(BST tree)
		{

			return ValidateBinarySearchTree(tree, 0 , tree.value);

		}

		public static bool ValidateBinarySearchTree(BST CurrentNode, int typeOfSubtree , int valueOfRootNode)
		{

			if (CurrentNode == null)
				return true;

			BST LeftNode = CurrentNode.left;
			BST RightNode = CurrentNode.right;
			
			if (LeftNode != null &&  CurrentNode.value <= LeftNode.value )
				return false;

			if (RightNode != null && CurrentNode.value >= RightNode.value )
				return false;

            switch (typeOfSubtree)
            {
				case (int)TypeOfSubtree.Root:
			    {
				    return ValidateBinarySearchTree(LeftNode, (int)TypeOfSubtree.Left, valueOfRootNode) && ValidateBinarySearchTree(RightNode, (int)TypeOfSubtree.Right, valueOfRootNode);
			    }
				case (int)TypeOfSubtree.Left:
                {
					if (CurrentNode.value >= valueOfRootNode)
						return false;
					break;
			    }
				case (int)TypeOfSubtree.Right:
				{
						if (CurrentNode.value <= valueOfRootNode)
							return false;
						break;
				}
				default: break;
			}

			return ValidateBinarySearchTree(LeftNode, typeOfSubtree, valueOfRootNode) && ValidateBinarySearchTree(RightNode, typeOfSubtree, valueOfRootNode);

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


		public enum TypeOfSubtree
        {
			Root = 0,
			Left = 1 ,
			Right = 2
        }
	}
}
