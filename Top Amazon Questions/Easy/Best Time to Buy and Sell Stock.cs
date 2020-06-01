// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 0) return 0;
        int runningTotal = 0;
        int minValue = Int32.MaxValue;

        for (int i = 0; i < prices.Length; i++) {
            minValue = Math.Min(minValue, prices[i]);
            runningTotal = Math.Max(runningTotal, prices[i] - minValue);
        }

        return runningTotal;
    }
}