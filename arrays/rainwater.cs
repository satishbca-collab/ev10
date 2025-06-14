public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int result = 0;

        for(int i = 1; i < n-1; i++){
            int leftmax = height[i];
            for(int left = i-1; left >= 0; left--){
                leftmax = Math.Max(leftmax, height[left]);
            }
            int rightmax = height[i];
            for(int right = i+1; right < n; right++){
                rightmax = Math.Max(rightmax, height[right]);
            }

            result += Math.Max(0, Math.Min(rightmax, leftmax) - height[i]);
        }

        return result;
    }
}