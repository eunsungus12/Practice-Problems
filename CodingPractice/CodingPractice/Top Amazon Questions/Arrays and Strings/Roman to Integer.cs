using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Roman_to_Integer
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2965/

        public static int RomanToInt(string s)
		{
			if (s == "") return 0;
			string firstChar = s[0].ToString();
			string firstTwo = s.Length > 1 ? firstChar + s[1].ToString() : "";
			string sO = s.Length > 1 ? s.Substring(1, s.Length - 1) : "";
			string sT = s.Length > 2 ? s.Substring(2, s.Length - 2) : "";
			if (firstChar == "M") return 1000 + RomanToInt(sO);
			if (firstTwo == "CM") return 900 + RomanToInt(sT);
			if (firstChar == "D") return 500 + RomanToInt(sO);
			if (firstTwo == "CD") return 400 + RomanToInt(sT);
			if (firstChar == "C") return 100 + RomanToInt(sO);
			if (firstTwo == "XC") return 90 + RomanToInt(sT);
			if (firstChar == "L") return 50 + RomanToInt(sO);
			if (firstTwo == "XL") return 40 + RomanToInt(sT);
			if (firstChar == "X") return 10 + RomanToInt(sO);
			if (firstTwo == "IX") return 9 + RomanToInt(sT);
			if (firstChar == "V") return 5 + RomanToInt(sO);
			if (firstTwo == "IV") return 4 + RomanToInt(sT);
			return 1 + RomanToInt(sO);
		}
		public static void Test()
		{
			Console.WriteLine("Testing Roman to Integer");
			string s = "III";
			Console.WriteLine("Expected: 3, Got: " + RomanToInt(s));
			s = "IV";
			Console.WriteLine("Expected: 4, Got: " + RomanToInt(s));
			s = "IX";
			Console.WriteLine("Expected: 9, Got: " + RomanToInt(s));
			s = "LVIII";
			Console.WriteLine("Expected: 58, Got: " + RomanToInt(s));
		}
	}
}
