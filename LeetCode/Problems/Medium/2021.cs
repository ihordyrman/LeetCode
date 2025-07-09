namespace LeetCode.Problems.Medium;

/// <summary>
///     https://leetcode.com/problems/brightest-position-on-street/
/// </summary>
public class _2021
{
    private static readonly string[] Input = ["X++", "++X", "--X", "X--"];

    [BenchmarkGen]
    public void FinalValueAfterOperations() => FinalValueAfterOperations(Input);

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
