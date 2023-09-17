using Xunit;

namespace _2021;

internal static class Program
{
    public static void Main()
    {
        Assert.Equal(1, FinalValueAfterOperations(new[] { "--X", "X++", "X++" }));
        Assert.Equal(3, FinalValueAfterOperations(new[] { "++X", "++X", "X++" }));
        Assert.Equal(0, FinalValueAfterOperations(new[] { "X++", "++X", "--X", "X--" }));
    }

    private static int FinalValueAfterOperations(string[] operations)
    {
        var result = 0;
        var index = 0;

        while (index < operations.Length)
        {
            if (operations[index][1] == '-')
            {
                result--;
            }
            else
            {
                result++;
            }

            index++;
        }

        return result;
    }
}
