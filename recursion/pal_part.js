/**
 * @param {string} s
 * @return {string[][]}
 */
var partition = function(s) {
    const n = s.length;
    const result = [];
    Helper(s, 0, result, []);
    return result;    
};

function Helper(s, index, result, cur){
    const n = s.length;
    if(index == s.length){
        result.push([...cur]);
        return;
    }

    for(let i = index; i < n; i++){
        const sub = s.substring(index, i+1);
        if(isPalindrome(sub)){
            cur.push(sub);
            Helper(s, i + 1, result, cur);
            cur.pop();
        }
    }
}

function isPalindrome(str){
    const n = str.length;
    if(n===1) return true;

    for(let i = 0; i < n/2; i++){
        if(str[i] !== str[n-i-1]) return false;
    }

    return true;
}