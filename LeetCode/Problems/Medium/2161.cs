using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2161: Partition Array According to Given Pivot
///     https://leetcode.com/problems/partition-array-according-to-given-pivot/
/// </summary>
public class _2161
{
    private static readonly int[] Input = [9, 12, 5, 10, 14, 3, 10];

    // [9,5,3,10,10,12,14]
    public static void Execute() => PivotArrayBetterOne(Input, 10).Display();

    // First attempt. Not optimal
    private static int[] PivotArray(int[] nums, int pivot)
    {
        List<int> smaller = [];
        List<int> larger = [];
        int pivots = 0;

        foreach (var num in nums)
        {
            if (num < pivot)
                smaller.Add(num);
            else if (num > pivot)
                larger.Add(num);
            else
                pivots++;
        }

        for (int i = 0; i < pivots; i++)
        {
            smaller.Add(pivot);
        }

        return smaller.Concat(larger).ToArray();
    }

    private static int[] PivotArrayBetterOne(int[] nums, int pivot)
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