using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconstruct_BST.MySolutions
{
    public class FirstSolution
    {
        #region Algorithm Design
        /*
         * - ReconstructBstHelper(List , RootIndex , MaxTreeIndex)
         * 1- If CurrentIndex > Number Of Total Elements in List ( List.Count )
         * -    Return Null;
         * 2- Root = Create New Node For Value At RootIndex 
         * 3- Calculate Right Child Index 
         * 4- Calculate Left Child Index
         * 5- if root has left child
         *    Root.Left = ReconstructBstHelper(List,Left Child Index, MaxLeftIndex)
         * 6- if root has right child
         *    Root.Right = ReconstructBstHelper(List,Right Child Index , MaxRightIndex)
         * - Return Root ;
         */
        #endregion

        #region Algorithm Analysis
        /* https://www.enjoyalgorithms.com/blog/time-complexity-analysis-of-recursion-in-programming
         * Time Complexity :
         * Step 1 --> O(1)
         * Step 2 --> O(1)
         * Step 3 --> O(N)   --> Loop,, So On Worst Case = O(N) Where N Is The Current InputSize
         * Step 4 --> O(1)
         * Step 5 --> O(N-1) --> Analysis of Recursion ( Input Size Is Decreased For Every Recursion By One Node )
         * Step 6 --> O(N-1) --> Analysis of Recursion ( Input Size Is Decreased For Every Recursion By One Node )
         * 
         * Total Time Complexity = 2T(N-1) + CN 
         *                       = N^2 When The Tree Is Skewed
         *                       or NLog(N) When The Tree Is Balanced
         *                       i am not sure which one of them is correct
         *                       
         *                       
         * Space Complexity :  O(Log H) For Stack Recursion Calls
         * Where H = Max Height 
         * Average = Log(N) When The Tree Is Balanced
         * Worst = N        When The Tree Is Skewed
         */
        #endregion

        #region Algorithm Implementation
        public BST ReconstructBst(List<int> preOrderTraversalValues)
        {
            return ReconstructBstHelper(preOrderTraversalValues, 0 , preOrderTraversalValues.Count - 1);
        }

        public BST ReconstructBstHelper(List<int> preOrderTraversalValues, int RootIndex , int MaxTreeIndex)
        {
            if (RootIndex >= preOrderTraversalValues.Count)
            {
                return null;
            }

            int CurrentNodeValue = preOrderTraversalValues[RootIndex];
            BST Root = new BST(CurrentNodeValue);

            ChildResult RightChildResult = CalculateRightChildIndex(preOrderTraversalValues, RootIndex , MaxTreeIndex);
            ChildResult LeftChildResult = CalculateLeftChildIndex(preOrderTraversalValues, RootIndex , RightChildResult.ChildIndex );

            int MaxRightTreeIndex = MaxTreeIndex;
            int MaxLeftTreeIndex = 0;
            switch (RightChildResult.HasChild)
            {
                case true:
                    MaxLeftTreeIndex = RightChildResult.ChildIndex - 1;
                    break;
                case false:
                    MaxLeftTreeIndex = MaxTreeIndex;
                    break;
            }

            if (LeftChildResult.HasChild)
            {
                Root.left = ReconstructBstHelper(preOrderTraversalValues, LeftChildResult.ChildIndex , MaxLeftTreeIndex);
            }
           
            if (RightChildResult.HasChild)
            {
                Root.right = ReconstructBstHelper(preOrderTraversalValues, RightChildResult.ChildIndex , MaxRightTreeIndex);
            }

            return Root;
        }


        public ChildResult CalculateLeftChildIndex(List<int> preOrderTraversalValues, int RootIndex , int MaxIndex)
        {
            ChildResult Result = new ChildResult();

            int NextElementIndex = RootIndex + 1;

            if (NextElementIndex <= MaxIndex)
            {
                int RootElement = preOrderTraversalValues[RootIndex];
                int NextElement = preOrderTraversalValues[NextElementIndex];

                if (NextElement < RootElement)
                {
                    Result.HasChild = true;
                    Result.ChildIndex = NextElementIndex;
                    return Result;
                }

            }

            Result.HasChild = false;
            return Result;

        }

        public ChildResult CalculateRightChildIndex(List<int> preOrderTraversalValues, int RootIndex, int MaxIndex)
        {
            ChildResult Result = new ChildResult();

            int NextElementIndex = RootIndex + 1;

            while (NextElementIndex <= MaxIndex)
            {
                int RootElement = preOrderTraversalValues[RootIndex];
                int NextElement = preOrderTraversalValues[NextElementIndex];
                if (NextElement >= RootElement)
                {
                    Result.HasChild = true;
                    Result.ChildIndex = NextElementIndex;
                    return Result;
                }
                NextElementIndex++;
            }

            Result.HasChild = false;
            Result.ChildIndex = MaxIndex;
            return Result;

        }


        public class BST
        {
            public int value;
            public BST left = null;
            public BST right = null;

            public BST(int value)
            {
                this.value = value;
            }
        }

        public class ChildResult
        {
            public bool HasChild;
            public int  ChildIndex;
        }
        #endregion
    }
}
