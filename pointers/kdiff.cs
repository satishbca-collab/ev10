/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var findPairs = function(nums, k) {
    nums.sort((a,b) => a - b);
    let i = 0, j = 1, count = 0, n = nums.length;
    while(j < n){
        if(nums[j] - nums[i] < k || i >= j){
            j++;
        }
        else if(nums[j] - nums[i] > k){
            i++;
        }
        else {
            i++;
            j++;
            count++;
            while(nums[i] == nums[i-1] && i < n){
                i++;
            }
        }
    }
    return count;
};