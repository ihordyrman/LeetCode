namespace LeetCode.Problems.Medium;

/// <summary>
///     49. Group Anagrams
///     https://leetcode.com/problems/group-anagrams/
/// </summary>
public class _49
{
    private static readonly string[] Input1 = ["eat", "tea", "tan", "ate", "nat", "bat"];
    private static readonly string[] Input2 = [""];
    private static readonly string[] Input3 = ["a"];
    private static readonly string[] Input4 = ["cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc"];
    private static readonly string[] Input5 = ["abbbbbbbbbbb", "aaaaaaaaaaab"];

    public static void Execute()
    {
        GroupAnagramsBetter(Input1).Display();
        GroupAnagramsBetter(Input2).Display();
        GroupAnagramsBetter(Input3).Display();
        GroupAnagramsBetter(Input4).Display();
        GroupAnagramsBetter(Input5).Display();
    }

    // First attempt. Not ideal
    private static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, int> dic = [];
        IList<IList<string>> result = [];
        for (int i = 0; i < strs.Length; i++)
        {
            var arr = strs[i].ToCharArray();
            Array.Sort(arr);
            var str = new string(arr);

            if (!dic.TryGetValue(str, out var index))
            {
                result.Add([strs[i]]);
                dic.Add(str, result.Count - 1);
            }
            else
            {
                result[index].Add(strs[i]);
            }
        }

        return result;
    }

    // Second attempt.
    private static IList<IList<string>> GroupAnagramsBetter(string[] strs)
    {
        Dictionary<double, int> dic = [];
        IList<IList<string>> result = [];
        for (int i = 0; i < strs.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < strs[i].Length; j++)
            {
                // pow(2) and pow(3) didn't work
                sum += Math.Pow(strs[i][j], 4);
            }

            if (dic.TryAdd(sum, result.Count))
                result.Add([strs[i]]);
            else
                result[dic[sum]].Add(strs[i]);
        }

        return result;
    }
}