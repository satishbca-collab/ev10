/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    const hash = [];
    for(let i = 0; i < nums.length; i++){
        const key = target - nums[i];
        if(hash[key] !== undefined){
            return [i, hash[key]];
        }
        hash[nums[i]] = i;
    }
};