using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1221. Split a String in Balanced Strings
///     https://leetcode.com/problems/split-a-string-in-balanced-strings/
/// </summary>
public class _1221
{
    public _1221()
    {
        Assert.Equal(BalancedStringSplit("RLRRLLRLRL"), 4);
        Assert.Equal(BalancedStringSplit("RLLLLRRRLR"), 3);
        Assert.Equal(BalancedStringSplit("LLLLRRRR"), 1);
        Assert.Equal(BalancedStringSplit("RLRRRLLRLL"), 2);
    }

    private static int BalancedStringSplit(string s)
    {
        var moveTo = 0;
        var count = 0;

        for (var i = 0; i < s.Length; i = moveTo)
        {
            var rCount = 0;
            var lCount = 0;

            for (int j = i; j < s.Length; j++)
            {
                switch (s[j])
                {
                    case 'R':
                        rCount++;
                        break;
                    case 'L':
                        lCount++;
                        break;
                }

                if (lCount == rCount)
                {
                    moveTo = ++j;
                    count++;
                    break;
                }
            }
        }

        return count;
    }
}
