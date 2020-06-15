// https://leetcode.com/problems/top-k-frequent-words/

public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++) {
            if(dict.ContainsKey(words[i])) dict[words[i]] += 1;
            else dict.Add(words[i], 1);
        }
        
        SortedDictionary<int, List<string>> newDict = new SortedDictionary<int, List<string>>();
        foreach(KeyValuePair<string, int> pair in dict) {
            if (newDict.ContainsKey(pair.Value)) newDict[pair.Value].Add(pair.Key);
            else newDict.Add(pair.Value, new List<string>() {pair.Key});
        }


        int iter = 0;
        IList<string> result = new List<string>();
        foreach(KeyValuePair<int, List<string>> pair in newDict.Reverse()) {
            pair.Value.Sort((a, b) => a.CompareTo(b));
            pair.Value.ForEach(word => {
                if (iter < k) result.Add(word);
                iter++;
            });
        }

        return result;
    }
}