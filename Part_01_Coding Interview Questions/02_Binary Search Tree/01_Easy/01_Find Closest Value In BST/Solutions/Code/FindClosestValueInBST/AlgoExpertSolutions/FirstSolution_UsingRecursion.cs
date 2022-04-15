using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST.AlgoExpertSolutions
{
    // Copyright © 2022 AlgoExpert LLC. All rights reserved.
    public class FirstSolution_UsingRecursion
    {
        // Average: O(log(n)) time | O(log(n)) space
        // Worst: O(n) time | O(n) space
        public static int FindClosestValueInBst(BST tree, int target)
        {
            return FindClosestValueInBst(tree, target, tree.value);
        }

        public static int FindClosestValueInBst(BST tree, int target, int closest)
        {
            if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
            {
                closest = tree.value;
            }

            if (target < tree.value && tree.left != null)
            {
                return FindClosestValueInBst(tree.left, target, closest);
            }
            else if (target > tree.value && tree.right != null)
            {
                return FindClosestValueInBst(tree.right, target, closest);
            }
            else
            {
                return closest;
            }
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
