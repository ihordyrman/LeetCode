namespace LeetCode.Problems.Easy;

/// <summary>
///     1281. Subtract the Product and Sum of Digits of an Integer
///     https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
/// </summary>
public class _1281
{
    private const int Input = 4421;

    [BenchmarkGen]
    public void SubtractProductAndSum() => SubtractProductAndSum(Input);

    private static int SubtractProductAndSum(int n)
    {
        var product = 1;
        var sum = 0;
        var haveZero = false;

        while (true)
        {
            if (n > 9)
            {
                if (n % 10 == 0)
                {
                    haveZero = true;
                }

                int value = n % 10;
                product *= value;
                sum += value;
                n /= 10;
            }
            else
            {
                if (n == 0)
                {
                    haveZero = true;
                }

                product *= n;
                sum += n;
                break;
            }
        }

        product = haveZero ? 0 : product;
        return product - sum;
    }
}
