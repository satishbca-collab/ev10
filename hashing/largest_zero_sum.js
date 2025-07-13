/**
 * @param {Number[]} arr
 * @returns {Number}
 */
class Solution {
    maxLength(arr) {
        // code here
        var mymap = new Map();
        
        let sum = 0;
        let maxLen = 0;
        
        for(let i = 0; i < arr.length; i++){
            sum += arr[i];
            
            if(mymap.has(sum)){
                maxLen = Math.max(maxLen, i - mymap.get(sum));
            }
            else if(sum === 0){
                maxLen = Math.max(maxLen, i + 1);
            }
            else {
                mymap.set(sum, i);
            }
        }
        
        return maxLen;
    }
}