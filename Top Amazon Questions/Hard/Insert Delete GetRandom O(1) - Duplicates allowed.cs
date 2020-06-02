// https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/

public class RandomizedCollection {

    private Dictionary<int, LinkedList<int>> dict;
    private List<int> list;

    /** Initialize your data structure here. */
    public RandomizedCollection() {
        this.dict = new Dictionary<int, LinkedList<int>>();
        this.list = new List<int>();
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) {
        if (this.dict.ContainsKey(val)) {
            this.list.Add(val);
            this.dict[val].AddLast(this.list.Count-1); // Add to existing linkedlist the index of the val that was added to list
            return false;
        } else {
            this.list.Add(val);
            var node = new LinkedList<int>();
            node.AddFirst(this.list.Count-1);
            this.dict.Add(val, node);
            return true;
        }
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) {
        if (this.dict.ContainsKey(val)) {
            // current index of val
            int indexOfVal = this.dict[val].Last.Value;
            this.dict[val].RemoveLast();

            if (this.list.Count > 1) {
                // current value at end of list
                int valAtEnd = this.list[this.list.Count-1];

                // set list value in current index of val to the value at end of the list
                this.list[indexOfVal] = valAtEnd;
                this.dict[valAtEnd].Last.Value = indexOfVal;
            }

            if (this.dict[val].Count == 0) this.dict.Remove(val);
            this.list.RemoveAt(this.list.Count-1);
            return true;
        } else {
            return false;
        }
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() {
        var rand = new Random();
        return this.list[rand.Next(this.list.Count)];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */