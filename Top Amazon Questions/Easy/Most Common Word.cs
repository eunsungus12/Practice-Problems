// https://leetcode.com/problems/most-common-word/

public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        // Trim paragraph
        paragraph = paragraph.ToLower();
        paragraph = Regex.Replace(paragraph, @"(\p{P})", " ");
        paragraph = Regex.Replace(paragraph, @"\s+", " ");

        // If empty paragraph, return
        if (paragraph.Split(' ').Length <= 1) return paragraph;

        // Declare variables
        // banned array to hashset for quick lookups
        HashSet<string> hs = new HashSet<string>(banned);
        Dictionary<string, int> dict = new Dictionary<string, int>();
        // To not have to loop through dictionary later
        int highestCount = Int32.MinValue;
        string mostFreqWord = "";

        // Loop through each word and store frequency
        foreach(string s in paragraph.Split(' ')) {
            if (hs.Contains(s)) continue;
            if (!dict.ContainsKey(s)) {
                dict.Add(s, 1);
            } else {
                dict[s] += 1;
            }
            if (dict[s] > highestCount) {
                highestCount = dict[s];
                mostFreqWord = s;
            }
        }
        return mostFreqWord;
    }
}