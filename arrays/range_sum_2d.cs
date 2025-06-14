public class NumMatrix {
    int[][] arr;
    
    public NumMatrix(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return;
        }
        
        int m = matrix.Length, n = matrix[0].Length;
        arr = new int[m][];
        
        // Initialize the array with proper dimensions
        for (int i = 0; i < m; i++) {
            arr[i] = new int[n];
            for (int j = 0; j < n; j++) {
                arr[i][j] = matrix[i][j];
            }
        }

        // Build prefix sum for first row
        for (int j = 1; j < n; j++) {
            arr[0][j] += arr[0][j-1];
        }

        // Build prefix sum for first column
        for (int i = 1; i < m; i++) {
            arr[i][0] += arr[i-1][0];
        }

        // Build prefix sum for the rest of the matrix
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                arr[i][j] += arr[i-1][j] + arr[i][j-1] - arr[i-1][j-1];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        if (arr == null) return 0;
        
        int res = arr[row2][col2];
        if (row1 > 0) {
            res -= arr[row1-1][col2];
        }
        if (col1 > 0) {
            res -= arr[row2][col1-1];
        }
        if (row1 > 0 && col1 > 0) {
            res += arr[row1-1][col1-1];
        }
        return res;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */