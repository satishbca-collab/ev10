class Solution {
    public int findUnique(int[] arr) {
        // code here
        int result = 0;
        for(int i = 0; i < arr.length; i++){
            result = result ^ arr[i];
        }
        return result;
    }
}