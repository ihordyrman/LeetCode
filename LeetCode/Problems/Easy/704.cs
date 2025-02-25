using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     704. Binary Search
///     https://leetcode.com/problems/binary-search/
/// </summary>
public class _704
{
    public _704()
    {
        Assert.Equal(0, Search(new[] { 2, 5 }, 2));
        Assert.Equal(0, Search(new[] { 5 }, 5));
        Assert.Equal(4, Search(new[] { -1, 0, 3, 5, 9, 12 }, 9));
        Assert.Equal(-1, Search(new[] { -1, 0, 3, 5, 9, 12 }, 2));
    }

    private static int Search(int[] nums, int target)
    {
        int middle = nums.Length / 2;
        var start = 0;
        int end = nums.Length - 1;

        while (start <= end && end >= middle && start <= middle)
        {
            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[middle] > target)
            {
                end = middle - 1;
            }
            else
            {
                start = middle + 1;
            }

            middle = (start + end) / 2;
        }

        return -1;
    }
}
