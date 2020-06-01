// https://leetcode.com/problems/lru-cache/

public class LRUCache {

    Dictionary<int, int> dict = new Dictionary<int, int>();

    public LRUCache(int capacity) {
        int capacity = capacity;
    }
    
    public int Get(int key) {
        if (this.dict.ContainsKey(key)) {
            // TO DO: update least recently used

            return this.dict[key];
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        if (this.dict.ContainsKey(key)) {
            this.dict[key] = value;
        } else {
            if (this.dict.Count < this.capacity) {
                this.dict.Add(key, value);
            }
            // TO DO: remove least recently used and add dictionary then update least recently used

        }
    }

    private void UpdateLRU(int key) {
        
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */