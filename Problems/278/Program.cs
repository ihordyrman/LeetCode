namespace _278;

internal static class Program
{
    public static void Main()
    {
    }

    private static int FirstBadVersion(int n)
    {
        var left = 1;
        int right = n;
        while (left < right)
        {
            int middle = left + (right - left) / 2;
            if (IsBadVersion(middle))
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }

    private static bool IsBadVersion(int version) => false;
}
