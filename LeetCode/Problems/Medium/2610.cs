using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2610. Convert an Array Into a 2D Array With Conditions
///     https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions
/// </summary>
public class _2610
{
    private static readonly int[] Input = [1, 3, 4, 1, 2, 3, 1];

    public static void Execute() => FindMatrixBetter(Input).Display();

    // First lazy attempt. 4 ms. Beats 47.73%
    private static IList<IList<int>> FindMatrix(int[] nums)
    {
        Dictionary<int, int> dic = [];
        foreach (var num in nums)
        {
            if (!dic.TryAdd(num, 1))
                dic[num]++;
        }

        IList<IList<int>> result = [];
        while (true)
        {
            bool found = false;
            int index = result.Count;
            foreach (var (num, count) in dic)
            {
                if (count != 0)
                {
                    if (result.Count == index) result.Add([]);

                    result[index].Add(num);
                    dic[num]--;
                    found = true;
                }
            }

            if (!found) break;
        }

        return result;
    }

    // Second attempt. Also lazy, but 2 ms. Beats 88.64%
    private static IList<IList<int>> FindMatrixBetter(int[] nums)
    {
        IList<IList<int>> result = [];
        Dictionary<int, int> dic = [];

        foreach (var num in nums)
        {
            if (!dic.TryAdd(num, 0))
                dic[num]++;

            int index = dic[num];
            if (result.Count - 1 < index)
                result.Add([]);
            result[dic[num]].Add(num);
        }

        return result;
    }
}