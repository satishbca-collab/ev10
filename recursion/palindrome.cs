public class Solution {
    // Function to check if a string is a palindrome
    public bool isPalindrome(string s) {
        // code here
        return Helper(s, 0, s.Length-1);
    }
    
    private bool Helper(string s, int start, int end){
        if(start > end){
            return true;
        }
        if(start == end){
            return true;
        }
        
        if(s[start] != s[end]){
            return false;
        }
        
        return Helper(s, start + 1, end - 1);
    }
}