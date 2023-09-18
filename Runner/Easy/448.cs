using Xunit;

namespace Runner.Easy;

/// <summary>
///     448. Find All Numbers Disappeared in an Array
///     https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
/// </summary>
public class _448
{
    public _448()
    {
        Assert.Equal(new[] { 5, 6 }, FindDisappearedNumbers(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }));
        Assert.Equal(new[] { 2 }, FindDisappearedNumbers(new[] { 1, 1 }));
    }

    private static IList<int> FindDisappearedNumbers(int[] nums)
    {
        var values = new bool[nums.Length + 1];

        foreach (int t in nums)
        {
            values[t] = true;
        }

        var result = new List<int>();

        for (var i = 1; i < values.Length; i++)
        {
            if (!values[i])
            {
                result.Add(i);
            }
        }

        return result;
    }
}
