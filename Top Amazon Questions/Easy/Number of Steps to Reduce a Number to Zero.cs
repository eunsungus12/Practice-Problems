// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/

public class Solution {
    public int NumberOfSteps(int num) {
        return NumberOfSteps(num, 0);
    }
    
    private int NumberOfSteps(int num, int counter) {
        if (num == 0) return counter;
        counter++;
        if (num % 2 == 0) return NumberOfSteps(num/2, counter);
        else return NumberOfSteps(num-1, counter);
    }
}