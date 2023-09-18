using Xunit;

namespace Runner.Easy;

/// <summary>
///     121. Best Time to Buy and Sell Stock
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
/// </summary>
public class _121
{
    public _121()
    {
        Assert.Equal(FastMaxProfit(new[] { 7, 1, 5, 3, 6, 4 }), 5);
        Assert.Equal(FastMaxProfit(new[] { 7, 6, 4, 3, 1 }), 0);
    }

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
}
