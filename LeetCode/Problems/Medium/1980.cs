using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

public class _1980
{
    private static readonly string[] Input = ["01", "10"]; // 11
    private static readonly string[] Input2 = ["00", "01"]; // 11
    private static readonly string[] Input3 = ["111", "011", "001"]; // 101
    private static readonly string[] Input4 = ["1010", "0000", "0101", "1111"]; // 0001

    public static void Execute()
    {
        Console.WriteLine($"Input {Input.Stringify()}, Output: {FindDifferentBinaryString(Input)}");
        Console.WriteLine($"Input {Input2.Stringify()}, Output: {FindDifferentBinaryString(Input2)}");
        Console.WriteLine($"Input {Input3.Stringify()}, Output: {FindDifferentBinaryString(Input3)}");
        Console.WriteLine($"Input {Input4.Stringify()}, Output: {FindDifferentBinaryString(Input4)}");
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
            if (!numbers.Contains(i))
            {
                return Convert.ToString(i, 2).PadLeft(length, '0');
            }
        }

        var result = new string('0', length);
        if (nums.Contains(result)) return new string('1', length);
        return result;
    }
}