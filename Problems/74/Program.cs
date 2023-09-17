using System.Linq;
using Xunit;

namespace _74;

/// <summary>
///     74. Search a 2D Matrix
///     https://leetcode.com/problems/search-a-2d-matrix/
/// </summary>
internal static class Program
{
    private static void Main()
    {
        int[][] matrix = new[]
        {
            new[] { 1, 3, 5, 7 },
            new[] { 10, 11, 16, 20 },
            new[] { 23, 30, 34, 50 }
        };

        Assert.True(SearchMatrix(matrix, 3));
        Assert.True(SearchMatrixLinq(matrix, 20));
        Assert.True(SearchMatrixBinary(matrix, 10));
        Assert.False(SearchMatrixBinary(matrix, 12));
    }

    // Runtime: 96 ms, faster than 59.09% of C#
    private static bool SearchMatrix(int[][] matrix, int target)
    {
        foreach (int[] arr in matrix)
        foreach (int i in arr)
        {
            if (i == target)
            {
                return true;
            }
        }

        return false;
    }

    // Runtime: 108 ms, faster than 5.04% of C# lol
    private static bool SearchMatrixLinq(int[][] matrix, int target)
        => matrix.SelectMany(arr => arr).Any(x => x == target);

    // Runtime: 92 ms, faster than 82.06% of C#
    private static bool SearchMatrixBinary(int[][] matrix, int target)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return false;
        }

        if (matrix.Length == 1 && matrix[0].Length == 1)
        {
            return matrix[0][0] == target;
        }

        foreach (int[] arr in matrix)
        {
            if (arr.Length == 0 || arr[arr.Length - 1] < target)
            {
                continue;
            }

            var min = 0;
            int max = arr.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (target == arr[mid])
                {
                    return true;
                }

                if (target < arr[mid])
                {
                    max = --mid;
                }
                else
                {
                    min = ++mid;
                }
            }
        }

        return false;
    }
}
