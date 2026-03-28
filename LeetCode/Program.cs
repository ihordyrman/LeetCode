using BenchmarkDotNet.Running;
using LeetCode.Problems.Easy.Benchmarks;

namespace LeetCode;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<_3512_MinOerations_Benchmark>();
    }
}
