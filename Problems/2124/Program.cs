using Xunit;

public class Program
{
    public static void Main()
    {
        Assert.True(CheckString("aaabbb"));
        Assert.False(CheckString("abab"));
        Assert.True(CheckString("bbb"));
    }

    private static bool CheckString(string s)
    {
        int a = s.LastIndexOf('a');
        int b = s.IndexOf('b');

        if (a == -1 || b == -1)
        {
            return true;
        }

        return a < b;

        // First approach with slow speed
        /*int lastA = -1;
        int lastB = s.Length + 1;
        int i = 0;
        while (i < s.Length)
        {
            if (s[i] == 'a') lastA = i;
            else
            {
                lastB = i;
            }

            if (lastA > lastB) return false;

            i++;
        }

        return true;*/
    }
}
