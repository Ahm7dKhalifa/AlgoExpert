using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved.
    public class SecondSolution_UsingIteration
    {
        // Average: O(log(n)) time | O(1) space
        // Worst: O(n) time | O(1) space
        public static int FindClosestValueInBst(BST tree, int target)
        {
            return FindClosestValueInBst(tree, target, tree.value);
        }

        public static int FindClosestValueInBst(BST tree, int target, int closest)
        {
            BST currentNode = tree;
            while (currentNode != null)
            {
                if (Math.Abs(target - closest) > Math.Abs(target - currentNode.value)) 
                { 
                    closest = currentNode.value;
                }

                if (target < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if (target > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    break;
                }
            }

            return closest;
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
    }
}
