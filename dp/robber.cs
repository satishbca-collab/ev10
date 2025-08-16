public class Solution {
    public int Rob(int[] nums) {
        return Helper(nums, 0, 0);
    }

    private int Helper(int[] nums, int index, int money){
        if(index >= nums.Length) return money;

        return Math.Max(Helper(nums, index+1, money), Helper(nums, index+2, money + nums[index]));
    }
}

// Memo
public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        int[] memo = new int[n];
        for(int i = 0; i < memo.Length; i++){
            memo[i] = -1;
        }
        return Helper(nums, 0, memo);
    }

    private int Helper(int[] nums, int index, int[] memo){
        if(index >= nums.Length) return 0;
        if(memo[index] != -1) return memo[index];

        memo[index] = Math.Max(Helper(nums, index+1, memo), nums[index] + Helper(nums, index+2, memo));

        return memo[index];
    }
}

// Tabular
public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        int[] memo = new int[n];
        
        if(n == 1) return nums[0];

        memo[0] = nums[0];
        memo[1] = Math.Max(nums[0], nums[1]);

        for(int i = 2; i < n; i++){
            memo[i] = Math.Max(memo[i-1], memo[i-2] + nums[i]);
        }

        return memo[n-1];
    }
}

// Tab space opt
public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        
        if(n == 1) return nums[0];

        int a = nums[0];
        int b = Math.Max(nums[0], nums[1]);

        for(int i = 2; i < n; i++){
            int c = Math.Max(b, a + nums[i]);
            a = b;
            b = c;
        }

        return b;
    }
}