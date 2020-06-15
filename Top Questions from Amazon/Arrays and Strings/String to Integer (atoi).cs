// https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2962/

public class Solution {
	public int MyAtoi(string str) {
		str.Trim();
		if (str.Length == 0) return 0;
        int i = 0;
		if (str.Substring(1) != "-" && int.TryParse(str.Substring(0, 1), out i) == false) return 0;
		if (str.Remove(0, 1) == "-") {
			string[] arr = str.Split(" ");
			if (int.TryParse(arr[0].Substring(1), out i)) {
				if (String.Compare(arr[0], Int32.MinValue.ToString(), StringComparison.OrdinalIgnoreCase) >= 0) {
					int val = 0;
					Int32.TryParse(arr[0], out val);
					return val;
				}
				return Int32.MinValue;
			}
		} else {
			string[] arr = str.Split(" ");
			if (int.TryParse(arr[0].Substring(1), out i)) {
				Console.WriteLine(String.Compare(arr[0], Int32.MaxValue.ToString(), StringComparison.OrdinalIgnoreCase));
				if (String.Compare(arr[0], Int32.MaxValue.ToString(), StringComparison.OrdinalIgnoreCase) < 0) {
					int val = 0;
					Int32.TryParse(arr[0], out val);
					return val;
				}
				return Int32.MaxValue-1;
			}
		}
		return 0;
	}
}
	public int MyAtoi(string str) {
		str.Trim();
		if (str.Length == 0) return 0;
		if (str.Substring(1) != "-" && int.TryParse(str.Substring(1, 1)) == false) return 0;
		if (str.Remove(0, 1) == "-") {
			string[] arr = str.split(" ");
			int i = 0;
			if (int.TryParse(arr[0].Substring(1), out i)) {
				if (arr[0] >= Int32.MinValue.ToString()) {
					int val = 0;
					Int32.TryParse(arr[0], val);
					return val;
				}
				return Int32.MinValue;
			}
		} else {
			string[] arr = str.split(" ");
			int i = 0;
			if (int.TryParse(arr[0].Substring(1), out i)) {
				if (arr[0] < Int32.MaxValue) {
					int val = 0;
					Int32.TryParse(arr[0], val);
					return val;
				}
				return Int32.MaxValue-1;
			}
		}
		return 0;
	}