using System;
using  FindSuccessor.MySolutions;
using static FindSuccessor.MySolutions.FirstSolution;

namespace FindSuccessor
{
    class Program
    {
        static void Main(string[] args)
        {
			BinaryTree root = new BinaryTree(1);
			root.left = new BinaryTree(2);
			root.left.parent = root;
			root.right = new BinaryTree(3);
			root.right.parent = root;

			root.right.left = new BinaryTree(4);
			root.right.left.left = new BinaryTree(5);
			root.right.left.left.left = new BinaryTree(6);
			root.right.left.left.left.left = new BinaryTree(7);

			BinaryTree node = root;
			FirstSolution FirstSolution = new FirstSolution();
			var result = FirstSolution.FindSuccessor(root, node);
		}
    }
}
