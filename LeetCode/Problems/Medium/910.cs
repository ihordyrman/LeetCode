namespace LeetCode.Problems.Medium;

/// <summary>
///     910. Smallest Range II
///     https://leetcode.com/problems/smallest-range-ii/
/// </summary>
public class _910
{
    private static readonly (int[] nums, int k) Input = ([1, 7, 3, 5], 6);

    [BenchmarkGen]
    public void SmallestRangeIi() => SmallestRangeIi(Input.nums, Input.k);

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
