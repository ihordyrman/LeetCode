using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2657. Find the Prefix Common Array of Two Arrays
///     https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays
/// </summary>
public class _2657
{
    private static readonly int[] Input1 = [1, 3, 2, 4];
    private static readonly int[] Input2 = [3, 1, 2, 4];
    private static readonly int[] Input3 = [2, 3, 1];
    private static readonly int[] Input4 = [3, 1, 2];

    public static void Execute()
    {
        FindThePrefixCommonArray(Input1, Input2).Display();
        FindThePrefixCommonArray(Input3, Input4).Display();
    }

    private static int[] FindThePrefixCommonArrayLazyAttempt(int[] A, int[] B)
    {
        int[] result = new int[A.Length];
        int counter = 0;
        Dictionary<int, int> counts = [];

        for (int i = 0; i < A.Length; i++)
        {
            if (!counts.TryAdd(A[i], 1)) counter++;
            if (!counts.TryAdd(B[i], 1)) counter++;
            result[i] = counter;
        }

        return result;
    }

    private static int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int[] result = new int[A.Length];
        bool[] seen = new bool[A.Length + 1];
        int counter = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (seen[A[i]]) counter++;
            else seen[A[i]] = true;

            if (seen[B[i]]) counter++;
            else seen[B[i]] = true;

            result[i] = counter;
        }

        return result;
    }
}