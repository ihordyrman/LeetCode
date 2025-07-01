using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

public class _2610
{
    private static readonly int[] Input = [1, 3, 4, 1, 2, 3, 1];

    public static void Execute() => FindMatrix(Input).Display();

    // First attempt. 4 ms. Beats 47.73%
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
}