using System;
using static Validate_BST.MySolutions.FirstSolution_Wrong_UsingRecursion;

namespace Validate_BST
{
    class Program
    {
        static void Main(string[] args)
        {
			var root = new BST(10);
			
			root.left = new BST(5);
			root.left.left = new BST(2);
			root.left.right = new BST(5);

			root.left.left.left = new BST(1);



			root.right = new BST(15);
			root.right.left = new BST(13);
			root.right.right = new BST(22);

			root.right.left.right = new BST(16);
		}
    }
}
