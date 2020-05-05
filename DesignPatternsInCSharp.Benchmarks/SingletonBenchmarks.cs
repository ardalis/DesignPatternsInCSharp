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
            var instances = new List<Singleton.v1.Singleton>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.Add(Singleton.v1.Singleton.Instance));
        }

        [Benchmark]
        public void Locking()
        {
            var instances = new List<Singleton.v2.Singleton>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.Add(Singleton.v2.Singleton.Instance));
        }

        [Benchmark]
        public void BetterLocking()
        {
            var instances = new List<Singleton.v3.Singleton>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.Add(Singleton.v3.Singleton.Instance));
        }

        [Benchmark]
        public void LessLazy()
        {
            var instances = new List<Singleton.v4.Singleton>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.Add(Singleton.v4.Singleton.Instance));
        }

        [Benchmark]
        public void NestedLazy()
        {
            var instances = new List<Singleton.v5.Singleton>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.Add(Singleton.v5.Singleton.Instance));
        }

        [Benchmark]
        public void LazyOfT()
        {
            var instances = new List<Singleton.v6.Singleton>();

            Parallel.ForEach(
                _strings,
                _parallelOptions,
                _ => instances.Add(Singleton.v6.Singleton.Instance));
        }
    }
}
