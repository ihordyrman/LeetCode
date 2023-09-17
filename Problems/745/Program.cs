using System.Collections.Generic;
using Xunit;

namespace _745;

/// <summary>
///     745. Prefix and Suffix Search
///     https://leetcode.com/problems/prefix-and-suffix-search/
/// </summary>
internal static class Program
{
    private static void Main()
    {
        var wordFilter = new WordFilter(
            new[]
            {
                "cabaabaaaa",
                "ccbcababac",
                "bacaabccba",
                "bcbbcbacaa",
                "abcaccbcaa",
                "accabaccaa",
                "cabcbbbcca",
                "ababccabcb",
                "caccbbcbab",
                "bccbacbcba"
            });

        Assert.Equal(wordFilter.F("bccbacbcba", "a"), 9);
        Assert.Equal(wordFilter.F("ab", "abcaccbcaa"), 4);
        Assert.Equal(wordFilter.F("a", "aa"), 5);
        Assert.Equal(wordFilter.F("cabaaba", "abaaaa"), 0);
        Assert.Equal(wordFilter.F("cacc", "accbbcbab"), 8);
        Assert.Equal(wordFilter.F("ccbcab", "bac"), 1);
        Assert.Equal(wordFilter.F("bac", "cba"), 2);

        // TODO: not finished yet.
        // Logic works correct, but still can't pass timeout validation.
        // Need to switch from dictionary to prefix tree.
    }
}

public class WordFilter
{
    private readonly Dictionary<string, int> _dictionary = new();

    public WordFilter(string[] words)
    {
        for (var i = 0; i < words.Length; i++)
        {
            if (!_dictionary.TryAdd(words[i], i))
            {
                _dictionary[words[i]] = i;
            }
        }
    }

    public int F(string prefix, string suffix)
    {
        int index = -1;

        foreach (KeyValuePair<string, int> word in _dictionary)
        {
            if (word.Key.StartsWith(prefix) && word.Key.EndsWith(suffix))
            {
                if (index < word.Value)
                {
                    index = word.Value;
                }
            }
        }

        return index;
    }
}
