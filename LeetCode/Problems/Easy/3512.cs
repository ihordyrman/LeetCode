namespace LeetCode.Problems.Easy;

/// <summary>
/// I know it's a lame task, but I needed something to test my new nvim config with C#
/// </summary>
public class _3512
{
    private const int K = 5;
    private static readonly int[] Arr = [3, 9, 7];

    [BenchmarkGen]
    public void MinOerations() => MinOerations(Arr, K);

    private static int MinOerations(int[] nums, int k)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        return sum % k;
    }
}
