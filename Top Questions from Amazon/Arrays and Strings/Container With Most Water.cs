public class Solution {
    public int MaxArea(int[] height) {
        if (height.Length <= 1) return 0;
        
        // Declare Variables
        int highVal = 0;
        int lowVal = 0;

        for (int i = 1; i < height.Length; i++) {
            if (height[i] >= height[highVal]) {
                lowVal = highVal;
                highVal = i;
                continue;
            }
            if (height[i] >= height[lowVal]) {
                lowVal = i;
                continue;
            }
        }

        if (highVal != lowVal) {
            return height[highVal] * height[lowVal];
        }
        return 0;
    }
}