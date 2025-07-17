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

    public static void Execute()
    {
        GroupAnagrams(Input1).Display();
        GroupAnagrams(Input2).Display();
        GroupAnagrams(Input3).Display();
        GroupAnagrams(Input4).Display();
    }

    // todo: need to finish
    private static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<int, int> dic = [];
        IList<IList<string>> result = [];
        for (int i = 0; i < strs.Length; i++)
        {
            int sum = 0;
            for (int j = 0; j < strs[i].Length; j++)
            {
                sum += strs[i][j];
            }

            if (!dic.TryGetValue(sum, out var index))
            {
                result.Add([strs[i]]);
                dic.Add(sum, result.Count - 1);
            }
            else
            {
                result[index].Add(strs[i]);
            }
        }

        return result;
    }
}