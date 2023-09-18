using BenchmarkDotNet.Attributes;

namespace Runner;

[ShortRunJob]
[MemoryDiagnoser]
public abstract class BaseBenchmark
{
    [GlobalSetup]
    public abstract void Setup();
}
