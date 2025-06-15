/**
 * The Rand7() API is already defined in the parent class SolBase.
 * public int Rand7();
 * @return a random integer in the range 1 to 7
 */
public class Solution : SolBase {
    public int Rand10() {
        while (true)
        {
            // Generate a number in the range [1, 49]
            int num = (Rand7() - 1) * 7 + Rand7();
            // If num is between 1 and 40, it can be evenly mapped to 1-10.
            if (num <= 40)
            {
                // Map num from [1, 40] to [1, 10] uniformly.
                return 1 + (num) % 10;
            }
            // Otherwise, reject num and try again.
        }
    }
}