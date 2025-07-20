namespace LeetCode.Problems.Easy;

/// <summary>
///     202. Happy Number
///     https://leetcode.com/problems/happy-number
/// </summary>
public class _202
{
    public static void Execute()
    {
        IsHappy(1).Display();
        IsHappy(2).Display();
        IsHappy(3).Display();
    }

    private static bool IsHappy(int n)
    {
        var numbers = new HashSet<int>();
        while (true)
        {
            if (!numbers.Add(n)) break;
            var sum = 0;
            var sqrSum = 0;
            while (n > 0)
            {
                var temp = n % 10;
                sum += temp;
                sqrSum += temp * temp;
                n /= 10;
            }

            if (sum == 1) return true;
            n = sqrSum;
        }

        return false;
    }
}