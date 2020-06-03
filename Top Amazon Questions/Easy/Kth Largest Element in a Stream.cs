// https://leetcode.com/problems/kth-largest-element-in-a-stream/

public class KthLargest {

    private MinHeap heap;
    private int k;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        this.heap = new Heap(k);
        this.heap.Add(nums);
    }
    
    public int Add(int val) {
        this.heap.Add(val);
        return this.heap.Min;
    }

    // For the sake of practice, created Heap class

    public class Heap {
        private int[] arr;
        private int size;
        private int heapSize;
        public Heap(int size) {
            this.size = size;
            this.heapSize = 0;
            this.arr = new int[this.size];
            for (int i = 0; i < this.size; i++) {
                this.arr[i] = Int32.MinValue;
                this.heapSize++;
            }
        }

        public int Min {
            get {
                return this.arr[0];
            }
        }

        // Add to top and sort
        public void Add(int val) {
            if (val > this.arr[0]) {
                // Perform "delete"
                Swap(0, this.size-1);
                // Sort after "delete"
                SortDown();
                // Perform Insert
                this.arr[0] = val;
                // Sort Heap
                SortDown();
            }
        }

        // Polymorphism - Overloading
        // Having 2 or more methods with the same name but different parameters
        public void Add(int[] nums) {
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] > this.arr[0]) {
                    Add(nums[i]);
                }
            }
        }

        private void SortDown(int i = 0) {
            int left = (i + 1) * 2 - 1;
            int right = (i + 1) * 2;
            // no need to sort leaf node
            if (right > this.size-1) return;
            // no need to sort already sorted
            if (this.arr[i] < this.arr[left] && this.arr[i] < this.arr[right]) return;
            if (this.arr[i] > this.arr[left]) {
                Swap(i, left);
                SortDown(left);
            } else {
                Swap(i, right);
                SortDown(right);
            }
        }

        public void Print() {
            Console.Write("Printing: ");
            for (int i = 0; i < this.size; i++) {
                Console.Write(this.arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine("");
        }

        private void SortUp(int iter = -1) {
            iter = iter == -1 ? this.size - 1 : iter;
            int parent = iter < 2 ? 0 : iter/2;
            // no need to sort leaf node
            if (iter == 0) return;
            // no need to sort already sorted
            if (this.arr[iter] < this.arr[parent]) {
                Swap(parent, iter);
                SortUp(parent);
            }
        }

        private void Swap(int left, int right) {
            int temp = this.arr[right];
            this.arr[right] = this.arr[left];
            this.arr[left] = temp;
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */