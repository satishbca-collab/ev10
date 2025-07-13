/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function(s) {
    let maxlen = 0, start = 0;
    const n = s.length;
    var mymap = new Map();
    
    for(let end = 0; end < n; end++){
        while(mymap.has(s[end])){
            mymap.delete(s[start]);
            start++;
        }
        mymap.set(s[end], true);
        const cur = end - start + 1;
        if(cur > maxlen) maxlen = cur;
    }

    return maxlen;
};