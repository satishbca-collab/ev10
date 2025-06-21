public class Solution {
    public bool CanArrange(int[] arr, int k) {
        int[] hash = new int[k];
        for(int i = 0; i < arr.Length; i++){
            int index = ((arr[i] % k) + k) % k;
            hash[index]++;
        }
        if(hash[0] % 2 != 0){
            return false;
        }
        for(int i = 1; i < k; i++){
            if(hash[i]!= hash[k-i]){
                return false;
            }
        }
        return true;
    }
}