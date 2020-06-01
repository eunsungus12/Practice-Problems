// https://leetcode.com/problems/min-stack

public class MinStack {

    Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
    
    /** initialize your data structure here. */
    public MinStack() {
    }
    
    public void Push(int x) {
        if (x != null) {
            int currMin = Math.Min(this.stack.Count > 0 ? this.stack.Peek().Item2 : Int32.MaxValue, x);
            this.stack.Push(new Tuple<int, int>(x, currMin));
        }
    }
    
    public void Pop() {
        if (this.stack.Count > 0) {
            this.stack.Pop();
        }
    }
    
    public int Top() {
        if (this.stack.Count > 0) {
            return this.stack.Peek().Item1;
        }
        return Int32.MinValue;
    }
    
    public int GetMin() {
        return this.stack.Peek().Item2;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */