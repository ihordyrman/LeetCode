namespace _278;

static class Program
{
    private static int FirstBadVersion(int n)
    {
        int left = 1;
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

    private static bool IsBadVersion(int version)
    {
        return false;
    }
}