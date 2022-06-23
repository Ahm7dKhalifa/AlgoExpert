using Binary_Tree_Diameter.MySolutions;
using System;
using static Binary_Tree_Diameter.MySolutions.FirstSolution;

namespace Binary_Tree_Diameter
{
    class Program
    {
        static void Main(string[] args)
        {
			var root = new BinaryTree(1);
			root.left = new BinaryTree(3);
			root.left.left = new BinaryTree(7);
			root.left.left.left = new BinaryTree(8);
			root.left.left.left.left = new BinaryTree(9);
			root.left.right = new BinaryTree(4);
			root.left.right.right = new BinaryTree(5);
			root.left.right.right.right = new BinaryTree(6);
			root.right = new BinaryTree(2);
			FirstSolution firstSolution = new FirstSolution();
			var actual = firstSolution.BinaryTreeDiameter(root);
		}
    }
}
