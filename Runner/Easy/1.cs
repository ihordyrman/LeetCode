﻿// 1. Two Sum

using Xunit;

/// <summary>
///     1. Two Sum
///     https://leetcode.com/problems/two-sum/
/// </summary>
public class _1
{
    public _1()
    {
        Assert.Equal(new[] { 0, 1 }.OrderBy(x => x), TwoSum(new[] { 2, 7, 11, 15 }, 9).OrderBy(x => x));
        Assert.Equal(new[] { 1, 2 }.OrderBy(x => x), TwoSum(new[] { 3, 2, 4 }, 6).OrderBy(x => x));
        Assert.Equal(new[] { 0, 1 }.OrderBy(x => x), TwoSum(new[] { 3, 3 }, 6).OrderBy(x => x));
        Assert.Equal(new[] { 0, 1 }.OrderBy(x => x), TwoSum2(new[] { 2, 7, 11, 15 }, 9).OrderBy(x => x));
        Assert.Equal(new[] { 1, 2 }.OrderBy(x => x), TwoSum2(new[] { 3, 2, 4 }, 6).OrderBy(x => x));
        Assert.Equal(new[] { 0, 1 }.OrderBy(x => x), TwoSum2(new[] { 3, 3 }, 6).OrderBy(x => x));
    }

    private int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }

        return Array.Empty<int>();
    }

    private int[] TwoSum2(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(target - nums[i]))
            {
                return new[] { i, dictionary[target - nums[i]] };
            }

            dictionary[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}
