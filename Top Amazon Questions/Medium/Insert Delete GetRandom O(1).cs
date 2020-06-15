// https://leetcode.com/problems/insert-delete-getrandom-o1/

public class RandomizedSet {

    private Dictionary<int, int> dict;
    private List<int> list;

    /** Initialize your data structure here. */
    public RandomizedSet() {
        this.dict = new Dictionary<int, int>();
        this.list = new List<int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if (this.dict.ContainsKey(val)) return false;
        this.list.Add(val);
        this.dict.Add(val, this.list.Count - 1);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if (!this.dict.ContainsKey(val)) return false;
        // Set current val index to last index val in list
        this.list[this.dict[val]] = this.list[this.list.Count - 1];
        this.dict[this.list[this.list.Count-1]] = this.dict[val];
        // Remove last item in list
        this.list.RemoveAt(this.list.Count - 1);
        this.dict.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        var rand = new Random();
        return this.list[rand.Next(this.list.Count)];
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
// public class RandomizedSet {
    
//     private HashSet<int> set;

//     /** Initialize your data structure here. */
//     public RandomizedSet() {
//         this.set = new HashSet<int>();
//     }
    
//     /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
//     public bool Insert(int val) {
//         if (!this.set.Contains(val)) {
//             this.set.Add(val);
//             return true;
//         }
//         return false;
//     }
    
//     /** Removes a value from the set. Returns true if the set contained the specified element. */
//     public bool Remove(int val) {
//         if (this.set.Contains(val)) {
//             this.set.Remove(val);
//             return true;
//         }
//         return false;
//     }
    
//     /** Get a random element from the set. */
//     public int GetRandom() {
//         if (this.set.Count < 1) return 0;
//         if (this.set.Count == 2) return this.set.First();
//         var rand = new Random();
//         int randomNum = rand.Next(this.set.Count);
//         foreach(int val in this.set) {
//             if (randomNum == 0) return val;
//             randomNum--;
//         }
//         return this.set.First();
//     }
// }

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */