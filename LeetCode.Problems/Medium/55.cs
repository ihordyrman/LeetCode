using Xunit;

namespace LeetCode.Problems.Medium;

/// <summary>
///     55. Jump Game
///     https://leetcode.com/problems/jump-game/
/// </summary>
public class _55
{
    public _55()
    {
        Assert.Equal(CanJump([2, 3, 1, 1, 4]), true);
        Assert.Equal(CanJump([3, 2, 1, 0, 4]), false);
    }

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
