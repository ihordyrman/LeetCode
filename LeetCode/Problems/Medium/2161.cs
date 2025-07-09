namespace LeetCode.Problems.Medium;

/// <summary>
///     2161: Partition Array According to Given Pivot
///     https://leetcode.com/problems/partition-array-according-to-given-pivot/
/// </summary>
public class _2161
{
    private static readonly int[] Input = [9, 12, 5, 10, 14, 3, 10];

    // [9,5,3,10,10,12,14]
    public static void Execute() => PivotArray(Input, 10).Display();

    private static int[] PivotArray(int[] nums, int pivot)
    {
        int[] result = new int[nums.Length];
        int pointer = 0;

        foreach (var num in nums)
        {
            if (num < pivot) result[pointer++] = num;
        }

        foreach (var num in nums)
        {
            if (num == pivot) result[pointer++] = num;
        }

        foreach (var num in nums)
        {
            if (num > pivot) result[pointer++] = num;
        }

        return result;
    }
}