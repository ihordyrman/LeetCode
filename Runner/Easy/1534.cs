using Xunit;

namespace Runner.Easy;

/// <summary>
///     1534. Count Good Triplets
///     https://leetcode.com/problems/count-good-triplets/
/// </summary>
public class _1534
{
    public _1534()
    {
        Assert.Equal(CountGoodTriplets(new[] { 3, 0, 1, 1, 9, 7 }, 7, 2, 3), 4);
        Assert.Equal(CountGoodTriplets(new[] { 1, 1, 2, 2, 3 }, 0, 0, 1), 0);
    }

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
