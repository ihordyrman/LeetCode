namespace LeetCode.Problems.Easy;

/// <summary>
///     1221. Split a String in Balanced Strings
///     https://leetcode.com/problems/split-a-string-in-balanced-strings/
/// </summary>
public class _1221
{
    private const string Input = "RLRRLLRLRL";

    [BenchmarkGen]
    public void BalancedStringSplit() => BalancedStringSplit(Input);

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
