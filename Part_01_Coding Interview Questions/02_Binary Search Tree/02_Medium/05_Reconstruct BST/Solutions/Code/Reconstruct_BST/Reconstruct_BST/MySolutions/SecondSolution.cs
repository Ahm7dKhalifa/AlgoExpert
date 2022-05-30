using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconstruct_BST.MySolutions
{
    public class SecondSolution
    {
        #region Algorithm Design
        /*
            //Base Case 1
            if (RootIndex >= preOrderTraversalValues.Count)
            {
                return null;
            }

            int CurrentNodeValue = preOrderTraversalValues[RootIndex];
            BST Root = new BST(CurrentNodeValue);

            //Base Case 2
            if (CurrentNodeValue < Min || CurrentNodeValue > Max)
                return null;
          
          
            Root.left = ReconstructBstHelper(preOrderTraversalValues,  RootIndex + 1, Min , CurrentNodeValue - 1);
            Root.right = ReconstructBstHelper(preOrderTraversalValues, RootIndex + 1, CurrentNodeValue , Max);
            

            return Root;
         */
        #endregion

        #region Algorithm Analysis
        /* https://www.enjoyalgorithms.com/blog/time-complexity-analysis-of-recursion-in-programming
         * Time Complexity : O(N)
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
            int RootIndex = 0;
            return ReconstructBstHelper(preOrderTraversalValues, ref RootIndex , int.MinValue , int.MaxValue);
        }

        public BST ReconstructBstHelper(List<int> preOrderTraversalValues, ref int RootIndex  , int Min , int Max)
        {
            //Base Case 1
            if (RootIndex >= preOrderTraversalValues.Count)
            {
                return null;
            }

            int CurrentNodeValue = preOrderTraversalValues[RootIndex];
            BST Root = new BST(CurrentNodeValue);

            //Base Case 2
            if (CurrentNodeValue < Min || CurrentNodeValue > Max)
                return null;

            RootIndex++;
            Root.left = ReconstructBstHelper(preOrderTraversalValues,  ref RootIndex, Min , CurrentNodeValue - 1);
            Root.right = ReconstructBstHelper(preOrderTraversalValues, ref RootIndex, CurrentNodeValue + 1  , Max);
            

            return Root;
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


        #endregion
    }
}
