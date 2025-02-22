using Xunit;

namespace _1370;

/// <summary>
///     1370. Increasing Decreasing String
///     https://leetcode.com/problems/increasing-decreasing-string/
/// </summary>
public class _1370
{
    public _1370()
    {
        Assert.Equal(SortString("aaaabbbbcccc"), "abccbaabccba");
        Assert.Equal(SortStringLinq("aaaabbbbcccc"), "abccbaabccba");
        Assert.Equal(SortString("rat"), "art");
        Assert.Equal(SortStringLinq("rat"), "art");
        Assert.Equal(SortString("leetcode"), "cdelotee");
        Assert.Equal(SortStringLinq("leetcode"), "cdelotee");
        Assert.Equal(SortString("spo"), "ops");
        Assert.Equal(SortStringLinq("spo"), "ops");
    }

    private static string SortString(string s)
    {
        Dictionary<int, int> chars = new();
        string result = string.Empty;
        var reversed = false;

        foreach (char ch in s)
        {
            if (chars.Keys.All(x => x != +ch))
            {
                chars.Add(+ch, 1);
            }
            else
            {
                chars.TryGetValue(+ch, out int value);
                chars[+ch] = ++value;
            }
        }

        while (chars.Any())
        {
            if (!reversed)
            {
                for (var i = 97; i < 123; i++)
                {
                    if (chars.ContainsKey(i))
                    {
                        ChangeDictionary(i);
                    }
                }
            }
            else
            {
                for (int i = 123 - 1; i >= 97; i--)
                {
                    if (chars.ContainsKey(i))
                    {
                        ChangeDictionary(i);
                    }
                }
            }

            reversed = !reversed;
        }

        return result;

        void ChangeDictionary(int i)
        {
            result += (char)i;
            chars.TryGetValue(i, out int value);
            chars[i] = --value;

            if (value == 0)
            {
                chars.Remove(i);
            }
        }
    }

    private static string SortStringLinq(string s)
        => string.Concat(
            s.ToCharArray()
                .GroupBy(x => x)
                .SelectMany(x => x.Select((c, i) => (c, i, i % 2 == 0 ? c : -c)))
                .OrderBy(x => x.Item2)
                .ThenBy(x => x.Item3)
                .Select(x => x.Item1));
}
