using Xunit;

namespace _2114;

static class Program
{
    public static void Main()
    {
        Assert.Equal(6, MostWordsFound(new[] { "alice and bob love leetcode", "i think so too", "this is great thanks very much" }));
        Assert.Equal(3, MostWordsFound(new[] { "please wait", "continue to fight", "continue to win" }));
    }

    private static int MostWordsFound(string[] sentences)
    {
        int index = 0;
        int maxItems = 0;
        while (index < sentences.Length)
        {
            int wordsCount = 1;
            int innerIndex = 0;

            while (innerIndex < sentences[index].Length)
            {
                if (sentences[index][innerIndex] == ' ') wordsCount++;
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