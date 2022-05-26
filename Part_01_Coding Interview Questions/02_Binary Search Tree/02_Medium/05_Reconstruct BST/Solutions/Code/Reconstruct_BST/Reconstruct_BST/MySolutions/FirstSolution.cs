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
         * 1- ReconstructBstHelper(List , RootIndex )
         * - If CurrentIndex >= Number Of Total Elements in List ( List.Count )
         * -    Return Null;
         * - Root = Create New Node 
         * - Define Variable To Store Left Child Index
         * - Define Variable To Store Right Child Index
         * - Calculate Left Child Index
         * - Calculate Right Child Index
         * - Root.Left = ReconstructBstHelper(List,Left Child Index)
         * - Root.Right = ReconstructBstHelper(List,Right Child Index)
         * - Return Root ;
         * 
         * 2- CalculateLeftChildIndex(List,RootIndex)
         *  - If Root Index < ( Number Of Element On List - 1 )
         *       Next Element Index = Root Index + 1
         *       if(Next Element < Root Element )
         *          ChildIndexResult.HasIndex = true
         *          ChildIndexResult.Index = Next Element Index
         *          return ChildIndexResult;
         *    ChildIndexResult.HasIndex = false
         *    return ChildIndexResult;
         *    
         * 2- CalculateRightChildIndex(List,RootIndex)
         *  - Next Element Index = RootIndex + 1 
         *  - While Next Element Index < ( Number Of Element On List - 1 )
         *       if(Next Element > Root Element )
         *          ChildIndexResult.HasIndex = true
         *          ChildIndexResult.Index = Next Element Index
         *          return ChildIndexResult;
         *       else
         *          Next Element Index++
         *    ChildIndexResult.HasIndex = false
         *    return ChildIndexResult;    
         *    
         *  Class ChildIndexResult 
         *        - Index
         *        - HasIndex
         */
        #endregion

        #region Algorithm Analysis
        #endregion

        #region Algorithm Implementation
        public BST ReconstructBst(List<int> preOrderTraversalValues)
        {
            return ReconstructBstHelper(preOrderTraversalValues, 0);
        }

        public BST ReconstructBstHelper(List<int> preOrderTraversalValues, int RootIndex )
        {
            if (RootIndex >= preOrderTraversalValues.Count)
            {
                return null;
            }

            int CurrentNodeValue = preOrderTraversalValues[RootIndex];
            BST Root = new BST(CurrentNodeValue);

            ChildIndexResult LeftIndexResult = CalculateLeftChildIndex(preOrderTraversalValues, RootIndex);
            ChildIndexResult RightIndexResult = CalculateRightChildIndex(preOrderTraversalValues, RootIndex);

            if (LeftIndexResult.HasIndex)
            {
                Root.left = ReconstructBstHelper(preOrderTraversalValues, LeftIndexResult.Index );
            }

           
            if (RightIndexResult.HasIndex)
            {
                Root.right = ReconstructBstHelper(preOrderTraversalValues, RightIndexResult.Index);
            }

            return Root;
        }


        public ChildIndexResult CalculateLeftChildIndex(List<int> preOrderTraversalValues, int RootIndex)
        {
            ChildIndexResult Result = new ChildIndexResult();

            int NextElementIndex = RootIndex + 1;

            if (NextElementIndex < preOrderTraversalValues.Count)
            {
                int RootElement = preOrderTraversalValues[RootIndex];
                int NextElement = preOrderTraversalValues[NextElementIndex];

                if (NextElement < RootElement)
                {
                    Result.HasIndex = true;
                    Result.Index = NextElementIndex;
                    return Result;
                }
            }

            Result.HasIndex = false;
            return Result;

        }

        public ChildIndexResult CalculateRightChildIndex(List<int> preOrderTraversalValues, int RootIndex)
        {
            ChildIndexResult Result = new ChildIndexResult();

            int NextElementIndex = RootIndex + 1;

            while (NextElementIndex < preOrderTraversalValues.Count)
            {
                int RootElement = preOrderTraversalValues[RootIndex];
                int NextElement = preOrderTraversalValues[NextElementIndex];
                if (NextElement > RootElement)
                {
                    Result.HasIndex = true;
                    Result.Index = NextElementIndex;
                    return Result;
                }
                NextElementIndex++;
            }

            Result.HasIndex = false;
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

        public class ChildIndexResult
        {
            public bool HasIndex;
            public int Index;
        }
        #endregion
    }
}
