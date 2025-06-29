public class Solution {
    public int FindMin(int[] nums) {
        return helper(nums, 0, nums.Length-1);
    }

    private int helper(int[] nums, int l, int r){
        while(l < r){
            int m = l + (r-l)/2;
            if(nums[m] > nums[r]){
                l = m + 1;
            }
            else {
                r = m;
            }
        }
        return nums[l];
    }
}