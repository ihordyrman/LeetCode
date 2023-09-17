using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _55;

/// <summary>
///     55. Jump Game
///     https://leetcode.com/problems/jump-game/
/// </summary>
internal static class Program
{
    private static void Main()
    {
        Assert.Equal(CanJump(new[] { 2, 3, 1, 1, 4 }), true);
        Assert.Equal(CanJump(new[] { 3, 2, 1, 0, 4 }), false);
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
                    distance = new List<int> { 0 };
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
