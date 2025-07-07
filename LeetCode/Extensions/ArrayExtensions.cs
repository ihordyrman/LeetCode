using System.Text;

namespace LeetCode.Extensions;

public static class ArrayExtensions
{
    public static void Display(this int[] nums) => Console.WriteLine(GetString(nums));

    public static void Display<T>(this IEnumerable<IEnumerable<T>> nums)
    {
        var builder = new StringBuilder();

        builder.Append('[');
        builder.AppendLine();

        foreach (var num in nums)
        {
            builder.Append("  " + GetString(num));
            builder.AppendLine();
        }

        builder.Append(']');
        Console.WriteLine(builder.ToString());
    }

    public static string Stringify<T>(this T[] nums) => GetString(nums);

    private static string GetString(int[] nums)
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
        return builder.ToString();
    }

    private static string GetString<T>(IEnumerable<T> nums)
    {
        var builder = new StringBuilder();

        builder.Append('[');

        foreach (var num in nums)
        {
            builder.Append(num);
            builder.Append(", ");
        }

        // remove last ", "
        builder.Remove(builder.Length - 2, 2);

        builder.Append(']');
        return builder.ToString();
    }
}