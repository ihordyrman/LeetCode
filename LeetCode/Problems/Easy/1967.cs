using LeetCode.Generators;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1967. Number of Strings That Appear as Substrings in Word
///     https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word
/// </summary>
public class _1967
{
    private static readonly (string[] patterns, string word) Input = (["a", "abc", "bc", "d"], "abc");

    [BenchmarkGen]
    public void NumOfStrings() => NumOfStrings(Input.patterns, Input.word);

    private int NumOfStrings(string[] patterns, string word)
    {
        var count = 0;
        var i = 0;

        while (i < patterns.Length)
        {
            string pattern = patterns[i];

            if (word.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                count++;
            }

            i++;
        }

        return count;
    }
}
