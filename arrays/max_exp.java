// User function Template for Java
class Solution {
    // Function to find the maximum value of the given expression.
    public int maxValueOfExpression(int[] arr) {
        // Write Code Here
        int n = arr.length;
        int[] sum = new int[n];
        int[] diff = new int[n];
        int result = Integer.MIN_VALUE;
        for(int i = 0; i < n; i++){
            sum[i] = arr[i] + i;
            diff[i] = arr[i] - i;
        }
        
        int min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
        for(int i = 0; i < n; i++){
            min = Math.min(min, sum[i]);
            max = Math.max(max, sum[i]);
        }
        result = Math.max(result, max-min);
        
        min = Integer.MAX_VALUE; max = Integer.MIN_VALUE;
        for(int i = 0; i < n; i++){
            min = Math.min(min, diff[i]);
            max = Math.max(max, diff[i]);
        }
        result = Math.max(result, max-min);
        
        return result;
    }
}