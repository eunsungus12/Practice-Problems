using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions
{
    class Integer_to_Roman
    {
		// https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2964/

		public static string IntToRoman(int num)
		{
			if (num == 0) return "";
			Dictionary<int, string> dict = new Dictionary<int, string>() { { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" }, { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" } };
			List<int> list = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
			string result = "";
			while (num != 0)
			{
				for (int i = 0; i < list.Count; i++) {
					if (num >= list[i])
					{
						result += dict[list[i]];
						num -= list[i];
						break;
					}
				}
			}
			return result;
		}

			// Seems a little brute force to me but it works very fast
   //     public static string IntToRoman(int num)
   //     {
			//if (num == 0) return "";
			//if (num >= 1000) return "M" + IntToRoman(num - 1000);
			//if (num >= 900) return "CM" + IntToRoman(num - 900);
			//if (num >= 500) return "D" + IntToRoman(num - 500);
			//if (num >= 400) return "CD" + IntToRoman(num - 400);
			//if (num >= 100) return "C" + IntToRoman(num - 100);
			//if (num >= 90) return "XC" + IntToRoman(num - 90);
			//if (num >= 50) return "L" + IntToRoman(num - 50);
			//if (num >= 40) return "XL" + IntToRoman(num - 40);
			//if (num >= 10) return "X" + IntToRoman(num - 10);
			//if (num >= 9) return "IX" + IntToRoman(num - 9);
			//if (num >= 5) return "V" + IntToRoman(num - 5);
			//if (num >= 4) return "IV" + IntToRoman(num - 4);
			//return "I" + IntToRoman(num - 1);
   //     }

		public static void Test()
		{
			Console.WriteLine("Testing Word Break");
			int s = 3;
			Console.WriteLine("Expected: III, Got: " + IntToRoman(s));
			s = 4;
			Console.WriteLine("Expected: IV, Got: " + IntToRoman(s));
			s = 9;
			Console.WriteLine("Expected: IX, Got: " + IntToRoman(s));
			s = 58;
			Console.WriteLine("Expected: LVIII, Got: " + IntToRoman(s));
		}
	}
}
