using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    class Tree
    {

    }

    class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node(int val, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
