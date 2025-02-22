using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     2124. Check if All A's Appears Before All B's
///     https://leetcode.com/problems/check-if-all-as-appears-before-all-bs/
/// </summary>
public class _2124
{
    public _2124()
    {
        Assert.True(CheckString("aaabbb"));
        Assert.False(CheckString("abab"));
        Assert.True(CheckString("bbb"));
    }

    private static bool CheckString(string s)
    {
        int a = s.LastIndexOf('a');
        int b = s.IndexOf('b');

        if (a == -1 || b == -1)
        {
            return true;
        }

        return a < b;

        // First approach with slow speed
        /*int lastA = -1;
        int lastB = s.Length + 1;
        int i = 0;
        while (i < s.Length)
        {
            if (s[i] == 'a') lastA = i;
            else
            {
                lastB = i;
            }

            if (lastA > lastB) return false;

            i++;
        }

        return true;*/
    }
}
