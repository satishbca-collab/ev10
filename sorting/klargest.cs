public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        // Find the maximum and minimum elements in the array
        int max = nums[0], min = nums[0];
        foreach (var num in nums)
        {
            if (num > max) max = num;
            if (num < min) min = num;
        }

        // Create a count array for the range min to max
        int range = max - min + 1;
        int[] count = new int[range];

        // Fill the count array with frequencies
        foreach (var num in nums)
        {
            count[num - min]++;
        }

        // Traverse the count array from the end to find the k-th largest element
        for (int i = range - 1; i >= 0; i--)
        {
            if (count[i] > 0)
            {
                k -= count[i];
                if (k <= 0)
                {
                    return i + min;
                }
            }
        }
        return -1; // k is out of bounds
    }
}