using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST.MySolutions
{
    public class FirstSolution_UsingInOrderTraverse_V1
    {

        public static int FindClosestValueInBst(BinarySearchTreeNode Root, int target)
        {
            BinarySearchTree BinarySearchTree = new BinarySearchTree();
            
            /*
            BinarySearchTree.Insert(Root,5);
            BinarySearchTree.Insert(Root, 15);
            BinarySearchTree.Insert(Root, 13);
            BinarySearchTree.Insert(Root, 22);
            BinarySearchTree.Insert(Root, 14);
            BinarySearchTree.Insert(Root, 2);
            BinarySearchTree.Insert(Root, 1);
            */

            List<BinarySearchTreeNode> BinarySearchTreeAsList = new List<BinarySearchTreeNode>();
                
            BinarySearchTree.InOrderTraverse(Root, BinarySearchTreeAsList);

            for(int i = 0; i < BinarySearchTreeAsList.Count; i++)
            {
                var CurrentNode = BinarySearchTreeAsList[i];
                if (CurrentNode.Value == target)
                {
                    return CurrentNode.Value;
                }
                else if(CurrentNode.Value > target)
                {
                    var PreviosNodeIndex = i - 1;

                    if (PreviosNodeIndex >= 0 )
                    {
                        var PreviosNode = BinarySearchTreeAsList[PreviosNodeIndex];
                        if (target - PreviosNode.Value < CurrentNode.Value - target)
                        {
                            return PreviosNode.Value;
                        }
                        else
                        {
                            return CurrentNode.Value;
                        }
                    }
                    else
                    {
                        return CurrentNode.Value;
                    }

                }
            }

            return -1;
        }

        public class BinarySearchTree
        {
            BinarySearchTreeNode Root;


            public void InOrderTraverse(BinarySearchTreeNode Node , List<BinarySearchTreeNode> Result)
            {
                if (Node == null)
                    return;

                InOrderTraverse(Node.Left , Result);

                Result.Add(Node);

                InOrderTraverse(Node.Right , Result);
            }

            public BinarySearchTreeNode Insert(BinarySearchTreeNode root, int key)
            {

                if (root == null)
                {
                    return new BinarySearchTreeNode(key);
                }

                if (key < root.Value)
                {
                    root.Left = Insert(root.Left, key);
                }
                else
                {
                    root.Right = Insert(root.Right, key);
                }

                return root;
            }

        }

        public class BinarySearchTreeNode
        {
            public int Value;
            public BinarySearchTreeNode Left;
            public BinarySearchTreeNode Right;

            public BinarySearchTreeNode(int Value)
            {
                this.Value = Value;
            }

        }
    }
}
