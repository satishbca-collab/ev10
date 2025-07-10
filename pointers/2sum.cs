/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    const hash = [];
    for(let i = 0; i < nums.length; i++){
        hash.push([i, nums[i]]);
    }

    hash.sort((a,b) => a[1] - b[1]);

    let i = 0, j = nums.length - 1;
    while (i < j){
        if(hash[i][1] + hash[j][1] == target){
            return [hash[i][0], hash[j][0]];
        }
        else if(hash[i][1] + hash[j][1] > target){
            j--;
        }
        else {
            i++;
        }
    }
};