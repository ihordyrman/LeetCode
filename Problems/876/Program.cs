namespace _876;

/// <summary>
///     876. Middle of the Linked List
///     https://leetcode.com/problems/middle-of-the-linked-list/
/// </summary>
internal static class Program
{
    private static void Main() { }

    public static ListNode MiddleNode(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        ListNode tempNode = head;
        var count = 0;
        while (tempNode.next != null)
        {
            count++;
            tempNode = tempNode.next;
        }

        int middle = count / 2;

        if (count % 2 != 0)
        {
            middle++;
        }

        count = 0;
        while (count != middle)
        {
            count++;
            head = head.next;
        }

        return head;
    }
}

public class ListNode
{
    public readonly ListNode next;
    public readonly int val;

    protected ListNode(int x) => val = x;
}
