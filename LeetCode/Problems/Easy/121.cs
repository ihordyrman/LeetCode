namespace LeetCode.Problems.Easy;

/// <summary>
///     121. Best Time to Buy and Sell Stock
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
/// </summary>
public class _121
{
    private static readonly int[] Input = [7, 1, 5, 3, 6, 4];

    public static void Execute() => Console.WriteLine(MaxProfit(Input));

    [BenchmarkGen]
    public void FastMaxProfit() => MaxProfit(Input);

    private static int FastMaxProfit(int[] prices)
    {
        if (prices.Length == 0)
        {
            return 0;
        }

        var maxProfit = 0;
        int minPrice = prices[0];

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] > minPrice)
            {
                maxProfit = prices[i] - minPrice > maxProfit ? prices[i] - minPrice : maxProfit;
            }

            minPrice = prices[i] < minPrice ? prices[i] : minPrice;
        }

        return maxProfit;
    }

    // The new attempt after several years
    private static int MaxProfit(int[] prices)
    {
        if (prices is { Length: 0 or 1 }) return 0;

        int minPrice = prices[0];
        int profit = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            if (minPrice > prices[i])
            {
                minPrice = prices[i];
            }

            profit = Math.Max(profit, prices[i] - minPrice);
        }

        return profit;
    }
}