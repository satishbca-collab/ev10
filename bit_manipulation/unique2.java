class Solution {
    public int[] singleNum(int[] arr) {
        // Code here
        int n = arr.length, xor = 0;
        for(int i = 0; i < n; i++){
            xor = xor ^ arr[i];
        }
        
        int index = -1;
        for(int i = 0; i < 32; i++){
            if(((xor >> i) & 1) == 1){
                index = i;
                break;
            }
        }
        
        ArrayList<Integer> list1 = new ArrayList<>();
        ArrayList<Integer> list2 = new ArrayList<>();
        
        for(int i = 0; i < n; i++){
            if(((arr[i] >> index) & 1) == 1){
                list1.add(arr[i]);
            }
            else {
                list2.add(arr[i]);
            }
        }
        
        int x = 0, y = 0;
        
        for(Integer num : list1){
            x = x ^ num;
        }
        
        for(Integer num : list2){
            y = y ^ num;
        }
        int[] result = {x,y};
        Arrays.sort(result);
        return result;
    }
}