public class Solution {
    public int ClimbStairs(int n) {
        if(n <= 1) return 1;
        return ClimbStairs(n-1) + ClimbStairs(n-2);
    }
}

// Memo
public class Solution {
    public int ClimbStairs(int n) {
        int[] memo = new int[n+1];
        memo[0] = 1; 
        memo[1] = 1;
        Helper(n, memo);
        return memo[n];
    }

    private void Helper(int n, int[] memo){
        if(memo[n] != 0) {
            return;
        }
        Helper(n-1, memo);
        Helper(n-2, memo);
        memo[n] = memo[n-1] + memo[n-2];
    }
}

// Tabulation
public class Solution {
    public int ClimbStairs(int n) {
        int[] memo = new int[n+1];
        memo[0] = 1; 
        memo[1] = 1;
        for(int i = 2; i <= n; i++){
            memo[i] = memo[i-1] + memo[i-2];
        }
        return memo[n];
    }
}

// Tab - space optimized
public class Solution {
    public int ClimbStairs(int n) {
        int a = 1; 
        int b = 1;
        for(int i = 2; i <= n; i++){
            int sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }
}