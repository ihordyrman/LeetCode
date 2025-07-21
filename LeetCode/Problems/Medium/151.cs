using System.Text;

namespace LeetCode.Problems.Medium;

/// <summary>
///     151. Reverse Words in a String
///     https://leetcode.com/problems/reverse-words-in-a-string/
/// </summary>
public class _151
{
    private static readonly string Input1 = "the sky is blue";
    private static readonly string Input2 = "  hello world  ";
    private static readonly string Input3 = "a good   example";

    public static void Execute()
    {
        ReverseWords(Input1).Display();
        ReverseWordsBetter(Input2).Display();
        ReverseWords(Input3).Display();
    }

    // One-liner. Definitely not a medium one.
    private static string ReverseWords(string s) =>
        s.Split(' ').Where(x => x.Length > 0).Reverse().Aggregate((seed, x) => seed + " " + x);

    // A bit faster second approach. O(n) time complexity, but a lot of allocations
    private static string ReverseWordsBetter(string s)
    {
        StringBuilder sb = new();
        List<int> spaces = [];
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' && (sb.Length == 0 || i == s.Length - 1 || (i + 1 < s.Length && s[i + 1] == ' ')))
                continue;

            sb.Append(s[i]);
            if (s[i] == ' ' && i < s.Length && s[i + 1] != ' ')
                spaces.Add(sb.Length - 1);
        }

        if (spaces.Count == 0) return s;
        StringBuilder result = new(sb.Length) { Length = sb.Length };

        int space = spaces[0];
        for (int i = 0, j = 1, index = 0; i < sb.Length; i++)
        {
            index = space > 0 ? result.Length - space-- : ++index;

            if (sb[i] == ' ')
            {
                result[sb.Length - i - 1] = ' ';
                space = spaces.Count >= j ? 0 : spaces[j++];
                index = -1;
                continue;
            }

            result[index] = sb[i];
        }

        return result.ToString();
    }
}