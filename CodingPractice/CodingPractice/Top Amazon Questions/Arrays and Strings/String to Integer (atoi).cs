using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingPractice.Top_Amazon_Questions
{
    class String_to_Integer__atoi_
    {
		// https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2962/

		public static int MyAtoi(string str)
		{
			str = str.Trim();
			if (str.Length == 0 || str == "") return 0;
			int i = 0;
			if (Int32.TryParse(str, out i)) return i;
			if (Int32.TryParse(str.Split(' ')[0], out i)) return i;
			string firstWord = str.Split(' ')[0];
			Regex rgx = new Regex(@"^\d+$");
			if (firstWord[0] == '-')
			{
				string sub = "-";
				for (int j = 1; j <= firstWord.Length-1; j++)
				{
					if (rgx.IsMatch(firstWord.Substring(1, j)))
					{
						sub += firstWord[j];
					}
					else break;
				}
				if (sub != "-" && Int32.TryParse(sub, out i)) return i;
				if (sub != "-") return Int32.MinValue;
			} else
			{
				if (firstWord[0] == '+') firstWord = firstWord.Substring(1, firstWord.Length - 1);
				string sub = "";
				for (int j = 1; j <= firstWord.Length; j++)
				{
					if (rgx.IsMatch(firstWord.Substring(0, j)))
					{
						sub += firstWord[j-1];
					}
					else break;
				}
				if (sub != "" && Int32.TryParse(sub, out i)) return i;
				if (sub != "")
				{
					return Int32.MaxValue;
				}
			}
			return 0;
		}
		public static void Test()
		{
			Console.WriteLine("Testing Word Break");
			string s = "42";
			//Console.WriteLine("Expected: 42, Got: " + MyAtoi(s).ToString());
			//s = "   -42";
			//Console.WriteLine("Expected: -42, Got: " + MyAtoi(s).ToString());
			//s = "4193 with words";
			//Console.WriteLine("Expected: 4193, Got: " + MyAtoi(s).ToString());
			//s = "words and 987";
			//Console.WriteLine("Expected: 0, Got: " + MyAtoi(s).ToString());
			//s = "-91283472332";
			//Console.WriteLine("Expected: -2147483648, Got: " + MyAtoi(s).ToString());
			s = "3.14159";
			Console.WriteLine("Expected: 3, Got: " + MyAtoi(s).ToString());
			s = "-3.14159";
			Console.WriteLine("Expected: -3, Got: " + MyAtoi(s).ToString());
			s = " ";
			Console.WriteLine("Expected: 0, Got: " + MyAtoi(s).ToString());
			s = "+11e530408314";
			Console.WriteLine("Expected: 11, Got: " + MyAtoi(s).ToString());
		}
	}
}
