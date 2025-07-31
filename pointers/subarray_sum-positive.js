/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraySum = function(nums, k) {
    let left = 0, sum = 0, n = nums.length, count = 0;
    for(let right = 0; right < nums.length; right++){
        sum += nums[right];

        while(sum > k && left < right){
            sum -= nums[left];
            left++;
        }

        if(sum == k){
            count++;
        }
    }
    return count;
};