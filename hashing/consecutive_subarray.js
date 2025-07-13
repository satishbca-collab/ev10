// User function Template for javascript
class Solution {
    areConsecutives(arr) {
        // Your code goes here
        const n = arr.length;
        
        let max = arr[0], min = arr[0];
        
        for(let i = 0; i < n; i++){
            if(max < arr[i]) max = arr[i];
            if(min > arr[i]) min = arr[i];
        }
        
        const range = max - min + 1;
        
        if(range !== n) return false;
        
        var mymap = new Map();
        
        for(let i = 0; i < n; i++){
            if(mymap.has(arr[i])) return false;
            
            mymap.set(arr[i], true);
        }
        
        return true;
    }
}