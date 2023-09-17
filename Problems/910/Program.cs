using System;
using Xunit;

namespace _910;

internal static class Program
{
    private static void Main()
    {
        Assert.Equal(SmallestRangeII(new[] { 1, 7, 3, 5 }, 6), 6);
        Assert.Equal(SmallestRangeII(new[] { 1 }, 0), 1);
        Assert.Equal(SmallestRangeII(new[] { 0, 10 }, 2), 6);
        Assert.Equal(SmallestRangeII(new[] { 1, 3, 6 }, 3), 3);
    }

    private static int SmallestRangeII(int[] nums, int k)
    {
        Array.Sort(nums);

        int minDifference = nums[nums.Length - 1] - nums[0];

        for (var i = 0; i < nums.Length - 1; i++)
        {
            int high = Math.Max(nums[nums.Length - 1] - k, nums[i] + k);
            int low = Math.Min(nums[0] + k, nums[i + 1] - k);
            minDifference = Math.Min(minDifference, high - low);
        }

        return minDifference;
    }
}
