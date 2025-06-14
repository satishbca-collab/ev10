public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int result = 0;
        int[] leftMax = new int[n], rightMax = new int[n];

        for(int i = 0; i < n; i++){
            leftMax[i] = rightMax[i] = height[i];
        }

        for(int i = 1; i < n-1; i++){
            leftMax[i] = Math.Max(leftMax[i-1], leftMax[i]);
            rightMax[n-i-1] = Math.Max(rightMax[n-i], rightMax[n-i-1]);
        }

        for(int i = 1; i < n-1; i++){
            result += Math.Max(0, Math.Min(rightMax[i], leftMax[i]) - height[i]);
        }
        return result;
    }
}