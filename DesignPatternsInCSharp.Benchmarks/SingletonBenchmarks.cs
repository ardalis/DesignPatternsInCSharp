using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

namespace DesignPatternsInCSharp.Benchmarks
{
    [MeanColumn]
    [MemoryDiagnoser]
    [RankColumn]
    public class SingletonBenchmarks
    {
        private ParallelOptions _parallelOptions;

        private List<string> _strings;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _parallelOptions =
                new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 3,
                    };
            _strings = new List<string>() { "one", "two", "three" };
        }

        [Benchmark(Baseline = true)]
        public void Naive()
        {
            var instances = new ConcurrentDictionary<Singleton.v1.Singleton, byte>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.TryAdd(Singleton.v1.Singleton.Instance, 0));
        }

        [Benchmark]
        public void Locking()
        {
            var instances = new ConcurrentDictionary<Singleton.v2.Singleton, byte>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.TryAdd(Singleton.v2.Singleton.Instance, 0));
        }

        [Benchmark]
        public void BetterLocking()
        {
            var instances = new ConcurrentDictionary<Singleton.v3.Singleton, byte>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.TryAdd(Singleton.v3.Singleton.Instance, 0));
        }

        [Benchmark]
        public void LessLazy()
        {
            var instances = new ConcurrentDictionary<Singleton.v4.Singleton, byte>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.TryAdd(Singleton.v4.Singleton.Instance, 0));
        }

        [Benchmark]
        public void NestedLazy()
        {
            var instances = new ConcurrentDictionary<Singleton.v5.Singleton, byte>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.TryAdd(Singleton.v5.Singleton.Instance, 0));
        }

        [Benchmark]
        public void LazyOfT()
        {
            var instances = new ConcurrentDictionary<Singleton.v6.Singleton, byte>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.TryAdd(Singleton.v6.Singleton.Instance, 0));
        }
    }
}
