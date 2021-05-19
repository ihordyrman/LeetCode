using Xunit;

namespace _1221
{
    /// <summary>
    /// 1221. Split a String in Balanced Strings
    /// https://leetcode.com/problems/split-a-string-in-balanced-strings/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.Equal(BalancedStringSplit("RLRRLLRLRL"), 4);
            Assert.Equal(BalancedStringSplit("RLLLLRRRLR"), 3);
            Assert.Equal(BalancedStringSplit("LLLLRRRR"), 1);
            Assert.Equal(BalancedStringSplit("RLRRRLLRLL"), 2);
        }

        private static int BalancedStringSplit(string s)
        {
            int moveTo = 0;
            int count = 0;

            for (int i = 0; i < s.Length; i = moveTo)
            {
                int rCount = 0;
                int lCount = 0;

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
}
