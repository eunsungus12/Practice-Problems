using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Design
{
    class MinStack
    {
        // https://leetcode.com/explore/interview/card/amazon/81/design/503/

        /** initialize your data structure here. */
        Stack<int[]> stack;
        public MinStack() {
            this.stack = new Stack<int[]>();
        }
        
        public void Push(int x) {
            if (this.stack.Count == 0) {
                this.stack.Push(new int[2] { x, x });
            } else {
                var prev = this.stack.Peek();
                this.stack.Push(new int[2] { x, prev[1] > x ? x : prev[1] });
            }
        }
        
        public void Pop() {
            if (this.stack.Count > 0) this.stack.Pop();
        }
        
        public int Top() {
            if (this.stack.Count > 0) return this.stack.Peek()[0];
            return -1;
        }
        
        public int GetMin() {
            if (this.stack.Count > 0) return this.stack.Peek()[1];
            return -1;
        }
    }
}
