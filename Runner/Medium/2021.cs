using Xunit;

namespace Runner.Medium;

/// <summary>
///     https://leetcode.com/problems/brightest-position-on-street/
/// </summary>
public class _2021
{
    public _2021()
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
