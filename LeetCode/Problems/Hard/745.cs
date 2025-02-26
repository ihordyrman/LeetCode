using LeetCode.Generators;

namespace LeetCode.Problems.Hard;

/// <summary>
///     745. Prefix and Suffix Search
///     https://leetcode.com/problems/prefix-and-suffix-search/
/// </summary>
public class _745
{
    // TODO: not finished yet.
    // Logic works correct, but still can't pass timeout validation.
    // Need to switch from dictionary to prefix tree.

    private static readonly WordFilter Filter = new(
    [
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
    ]);

    private static readonly (string prefix, string suffix) Input = ("bccbacbcba", "a");

    [BenchmarkGen]
    public void F() => Filter.F(Input.prefix, Input.suffix);

    private class WordFilter
    {
        private readonly Dictionary<string, int> dictionary = new();

        public WordFilter(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                if (!dictionary.TryAdd(words[i], i))
                {
                    dictionary[words[i]] = i;
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            int index = -1;

            foreach (KeyValuePair<string, int> word in dictionary)
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
}
