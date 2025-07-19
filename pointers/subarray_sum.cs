/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraySum = function(nums, k) {
    const prefixMap = new Map();
    let sum = 0, count = 0;
    prefixMap.set(0, 1);

    for(let i = 0; i < nums.length; i++){
        sum += nums[i];

        if(prefixMap.has(sum - k)){
            count += prefixMap.get(sum - k);
        }
        
        prefixMap.set(sum, (prefixMap.get(sum) || 0) + 1);
        
    }
    return count;
};