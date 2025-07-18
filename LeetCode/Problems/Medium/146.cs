namespace LeetCode.Problems.Medium;

public class _146
{
    public static void Execute()
    {
        var cache = new LRUCache(2);
        cache.Put(1, 1);    // cache is {1=1}
        cache.Put(2, 2);    // cache is {1=1, 2=2}
        cache.Get(1);       // return 1
        cache.Put(3, 3);    // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        cache.Get(2);       // returns -1 (not found)
        cache.Put(4, 4);    // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        cache.Get(1);       // return -1 (not found)
        cache.Get(3);       // return 3
        cache.Get(4);       // return 4
    }
}


// ReSharper disable once InconsistentNaming

// Time Limit Exceeded. todo: need to finish
public class LRUCache(int capacity)
{
    private readonly Dictionary<int, (int value, DateTime accessed)> cache = new(capacity);

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            cache[key]= (cache[key].value, DateTime.Now);
            return cache[key].value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            cache[key] = (value, DateTime.Now);
            return;
        }

        if (cache.Keys.Count < capacity)
        {
            cache.Add(key, (value, DateTime.Now));
            return;
        }

        var index = cache.Keys.First();
        var leastRecent = cache[index].accessed;
        foreach (var (x, (y, accessed)) in cache)
        {
            if (leastRecent > accessed)
            {
                leastRecent = accessed;
                index = x;
            }
        }

        cache.Remove(index);
        cache.Add(key, (value, DateTime.Now));
    }
}