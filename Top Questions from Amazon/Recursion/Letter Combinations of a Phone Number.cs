// https://leetcode.com/explore/interview/card/amazon/84/recursion/521/

public class Solution {
    public IList<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        if (digits.Length == 0) return result;
        Backtrack("", digits, result);
        return result;
    }

    public void Backtrack(string combination, string digits, List<string> result) {
        if (digits.Length == 0) {
            result.Add(combination);
        } else {
            string firstDigit = digits.Substring(0,1);
            if (Int32.TryParse(firstDigit, out int num)) {
                string letters = GetTelephone()[firstDigit];
                foreach(char letter in letters) {
                    Backtrack(combination + letter.ToString(), digits.Substring(1, digits.Length-1), result);
                }
            }
        }
    }

    private Dictionary<string, string> GetTelephone() {
        Dictionary<string, string> tel = new Dictionary<string, string>();
        tel.Add("2", "abc");
        tel.Add("3", "def");
        tel.Add("4", "ghi");
        tel.Add("5", "jkl");
        tel.Add("6", "mno");
        tel.Add("7", "pqrs");
        tel.Add("8", "tuv");
        tel.Add("9", "wxyz");
        return tel;
    }
}

// Leetcode Solution
    // public IList<string> LetterCombinations(string digits) {
    //     if (digits.Length == 0) return new List<string>();
    //     List<string> result = new List<string>();
    //     Backtrack("", digits, result);
    //     return result;
    // }

    // public void Backtrack(string combo, string digits, List<string> result) {
    //     if (digits.Length == 0) {
    //         result.Add(combo);
    //     } else {
    //         string digit = digits.Substring(0, 1);
    //         string letters = GetTelephone()[digit];
    //         foreach(var s in letters) {
    //             Backtrack(combo + s.ToString(), digits.Substring(1), result);
    //         }
    //     }
    // }