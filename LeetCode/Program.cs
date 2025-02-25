using BenchmarkDotNet.Running;
using LeetCode.Problems.Easy.Benchmarks;

namespace LeetCode;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<_1_TwoSum_Benchmark>();
        BenchmarkRunner.Run<_1290_ConvertBinaryNumber_Benchmark>();
    }
}
