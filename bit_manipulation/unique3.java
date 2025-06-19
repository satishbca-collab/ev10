// User function Template for Java

class Solution {
    public int getSingle(int[] arr) {
        // code here
        int result = 0;
        for(int i = 0; i < 32; i++){
            int count = 0;
            for(int val : arr){
                int bit = ((val >> i) & 1);
                if(bit == 1){
                    count++;
                }
            }
            if(count % 3 != 0){
                result = result | (1 << i);
            }
        }
        return result;
    }
}