using BranchSums.MySolutions;
using System;
using static BranchSums.MySolutions.SecondSolution;

namespace BranchSums
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new BinaryTree(1);
            root.left = new BinaryTree(2);
            root.right = new BinaryTree(3);

            root.left.left = new BinaryTree(4);
            root.left.right = new BinaryTree(5);


            root.right.left = new BinaryTree(6);
            root.right.right = new BinaryTree(7);


            root.left.left.left = new BinaryTree(8);
            root.left.left.right = new BinaryTree(9);


            root.left.right.left = new BinaryTree(10);

            //var result = FirstSolution.BranchSums(root);

            var result = SecondSolution.BranchSums(root);

            Console.WriteLine();
        }
    }
}
