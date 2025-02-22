using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1880. Check if Word Equals Summation of Two Words
///     https://leetcode.com/problems/check-if-word-equals-summation-of-two-words/
/// </summary>
public class _1880
{
    public _1880()
    {
        Assert.True(IsSumEqual("acb", "cba", "cdb"));
        Assert.True(IsSumEqual("aaa", "a", "aaaa"));
        Assert.False(IsSumEqual("aaa", "a", "aab"));
    }

    private static bool IsSumEqual(string firstWord, string secondWord, string targetWord)
    {
        return GetLength(firstWord) + GetLength(secondWord) == GetLength(targetWord);

        static int GetLength(string word)
        {
            var length = 0;
            var index = 0;

            while (index < word.Length)
            {
                length *= 10;
                length += word[index] - 97;
                index++;
            }

            return length;
        }
    }
}
