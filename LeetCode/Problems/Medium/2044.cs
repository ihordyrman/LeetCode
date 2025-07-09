namespace LeetCode.Problems.Medium;

/// <summary>
///     2044. Count Number of Maximum Bitwise-OR Subsets
///     https://leetcode.com/problems/count-number-of-maximum-bitwise-or-subsets
/// </summary>
public class _2044
{
    private static readonly int[] Input = [3, 1];
    private static readonly int[] Input2 = [2, 2, 2];
    private static readonly int[] Input3 = [3, 2, 1, 5];

    public static void Execute()
    {
        CountMaxOrSubsets(Input).Display();
        CountMaxOrSubsets(Input2).Display();
        CountMaxOrSubsets(Input3).Display();
    }

    private static int CountMaxOrSubsets(int[] nums)
    {
        int count = 0;
        var max = 0;
        foreach (var num in nums)
            max |= num;

        for (int i = 1; i < Math.Pow(2, nums.Length); i++)
        {
            int or = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if ((i & (int)Math.Pow(2, j)) != 0)
                {
                    or |= nums[j];
                }
            }

            if (or == max) count++;
        }

        return count;
    }
}