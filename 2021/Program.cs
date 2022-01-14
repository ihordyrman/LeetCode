using Xunit;

namespace _2021;

static class Program
{
    public static void Main()
    {
        Assert.Equal(1, FinalValueAfterOperations(new[] { "--X", "X++", "X++" }));
        Assert.Equal(3, FinalValueAfterOperations(new[] { "++X", "++X", "X++" }));
        Assert.Equal(0, FinalValueAfterOperations(new[] { "X++", "++X", "--X", "X--" }));
    }

    private static int FinalValueAfterOperations(string[] operations)
    {
        int result = 0;
        int index = 0;

        while (index < operations.Length)
        {
            if (operations[index][1] == '-') result--;
            else result++;
            index++;
        }

        return result;
    }
}