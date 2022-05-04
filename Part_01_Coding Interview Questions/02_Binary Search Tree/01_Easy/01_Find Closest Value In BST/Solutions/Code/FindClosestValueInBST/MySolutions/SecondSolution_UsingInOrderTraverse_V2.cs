using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST.MySolutions
{
    public class SecondSolution_UsingInOrderTraverse_V2
    {
        #region Algorithm Design
        /*
         * 1. Traverse Binary Search Tree InOrder To Get It As Sorted List
         * 
         * 2. If Target Is Greater Than Last Node Value On Sorted Lit
         *        return Closest Node = Last Node
         * 
         * 3. else if Target Equal One Of Node Values
         *        return Closest Node = Target
         *        
         * 4. else 
         *        return  Closest Node = GetClosestNodeToTarget(Previous,Target,Next)
         * 
         * GetClosestNodeToTarget : 
         * 4.1  GetTheNextAndPreviousOfTargetOnSortedList
         * 4.2  if Target Has Previous Node
         *         DF1 = CalculateDifferenceBetweenTargetWithPrevious
         *         DF2 = CalculateDifferenceBetweenNextWithTarget
         *         if(DF1 < DF2)
         *            return Closest Node = Previous Node
         *         else 
         *            return Closest Node = Next Node
         *      else 
         *         return ClosestNode = Next Node
         */
        #endregion

        #region Algorithm Analysis
        /*
         * This Code Is Just Refactor To The Code On The First Solution 
         * This Code Take O(3N) Time Complexity But The Code On The First Solution Take O(2N) Only
         * But The Code On The Second Solution Is More Readable And Cleaning
         * and This My Goal Of Refactor To Make The Code More Readable And Cleaning 
         * 
         * Time Complexity : 
         * Traverse Binary Search Tree  : O(N)
         * Compare Target With Last Node : O(1)
         * Is Target Equal One Of Node Values : O(N)
         * Get Closest Node To Target From Previous Or Next :  O(N) 
         * Total = O(3N) ~= O(N)
         * 
         * 
         * Space Complexity = O(N) --> Sorted List
         * 
         */
        #endregion

        #region Algorithm Implementation
        public static int FindClosestValueInBst(BST BST, int target)
        {

            BinarySearchTree BinarySearchTree = new BinarySearchTree();

            List<BST> BinarySearchTreeAsList = new List<BST>();

            BinarySearchTree.InOrderTraverse(BST, BinarySearchTreeAsList);

            if (IsTargetGreaterThanLastNode(target, BinarySearchTreeAsList))
            {
                var lastNode = BinarySearchTreeAsList.Last();
                var closestValue = lastNode.value;
                return closestValue;
            }

            if (IsTargetEqualOneOfNodeValues(target, BinarySearchTreeAsList))
            {
                var closestValue = target;
                return closestValue;
            }

           

            return GetClosestValue( target, BinarySearchTreeAsList);

        }

        private static bool IsTargetGreaterThanLastNode(int target, List<BST> BinarySearchTreeAsList)
        {
            var lastNode = BinarySearchTreeAsList.Last();
            if (lastNode != null)
            {
                if (target > lastNode.value)
                    return true;
                else
                    return false;

            }
            return false;
        }

        private static bool IsTargetEqualOneOfNodeValues(int target, List<BST> BinarySearchTreeAsList)
        {
            var IsTargetEqualOneOfNodeValues = BinarySearchTreeAsList.Where(n => n.value == target).Count() > 0;
            return IsTargetEqualOneOfNodeValues;
        }

        private static int GetClosestValue(int target, List<BST> BinarySearchTreeAsList)
        {
            GetNextAndPreviousNodesForTargetResult nextAndPreviousResult = GetNextAndPreviousNodesForTarget( target, BinarySearchTreeAsList);

            return GetClosestValueFromNextOrPrevious(nextAndPreviousResult.Previous , target , nextAndPreviousResult.Next);
        }

        private static GetNextAndPreviousNodesForTargetResult GetNextAndPreviousNodesForTarget(int target, List<BST> BinarySearchTreeAsList)
        {
            GetNextAndPreviousNodesForTargetResult result = new GetNextAndPreviousNodesForTargetResult();

            for (int i = 0; i < BinarySearchTreeAsList.Count; i++)
            {
                var CurrentNode = BinarySearchTreeAsList[i];

                if (CurrentNode.value > target)
                {
                    result.Next = CurrentNode;

                    var PreviosNodeIndex = i - 1;

                    if (PreviosNodeIndex >= 0)
                    {
                        result.Previous = BinarySearchTreeAsList[PreviosNodeIndex];                   
                    }

                    break; 
                }              
            }

            return result;
        }

        private static int GetClosestValueFromNextOrPrevious(BST Previous , int target , BST Next)
        {
            var DifferenceBetweenTargetAndPrevious = target - Previous.value;
            var DifferenceBetweenNextAndTarget = Next.value - target;

            if (DifferenceBetweenTargetAndPrevious < DifferenceBetweenNextAndTarget)
            {
                return Previous.value;
            }
            else
            {
                return Next.value;
            }
        }

        public class GetNextAndPreviousNodesForTargetResult
        {
            
            public BST Next ;
            
            public BST Previous;
            
            //Next Is The First Node Has Greater Value Than Target
            //Previous Is The Node Exist Before Target Directly
            //Example :
            // List : 1 2 7 10
            // Target : 5
            // Next : 7
            // Previous : 2

        }

        public class BinarySearchTree
        {
            BST Root;

            public void InOrderTraverse(BST Node , List<BST> Result)
            {
                if (Node == null)
                    return;

                InOrderTraverse(Node.left , Result);

                Result.Add(Node);

                InOrderTraverse(Node.right , Result);
            }

        }

        //BST Is Not Binary Search Tree But BST Is Just Binary Search Tree Node
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

        #endregion

    }
}
