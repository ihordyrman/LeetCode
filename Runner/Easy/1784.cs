using Xunit;

namespace Runner.Easy;

/// <summary>
///     1784. Check if Binary String Has at Most One Segment of Ones
///     https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/
/// </summary>
public class _1784
{
    public _1784()
    {
        Assert.False(CheckOnesSegment("1100111"));
        Assert.False(CheckOnesSegment("1001"));
        Assert.True(CheckOnesSegment("1000"));
        Assert.True(CheckOnesSegment("110"));
    }

    private static bool CheckOnesSegment(string s)
    {
        var found = false;

        for (var i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '1' when !found:
                    found = true;
                    break;
                case '1' when i > 0 && s[i - 1] != '1':
                    return false;
            }
        }

        return found;
    }
}
