// User function Template for Java
class Solution {
    // Function to find the maximum value of the given expression.
    public int maxValueOfExpression(int[] arr) {
        // Write Code Here
        int n = arr.length;
        int result = 0;
        
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                int currentResult = Math.abs(arr[i] - arr[j]) + Math.abs(i-j);
                result = Math.max(result, currentResult);
            }
        }
        
        return result;
    }
}