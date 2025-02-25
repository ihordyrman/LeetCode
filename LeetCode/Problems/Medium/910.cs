using Xunit;

namespace LeetCode.Problems.Medium;

/// <summary>
///     910. Smallest Range II
///     https://leetcode.com/problems/smallest-range-ii/
/// </summary>
public class _910
{
    public _910()
    {
        Assert.Equal(SmallestRangeIi(new[] { 1, 7, 3, 5 }, 6), 6);
        Assert.Equal(SmallestRangeIi(new[] { 1 }, 0), 1);
        Assert.Equal(SmallestRangeIi(new[] { 0, 10 }, 2), 6);
        Assert.Equal(SmallestRangeIi(new[] { 1, 3, 6 }, 3), 3);
    }

    private static int SmallestRangeIi(int[] nums, int k)
    {
        Array.Sort(nums);

        int minDifference = nums[^1] - nums[0];

        for (var i = 0; i < nums.Length - 1; i++)
        {
            int high = Math.Max(nums[^1] - k, nums[i] + k);
            int low = Math.Min(nums[0] + k, nums[i + 1] - k);
            minDifference = Math.Min(minDifference, high - low);
        }

        return minDifference;
    }
}
