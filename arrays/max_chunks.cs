public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int i = m - 1, j = 0;
        while(i >= 0 && j < n){
            if(matrix[i][j] == target){
                return true;
            }
            else if(matrix[i][j] > target){
                i--;
            }
            else {
                j++;
            }
        }
        return false;
    }
}