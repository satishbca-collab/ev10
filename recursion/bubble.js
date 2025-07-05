/**
 * @param {number[]} nums
 * @return {number[]}
 */
var sortArray = function(nums) {
    Helper(nums, 0);
    return nums;
};

function Helper(arr, incr){
    const n = arr.length;
    if(incr >= n) return;

    for(let i = 0; i < n - incr; i++){
        if(arr[i] > arr[i+1]){
            swap(arr, i, i + 1);
        }
    }
    Helper(arr, incr + 1)
}

function swap(arr, i, j){
    const temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}