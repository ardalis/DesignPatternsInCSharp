using BenchmarkDotNet.Running;

namespace DesignPatternsInCSharp.Benchmarks
{
    internal static class Program
    {
        private static void Main(string[] arguments)
        {
            BenchmarkSwitcher benchmarkSwitcher = new BenchmarkSwitcher(
                new[]
                    {
                        typeof(SingletonBenchmarks)
                    });
            benchmarkSwitcher.Run(arguments);
        }
    }
}
