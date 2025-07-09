namespace LeetCode.Problems.Medium;

/// <summary>
///     1472. Design Browser History
/// </summary>
public class _1472
{
    public static void Execute()
    {
        BrowserHistory history = new("leetcode.com");
        history.Visit("google.com");
        history.Visit("facebook.com");
        history.Visit("youtube.com");
        history.Back(1).Display();
        history.Back(1).Display();
        history.Forward(1).Display();
        history.Visit("linkedin.com");
        history.Forward(2).Display();
        history.Back(2).Display();
        history.Back(7).Display();
    }
}

file class BrowserHistory
{
    private readonly List<string> history = [];
    private int index = 0;
    private int boundary = 0;
    public BrowserHistory(string homepage) => history.Add(homepage);

    public void Visit(string url)
    {
        if (index < history.Count - 1)
        {
            index++;
            boundary = index;
            history[index] = url;
            return;
        }

        history.Add(url);
        index++;
        boundary++;
    }

    public string Back(int steps)
    {
        if (index - steps <= 0)
        {
            index = 0;
            return history[0];
        }

        index -= steps;
        return history[index];
    }

    public string Forward(int steps)
    {
        if (index + steps >= boundary)
        {
            index = boundary;
            return history[boundary];
        }

        index += steps;
        return history[index];
    }
}