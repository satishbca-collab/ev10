public class Solution {
    public uint reverseBits(uint n) {
        uint result = 0;
        int p = 31;
        // while( n > 0){
        //     uint rem = n % 2;
        //     result += (uint)(rem * Math.Pow(2, p));
        //     n = n/2;
        //     p--;
        // }
        // return result;

        while( n > 0){
            uint rem = n & 1;
            result = result | (rem << p);
            p--;
            n = n >> 1;
        }
        return result;
    }
}