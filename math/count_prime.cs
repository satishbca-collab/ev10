public class Solution {
    public int CountPrimes(int n) {
        bool[] prime = Enumerable.Repeat(true, n).ToArray();

        for(int i = 2; i*i < n; i++){
            if(prime[i] == false) continue;

            int current = i+i;
            while(current < n){
                prime[current] = false;
                current = current+i;
            }
        }
        int count = 0;
        for(int i = 2; i < n; i++){
            if(prime[i]){
                count++;
            }
        }

        return count;
    }
}