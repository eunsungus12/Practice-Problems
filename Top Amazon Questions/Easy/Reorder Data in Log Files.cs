// https://leetcode.com/problems/reorder-data-in-log-files

public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        if (logs.Length <= 1) return logs;
        List<string> digits = new List<string>();
        List<string> letters = new List<string>();

        foreach (string log in logs) {
            if (Int32.TryParse(log.Split(" ")[1][0].ToString(), out int i)) digits.Add(log);
            else letters.Add(log);
        }

        letters = MergeSort(letters);
        // letters.Sort((logA, logB) => {
        //     string leftStr = String.Join(" ", logA.Split(' ').Skip(1));
        //     string rightStr = String.Join(" ", logB.Split(' ').Skip(1));
        //     if (String.Compare(leftStr, rightStr) == 0) {
        //         return string.Compare(logA.Split(" ")[0], logB.Split(" ")[0]);
        //     }
        //     return String.Compare(leftStr, rightStr);
        // });

        return letters.Concat(digits).ToArray();
    }

    private List<string> MergeSort(List<string> logs) {
        if (logs.Count == 1) return logs;

        List<string> left = new List<string>();
        List<string> right = new List<string>();

        for (int i = 0; i < logs.Count; i++) {
            if (i < logs.Count / 2) {
                left.Add(logs[i]);
            } else {
                right.Add(logs[i]);
            }
        }

        return Merge(MergeSort(left), MergeSort(right));
    }

    private List<string> Merge(List<string> left, List<string> right) {
        int i = 0;
        int j = 0;

        List<string> result = new List<string>();

        while (i < left.Count & j < right.Count) {
            string leftStr = String.Join(" ", left[i].Split(' ').Skip(1));
            string rightStr = String.Join(" ", right[j].Split(' ').Skip(1));
            if (String.Compare(leftStr, rightStr) == -1) {
                result.Add(left[i]);
                i++;
            } else if (String.Compare(leftStr, rightStr) == 1) {
                result.Add(right[j]);
                j++;
            } else {
                if (String.Compare(left[i].Split(" ")[0], right[j].Split(" ")[0]) == -1) {
                    result.Add(left[i]);
                    i++;
                } else if (String.Compare(left[i].Split(" ")[0], right[j].Split(" ")[0]) == 1) {
                    result.Add(right[j]);
                    j++;
                } else {
                    result.Add(left[i]);
                    i++;
                    result.Add(right[j]);
                    j++;
                }
            }
        }

        while (i < left.Count) {
            result.Add(left[i]);
            i++;
        }
        while (j < right.Count) {
            result.Add(right[j]);
            j++;
        }

        return result;
    }
}