namespace LeetCode.Problems.Medium;

using KeyValue = (int key, int value);

public class _146
{
    public static void Execute()
    {
        var cache = new LRUCacheBetter(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1).Display();
        cache.Put(3, 3);
        cache.Get(2).Display();
        cache.Put(4, 4);
        cache.Get(1).Display();
        cache.Get(3).Display();
        cache.Get(4).Display();

        Console.WriteLine(new string('-', 10));

        cache = new LRUCacheBetter(2);
        cache.Put(1, 0);
        cache.Put(2, 2);
        cache.Get(1).Display();
        cache.Put(3, 3);
        cache.Get(2).Display();
        cache.Put(4, 4);
        cache.Get(1).Display();
        cache.Get(3).Display();
        cache.Get(4).Display();

        Console.WriteLine(new string('-', 10));

        cache = new LRUCacheBetter(2);
        cache.Put(2, 1);
        cache.Put(1, 1);
        cache.Put(2, 3);
        cache.Put(4, 1);
        cache.Get(1).Display();
        cache.Get(2).Display();

        Console.WriteLine(new string('-', 10));

        cache = new LRUCacheBetter(2);
        cache.Get(2).Display();
        cache.Put(2, 6);
        cache.Get(1).Display();
        cache.Put(1, 5);
        cache.Put(1, 2);
        cache.Get(1).Display();
        cache.Get(2).Display();
    }
}

// Just embarrassing first attempt
public class LRUCache(int capacity)
{
    private readonly Dictionary<int, int> keyIndex = [];
    private readonly Dictionary<int, int> indexKey = [];
    private readonly SortedDictionary<DateTime, int> dateIndex = [];
    private readonly int[] values = new int[capacity];
    private readonly DateTime[] dates = new DateTime[capacity];

    public int Get(int key)
    {
        if (keyIndex.TryGetValue(key, out var index))
        {
            var oldDate = dates[index];
            var date = DateTime.Now;
            dates[index] = date;
            dateIndex.Remove(oldDate);
            dateIndex[date] = index;
            return values[index];
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        var date = DateTime.Now;
        DateTime oldDate;

        if (keyIndex.TryGetValue(key, out var index))
        {
            values[index] = value;
            oldDate = dates[index];
            dates[index] = date;
            dateIndex[date] = index;
            dateIndex.Remove(oldDate);
            indexKey[index] = key;
            return;
        }

        if (keyIndex.Count < capacity)
        {
            index = keyIndex.Count;
            keyIndex.Add(key, index);
            values[index] = value;
            dates[index] = date;
            dateIndex[date] = index;
            indexKey.Add(index, key);
            return;
        }

        index = dateIndex.First().Value;

        var oldKey = indexKey[index];
        oldDate = dates[index];
        dateIndex.Remove(oldDate);
        indexKey.Remove(index);
        keyIndex.Remove(oldKey);
        indexKey.Add(index, key);
        keyIndex.Add(key, index);
        dateIndex.Add(date, index);
        dates[index] = date;
        values[index] = value;
    }
}

public class LRUCacheBetter(int capacity)
{
    private readonly LinkedList<KeyValue> list = [];
    private readonly Dictionary<int, LinkedListNode<KeyValue>> keys = [];

    public int Get(int key)
    {
        if (!keys.TryGetValue(key, out var node))
        {
            return -1;
        }

        list.Remove(node);
        list.AddFirst(node);
        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        var node = new LinkedListNode<KeyValue>((key, value));
        list.AddFirst(node);

        if (keys.TryGetValue(key, out var oldNode))
        {
            list.Remove(oldNode);
        }
        else if (list.Count > capacity)
        {
            keys.Remove(list.Last!.Value.key);
            list.RemoveLast();
        }

        keys[key] = node;
    }
}