using Xunit;

namespace _1869
{
    /// <summary>
    /// 1869. Longer Contiguous Segments of Ones than Zeros
    /// https://leetcode.com/problems/longer-contiguous-segments-of-ones-than-zeros/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.False(CheckZeroOnes("011000111"));
            Assert.True(CheckZeroOnes("1101"));
            Assert.False(CheckZeroOnes("111000"));
            Assert.False(CheckZeroOnes("110100010"));
        }

        private static bool CheckZeroOnes(string s)
        {
            int maxZeros = 0;
            int maxOnes = 0;
            int zeros = 0;
            int ones = 0;

            char current = s[0];

            foreach (var ch in s)
            {
                if (ch != current)
                {
                    current = ch;
                    maxZeros = maxZeros < zeros ? zeros : maxZeros;
                    maxOnes = maxOnes < ones ? ones : maxOnes;

                    zeros = 0;
                    ones = 0;
                }

                if (ch == '1')
                    ones++;
                else
                    zeros++;
            }

            maxZeros = maxZeros < zeros ? zeros : maxZeros;
            maxOnes = maxOnes < ones ? ones : maxOnes;

            return maxOnes > maxZeros;
        }
    }
}