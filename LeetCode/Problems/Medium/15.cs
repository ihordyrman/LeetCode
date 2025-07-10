namespace LeetCode.Problems.Medium;

public class _15
{
    private static readonly int[] Input = [-1, 0, 1, 2, -1, -4];
    private static readonly int[] Input2 = [0, 1, 1];
    private static readonly int[] Input3 = [0, 0, 0];

    public static void Execute()
    {
        ThreeSum(Input).Display();
        ThreeSum(Input2).Display();
        ThreeSum(Input3).Display();
    }

    // Time Limit exceeded
    private static IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = [];
        HashSet<(int, int, int)> hash = [];

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (j == i) continue;
                for (int k = 0; k < nums.Length; k++)
                {
                    if (k == i || k == j) continue;
                    if (nums[i] + nums[k] + nums[j] == 0)
                    {
                        var max = Math.Max(Math.Max(nums[i], nums[k]), nums[j]);
                        var min = Math.Min(Math.Min(nums[i], nums[k]), nums[j]);
                        var middle = nums[i] + nums[k] + nums[j] - max - min;
                        hash.Add((max, middle, min));
                    }
                }
            }
        }

        foreach (var (i, k, j) in hash)
        {
            result.Add([i, k, j]);
        }

        return result;
    }
}