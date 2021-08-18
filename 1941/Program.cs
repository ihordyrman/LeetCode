// 1941. Check if All Characters Have Equal Number of Occurrences
// https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _1941
{
    public static class Program
    {
        public static void Main()
        {
            Assert.True(SlowAreOccurrencesEqual("abacbc"));
            Assert.False(FastAreOccurrencesEqual("aaabb"));
        }

        private static bool FastAreOccurrencesEqual(string s)
        {
            int[] arr = new int[26];

            foreach (char ch in s)
            {
                arr[ch - 'a']++;
            }

            int totalCount = arr[s[0] - 'a'];

            foreach (int count in arr)
            {
                if (count != 0 && count != totalCount)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool SlowAreOccurrencesEqual(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (!dic.TryAdd(ch, 1))
                {
                    dic[ch]++;
                }
            }

            int x = dic.First().Value;

            foreach ((_, int value) in dic)
            {
                if (x != value) return false;
            }

            return true;
        }
    }
}