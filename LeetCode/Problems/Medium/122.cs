namespace LeetCode.Problems.Medium;

/// <summary>
///     122. Best Time to Buy and Sell Stock II
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii
/// </summary>
public class _122
{
    private static readonly int[] Input1 = [7, 1, 5, 3, 6, 4];
    private static readonly int[] Input2 = [1, 2, 3, 4, 5];
    private static readonly int[] Input3 = [7, 6, 4, 3, 1];

    public static void Execute()
    {
        MaxProfit(Input1).Display();
        MaxProfit(Input2).Display();
        MaxProfit(Input3).Display();
    }

    private static int MaxProfit(int[] prices)
    {
        int profit = 0;

        for (int i = 0; i < prices.Length - 1; i++)
        {
            if (prices[i + 1] > prices[i])
            {
                profit += prices[i + 1] - prices[i];
            }
        }

        return profit;
    }
}