namespace LeetCode.Problems.Medium;

/// <summary>
///     55. Jump Game
///     https://leetcode.com/problems/jump-game/
/// </summary>
public class _55
{
    private static readonly int[] Input = [2, 3, 1, 1, 4];

    [BenchmarkGen]
    public void CanJump() => CanJump(Input);

    private static bool CanJump(int[] nums)
    {
        var x = 0;

        while (x != nums.Length - 1)
        {
            int step = nums[x];
            var distance = new List<int> { 0 };

            for (var i = 1; i <= step; i++)
            {
                if (i + x == nums.Length - 1)
                {
                    x += i;
                    distance = [0];
                    break;
                }

                distance.Add(nums[i + x] - (step - i));
            }

            x += distance.LastIndexOf(distance.Max());

            if (x != nums.Length - 1 && nums[x] == 0)
            {
                return false;
            }
        }

        return true;
    }
}
