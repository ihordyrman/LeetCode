using System.Text;

namespace LeetCode.Problems.Medium;

/// <summary>
///     1980. Find Unique Binary String
///     https://leetcode.com/problems/find-unique-binary-string
/// </summary>
public class _1980
{
    private static readonly string[] Input = ["01", "10"]; // 11
    private static readonly string[] Input2 = ["00", "01"]; // 11
    private static readonly string[] Input3 = ["111", "011", "001"]; // 101
    private static readonly string[] Input4 = ["1010", "0000", "0101", "1111"]; // 0001

    public static void Execute()
    {
        Console.WriteLine($"Input {Input.Stringify()}, Output: {FindDifferentBinaryStringBetter(Input)}");
        Console.WriteLine($"Input {Input2.Stringify()}, Output: {FindDifferentBinaryStringBetter(Input2)}");
        Console.WriteLine($"Input {Input3.Stringify()}, Output: {FindDifferentBinaryStringBetter(Input3)}");
        Console.WriteLine($"Input {Input4.Stringify()}, Output: {FindDifferentBinaryStringBetter(Input4)}");
    }

    // First attempt. Not great, not terrible.
    private static string FindDifferentBinaryString(string[] nums)
    {
        HashSet<int> numbers = [];
        int max = 0;
        int min = int.MaxValue;
        int length = nums[0].Length;

        foreach (var num in nums)
        {
            var value = Convert.ToInt32(num, 2);
            numbers.Add(value);

            if (value > max) max = value;
            if (value < min) min = value;
        }

        for (int i = min + 1; i < max; i++)
        {
            if (!numbers.Add(i))
            {
                return Convert.ToString(i, 2).PadLeft(length, '0');
            }
        }

        var result = new string('0', length);
        if (nums.Contains(result)) return new string('1', length);
        return result;
    }

    // Since we have a matrix
    //  n == nums.length
    //  nums[i].length == n
    private static string FindDifferentBinaryStringBetter(string[] nums)
    {
        StringBuilder result = new();

        for (int i = 0; i < nums.Length; i++)
        {
            result.Append(nums[i][i] == '0' ? '1' : '0');
        }

        return result.ToString();
    }
}