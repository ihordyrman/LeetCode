namespace LeetCode.Structures;

public class ListNode
{
    public readonly ListNode Next;
    public readonly int Val;

    public ListNode(int val, ListNode next = null)
    {
        Val = val;
        Next = next;
    }
}
