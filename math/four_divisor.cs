class Solution {
    public int sumFourDivisors(int[] nums) {
        int totalSum = 0;
        for(int i = 0; i < nums.length; i++){
            int sum = 0, count = 0;
            int l = (int)Math.sqrt(nums[i]);
            for(int j = 2; j <= l; j++){
                if(nums[i]%j==0){
                    sum+=j;
                    count++;
                    int other = nums[i]/j;
                    if(other != j){
                        sum+=other;
                        count++;
                    }
                }
            }
            if(count == 2){
                totalSum += sum + 1 + nums[i];
            }
        }
        return totalSum;
    }
}