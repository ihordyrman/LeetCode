namespace LeetCode.Problems.Easy;

/// <summary>
///     2114. Maximum Number of Words Found in Sentences
///     https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/
/// </summary>
public class _2114
{
    private static readonly string[] Input = ["alice and bob love leetcode", "i think so too", "this is great thanks very much"];

    [BenchmarkGen]
    public void MostWordsFound() => MostWordsFound(Input);

    private static int MostWordsFound(string[] sentences)
    {
        var index = 0;
        var maxItems = 0;
        while (index < sentences.Length)
        {
            var wordsCount = 1;
            var innerIndex = 0;

            while (innerIndex < sentences[index].Length)
            {
                if (sentences[index][innerIndex] == ' ')
                {
                    wordsCount++;
                }

                innerIndex++;
            }

            if (wordsCount > maxItems)
            {
                maxItems = wordsCount;
            }

            index++;
        }

        return maxItems;
    }
}
