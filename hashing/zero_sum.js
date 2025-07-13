// User function Template for javascript

/**
 * @param {number[]} arr
 * @returns {boolean}
 */
class Solution {
    // Function to check whether there is a subarray present with 0-sum or not.
    subArrayExists(arr) {
        // code here
        var mymap = new Map();
        
        let sum = 0;
        mymap.set(0, true);
        
        for(let i = 0; i < arr.length; i++){
            sum += arr[i];
            if(mymap.has(sum)) return true;
            mymap.set(sum, true);
        }
        
        return false;
    }
}