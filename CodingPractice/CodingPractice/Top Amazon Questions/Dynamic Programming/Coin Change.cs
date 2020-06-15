using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Dynamic_Programming
{
    class Coin_Change
    {
        // https://leetcode.com/problems/coin-change/

        public static int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            if (coins.Length == 0) return -1;
            var arr = new int[amount + 1];
            Array.Fill(arr, amount + 1);
            arr[0] = 0;
            Array.Sort(coins);
            for (int i = 0; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i) arr[i] = Math.Min(arr[i], 1 + arr[i-coins[j]]);
                    else break;
                }
            }
            return arr[amount] > amount ? -1 : arr[amount];
        }

        public static void Test()
        {
            Console.WriteLine("Testing Coin Change");
            int[] coins = new int[] { 1, 2, 5 };
            int amount = 11;
            Console.WriteLine("Expected: 3, Got: " + CoinChange(coins, amount).ToString());
            coins = new int[] { 2 };
            amount = 3;
            Console.WriteLine("Expected: -1, Got: " + CoinChange(coins, amount).ToString());
            coins = new int[] { 1 };
            amount = 3;
            Console.WriteLine("Expected: 3, Got: " + CoinChange(coins, amount).ToString());
            coins = new int[] { 1, 4, 5, 10 };
            amount = 13;
            Console.WriteLine("Expected: 3, Got: " + CoinChange(coins, amount).ToString());

        }
    }
}
