public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] result = new int[n][];
        for(int i = 0; i < n; i++){
            result[i] = new int[n];
        }
        int[] dr = [0,1,0,-1];
        int[] dc = [1,0,-1,0];
        int dir = 0;
        int row = 0, col = 0;
        for(int i = 1; i <= n*n; i++){
            result[row][col] = i;

            int nextRow = row + dr[dir];
            int nextCol = col + dc[dir];

            if(nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n || result[nextRow][nextCol] != 0){
                dir = (dir + 1) % 4;
                nextRow = row + dr[dir];
                nextCol = col + dc[dir];
            }

            row = nextRow;
            col = nextCol;
        }
        return result;
    }
}