using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1844. Replace All Digits with Characters
///     https://leetcode.com/problems/replace-all-digits-with-characters/
/// </summary>
public class _1844
{
    public _1844()
    {
        Assert.Equal(ReplaceDigits("a1c1e1"), "abcdef");
        Assert.Equal(ReplaceDigits("a1b2c3d4e"), "abbdcfdhe");
    }

    private static string ReplaceDigits(string s)
    {
        var array = new char[s.Length];

        for (int i = 0, j = s.Length - 1; i <= s.Length / 2; i++, j--)
        {
            array[i] = i % 2 == 0 ? s[i] : (char)(s[i - 1] + char.GetNumericValue(s[i]));

            array[j] = j % 2 == 0 ? s[j] : (char)(s[j - 1] + char.GetNumericValue(s[j]));
        }

        return new string(array);
    }
}
