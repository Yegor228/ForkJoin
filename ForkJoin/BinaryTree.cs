using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkJoin
{
    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public bool Add(int value)
        {
            TreeNode before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Value) 
                    after = after.Left;
                else if (value > after.Value) 
                    after = after.Right;
                else
                {
                    return false;
                }
            }

            TreeNode newNode = new TreeNode();
            newNode.Value = value;

            if (Root == null)
                Root = newNode;
            else
            {
                if (value < before.Value)
                    before.Left = newNode;
                else
                    before.Right = newNode;
            }

            return true;
        }
        public void Walk(TreeNode parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Value + " ");
                Walk(parent.Left);
                Walk(parent.Right);
            }
        }
        public void Summ(TreeNode parent)
        {

            Task<int> sumLeft = new Task<int>(() => Total(parent.Left));
            sumLeft.Start();
            Task<int> sumRight = new Task<int>(() => Total(parent.Right));
            sumRight.Start();
            Task.WaitAll();
            Console.WriteLine(parent.Value + sumLeft.Result + sumRight.Result);
        }

        public int Total(TreeNode nd)
        {
            int Sum = 0;
            if (nd != null)
                Sum += nd.Value + Total(nd.Left) + Total(nd.Right);
            Console.WriteLine(Sum);
            return Sum;
        }
        
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

    }
}
