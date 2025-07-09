// 1. Two Sum

namespace LeetCode.Problems.Easy;

/// <summary>
///     1. Two Sum
///     https://leetcode.com/problems/two-sum/
/// </summary>
public class _1
{
    private static readonly int[] Input = [2, 7, 11, 15];

    [BenchmarkGen]
    public void TwoSum() => TwoSum2(Input, 9);

    [BenchmarkGen]
    public void TwoSum2() => TwoSum2(Input, 9);

    private int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    private int[] TwoSum2(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(target - nums[i]))
            {
                return [i, dictionary[target - nums[i]]];
            }

            dictionary[nums[i]] = i;
        }

        return [];
    }
}
