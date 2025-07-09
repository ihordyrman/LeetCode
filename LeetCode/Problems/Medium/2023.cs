namespace LeetCode.Problems.Medium;

/// <summary>
///     2023. Number of Pairs of Strings With Concatenation Equal to Target
///     https://leetcode.com/problems/number-of-pairs-of-strings-with-concatenation-equal-to-target
/// </summary>
public class _2023
{
    private static readonly (string[] nums, string target) Input1 = (["777", "7", "77", "77"], "7777");
    private static readonly (string[] nums, string target) Input2 = (["123", "4", "12", "34"], "1234");
    private static readonly (string[] nums, string target) Input3 = (["1", "1", "1"], "11");
    private static readonly (string[] nums, string target) Input4 = (["74","1","67","1","74"], "174");

    public static void Execute()
    {
        NumOfPairsBetter(Input1.nums, Input1.target).Display();
        NumOfPairsBetter(Input2.nums, Input2.target).Display();
        NumOfPairsBetter(Input3.nums, Input3.target).Display();
        NumOfPairsBetter(Input4.nums, Input4.target).Display();
    }

    // Brute force. Stupid, but works
    private static int NumOfPairs(string[] nums, string target)
    {
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j) continue;

                if (nums[i] + nums[j] == target)
                {
                    count++;
                }
            }
        }

        return count;
    }

    // 1ms, Beats 100.00%
    private static int NumOfPairsBetter(string[] nums, string target)
    {
        int count = 0;
        Dictionary<string, int> dic = [];

        for (int i = 0; i < nums.Length; i++)
        {
            if (!dic.TryAdd(nums[i], 1))
            {
                dic[nums[i]]++;
            }
        }

        for (int i = 1; i < target.Length; i++)
        {
            string left = target[..i];
            string right = target[i..];

            if (dic.ContainsKey(left) && dic.ContainsKey(right))
            {
                count += dic[left] * (left == right ? dic[right] - 1 : dic[right]);
            }
        }

        return count;
    }
}