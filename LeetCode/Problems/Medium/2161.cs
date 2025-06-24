using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

public class _2161
{
    private static readonly int[] Input = [9, 12, 5, 10, 14, 3, 10];

    public static void Execute() => PivotArray(Input, 10).Display();

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
}