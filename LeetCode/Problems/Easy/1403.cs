using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1403. Minimum Subsequence in Non-Increasing Order
///     https://leetcode.com/problems/minimum-subsequence-in-non-increasing-order/
/// </summary>
public class _1403
{
    public _1403()
    {
        Assert.Equal([7, 7, 6], MinSubsequence([4, 4, 7, 6, 7]));
        Assert.Equal([10, 9], MinSubsequence([4, 3, 10, 9, 8]));
        Assert.Equal([10], MinSubsequence([10, 2, 5]));
        Assert.Equal([9, 8, 7, 6], MinSubsequence([4, 6, 4, 4, 8, 5, 1, 7, 9]));
    }

    private static IList<int> MinSubsequence(int[] nums)
    {
        Array.Sort(nums);
        int index = nums.Length - 1;
        int maxSum = nums[index];
        var result = new List<int> { nums[index] };

        while (true)
        {
            var leftSum = 0;
            for (var i = 0; i < index; i++)
            {
                leftSum += nums[i];
            }

            if (leftSum < maxSum)
            {
                return result;
            }

            result.Add(nums[index - 1]);
            maxSum += nums[--index];
        }
    }
}
