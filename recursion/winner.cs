public class Solution {
    public bool PredictTheWinner(int[] nums)
    {
        int scoreDiff = GetScoreDifference(nums, 0, nums.Length - 1);
        return scoreDiff >= 0; // If Player 1 can secure at least a tie
    }

    private int GetScoreDifference(int[] nums, int left, int right)
    {
        if (left == right)
        {
            return nums[left]; // Base case: only one element left
        }

        // Player 1 chooses either left or right
        int pickLeft = nums[left] - GetScoreDifference(nums, left + 1, right);
        int pickRight = nums[right] - GetScoreDifference(nums, left, right - 1);

        // Maximize Player 1's advantage
        return Math.Max(pickLeft, pickRight);
    }
}