// https://leetcode.com/problems/insert-delete-getrandom-o1/

public class RandomizedSet {
    
    private HashSet<int> set;

    /** Initialize your data structure here. */
    public RandomizedSet() {
        this.set = new HashSet<int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if (!this.set.Contains(val)) {
            this.set.Add(val);
            return true;
        }
        return false;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if (this.set.Contains(val)) {
            this.set.Remove(val);
            return true;
        }
        return false;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        if (this.set.Count < 1) return 0;
        if (this.set.Count == 2) return this.set.First();
        var rand = new Random();
        int randomNum = rand.Next(this.set.Count);
        foreach(int val in this.set) {
            if (randomNum == 0) return val;
            randomNum--;
        }
        return this.set.First();
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */

 // Get Random is not O(1) Time Complexity