// 1967. Number of Strings That Appear as Substrings in Word
// https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/

using System;
using Xunit;

Assert.Equal(3, NumOfStrings(new[] { "a", "abc", "bc", "d" }, "abc"));
Assert.Equal(2, NumOfStrings(new[] { "a", "b", "c" }, "aaaaabbbbb"));
Assert.Equal(3, NumOfStrings(new[] { "a", "a", "a" }, "ab"));

int NumOfStrings(string[] patterns, string word)
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
