using System.Text;

namespace LeetCode.Extensions;

public static class ArrayExtensions
{
    public static void Display(this int[] nums)
    {
        var builder = new StringBuilder();

        builder.Append('[');

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            builder.Append(num);

            if (nums.Length > 1 && i != nums.Length - 1)
            {
                builder.Append(", ");
            }
        }

        builder.Append(']');

        Console.WriteLine(builder.ToString());
    }
}