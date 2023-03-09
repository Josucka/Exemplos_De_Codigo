using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareBinaryTree
{
    public class Node
    {
        internal Node(int value, Node? left = null, Node? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }
}
