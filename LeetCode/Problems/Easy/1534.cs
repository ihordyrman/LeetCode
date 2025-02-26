using LeetCode.Generators;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1534. Count Good Triplets
///     https://leetcode.com/problems/count-good-triplets/
/// </summary>
public class _1534
{
    private static readonly (int[] arr, int a, int b, int c) Input = ([3, 0, 1, 1, 9, 7], 7, 2, 3);

    [BenchmarkGen]
    public void CountGoodTriplets() => CountGoodTriplets(Input.arr, Input.a, Input.b, Input.c);

    private static int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        if (arr.Length < 3)
        {
            return 0;
        }

        var triplets = 0;

        for (var i = 0; i < arr.Length; i++)
        for (int j = i + 1; j < arr.Length; j++)
        for (int k = j + 1; k < arr.Length; k++)
        {
            if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)
            {
                triplets++;
            }
        }

        return triplets;
    }
}
