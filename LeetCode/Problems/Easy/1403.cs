namespace LeetCode.Problems.Easy;

/// <summary>
///     1403. Minimum Subsequence in Non-Increasing Order
///     https://leetcode.com/problems/minimum-subsequence-in-non-increasing-order/
/// </summary>
public class _1403
{
    private static readonly int[] Input = [4, 6, 4, 4, 8, 5, 1, 7, 9];

    [BenchmarkGen]
    public void MinSubsequence() => MinSubsequence(Input);

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
