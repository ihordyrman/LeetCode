using Xunit;

namespace Runner.Easy;

/// <summary>
///     169. Majority Element
///     https://leetcode.com/problems/majority-element/
/// </summary>
public class _169
{
    public _169()
    {
        Assert.Equal(3, MajorityElement(new[] { 3, 2, 3 }));
        Assert.Equal(2, MajorityElement(new[] { 2, 2, 1, 1, 1, 2, 2 }));
        Assert.Equal(5, MajorityElement(new[] { 6, 5, 5 }));
        Assert.Equal(3, MajorityElementFast(new[] { 3, 2, 3 }));
        Assert.Equal(2, MajorityElementFast(new[] { 2, 2, 1, 1, 1, 2, 2 }));
        Assert.Equal(5, MajorityElementFast(new[] { 6, 5, 5 }));
    }

    // Slow, but consume less memory.
    private static int MajorityElement(int[] nums)
    {
        var dic = new Dictionary<int, int>();
        var max = 0;
        var maxCount = 0;

        foreach (int num in nums)
        {
            if (!dic.TryAdd(num, 1))
            {
                dic[num]++;
            }

            if (dic[num] > maxCount)
            {
                maxCount = dic[num];
                max = num;
            }
        }

        return max;
    }

    // Fast, but too many allocations
    private static int MajorityElementFast(int[] nums)
    {
        for (var i = 0; i != nums.Length; i++)
        {
            if (nums.Count(x => x == nums[i]) > nums.Length / 2)
            {
                return nums[i];
            }

            nums = nums.Where(x => x != nums[i]).ToArray();
        }

        return 0;
    }
}
