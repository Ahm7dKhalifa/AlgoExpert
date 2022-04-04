using FindClosestValueInBST.MySolutions;
using System;
using static FindClosestValueInBST.MySolutions.FirstSolution_UsingInOrderTraverse;

namespace FindClosestValueInBST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTreeNode binarySearchTreeNode = new BinarySearchTreeNode(10);
            FirstSolution_UsingInOrderTraverse.FindClosestValueInBst(binarySearchTreeNode,12);

            
        }
    }
}
