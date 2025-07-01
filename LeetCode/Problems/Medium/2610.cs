using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

public class _2610
{
    private static readonly int[] Input = [1, 3, 4, 1, 2, 3, 1];

    public static void Execute() => FindMatrix(Input).Display();

    private static IList<IList<int>> FindMatrix(int[] nums)
    {
        Dictionary<int, int> dic = [];

        foreach (var num in nums)
        {
            if (!dic.TryAdd(num, 1))
                dic[num]++;
        }

        IList<IList<int>> result = [];
        bool moreLeft = true;

        while (moreLeft)
        {
            result.Add([]);
            bool found = false;
            int index = result.Count - 1;
            foreach (var (key, value) in dic)
            {
                if (value != 0)
                {
                    result[index].Add(key);
                    dic[key]--;
                    found = true;
                }
            }

            if (!found)
            {
                result.RemoveAt(index);
                moreLeft = false;
            }
        }

        return result;
    }
}