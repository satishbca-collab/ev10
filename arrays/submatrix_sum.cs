using System;
 
namespace SubmatrixSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test with example matrix
            int[,] matrix = {
                {1, 2},
                {3, 4}
            };
            
            Console.WriteLine("Matrix:");
            PrintMatrix(matrix);
            
            Console.WriteLine("\n=== Solution Comparison ===");
            
            long result1 = SumAllSubmatrices_BruteForce(matrix);
            Console.WriteLine($"Brute Force Result: {result1}");
            
            long result2 = SumAllSubmatrices_PrefixSum(matrix);
            Console.WriteLine($"Prefix Sum Result: {result2}");
            
            long result3 = SumAllSubmatrices_Optimal(matrix);
            Console.WriteLine($"Optimal Result: {result3}");
            
            // Verify all results match
            Console.WriteLine($"\nAll results match: {result1 == result2 && result2 == result3}");
        }
        
        // Stage 1: Brute Force Approach
        // Time Complexity: O(m³n³), Space Complexity: O(1)
        static long SumAllSubmatrices_BruteForce(int[,] matrix)
        {
            int m = matrix.GetLength(0); // rows
            int n = matrix.GetLength(1); // columns
            long totalSum = 0;
            
            // Choose all possible top-left corners
            for (int top = 0; top < m; top++)
            {
                for (int left = 0; left < n; left++)
                {
                    // Choose all possible bottom-right corners
                    for (int bottom = top; bottom < m; bottom++)
                    {
                        for (int right = left; right < n; right++)
                        {
                            // Calculate sum of current submatrix
                            long submatrixSum = 0;
                            for (int i = top; i <= bottom; i++)
                            {
                                for (int j = left; j <= right; j++)
                                {
                                    submatrixSum += matrix[i, j];
                                }
                            }
                            totalSum += submatrixSum;
                        }
                    }
                }
            }
            
            return totalSum;
        }
        
        // Stage 2: Optimization with Prefix Sums
        // Time Complexity: O(m²n²), Space Complexity: O(mn)
        static long SumAllSubmatrices_PrefixSum(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            
            // Build 2D prefix sum array
            long[,] prefix = new long[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    prefix[i, j] = matrix[i - 1, j - 1] + 
                                  prefix[i - 1, j] + 
                                  prefix[i, j - 1] - 
                                  prefix[i - 1, j - 1];
                }
            }
            
            long totalSum = 0;
            
            // Generate all submatrices
            for (int top = 0; top < m; top++)
            {
                for (int left = 0; left < n; left++)
                {
                    for (int bottom = top; bottom < m; bottom++)
                    {
                        for (int right = left; right < n; right++)
                        {
                            // O(1) submatrix sum calculation
                            long submatrixSum = prefix[bottom + 1, right + 1] - 
                                              prefix[top, right + 1] - 
                                              prefix[bottom + 1, left] + 
                                              prefix[top, left];
                            totalSum += submatrixSum;
                        }
                    }
                }
            }
            
            return totalSum;
        }
        
        // Stage 3: Optimal Mathematical Solution
        // Time Complexity: O(mn), Space Complexity: O(1)
        static long SumAllSubmatrices_Optimal(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            long totalSum = 0;
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Count how many submatrices contain element (i,j)
                    // Top-left corners: (i+1) * (j+1) possibilities
                    // Bottom-right corners: (m-i) * (n-j) possibilities
                    long count = (long)(i + 1) * (j + 1) * (m - i) * (n - j);
                    totalSum += matrix[i, j] * count;
                }
            }
            
            return totalSum;
        }
        
        // Helper method to print matrix
        static void PrintMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            
            for (int i = 0; i < m; i++)
            {
                Console.Write("[");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j < n - 1) Console.Write(", ");
                }
                Console.WriteLine("]");
            }
        }
        
        // Method to demonstrate the counting logic for a specific element
        static void ExplainElementContribution(int[,] matrix, int row, int col)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            
            Console.WriteLine($"\nAnalyzing element at position ({row}, {col}) = {matrix[row, col]}");
            Console.WriteLine($"Matrix dimensions: {m}x{n}");
            
            int topLeftCount = (row + 1) * (col + 1);
            int bottomRightCount = (m - row) * (n - col);
            long totalSubmatrices = (long)topLeftCount * bottomRightCount;
            long contribution = matrix[row, col] * totalSubmatrices;
            
            Console.WriteLine($"Possible top-left corners: ({row + 1}) * ({col + 1}) = {topLeftCount}");
            Console.WriteLine($"Possible bottom-right corners: ({m - row}) * ({n - col}) = {bottomRightCount}");
            Console.WriteLine($"Total submatrices containing this element: {totalSubmatrices}");
            Console.WriteLine($"Element's contribution to total sum: {matrix[row, col]} * {totalSubmatrices} = {contribution}");
        }
    }
    
    // Alternative implementation using jagged arrays (more common in C#)
    class AlternativeImplementation
    {
        static long SumAllSubmatrices_Optimal_JaggedArray(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            long totalSum = 0;
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Count submatrices containing element (i,j)
                    long count = (long)(i + 1) * (j + 1) * (m - i) * (n - j);
                    totalSum += matrix[i][j] * count;
                }
            }
            
            return totalSum;
        }
        
        // Generic version for different numeric types
        static T SumAllSubmatrices_Generic<T>(T[,] matrix) where T : struct, IComparable<T>
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            dynamic totalSum = default(T);
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    long count = (long)(i + 1) * (j + 1) * (m - i) * (n - j);
                    totalSum += (dynamic)matrix[i, j] * count;
                }
            }
            
            return totalSum;
        }
    }
}
