# Singleton

## Benchmarks

The Singleton implementations can be benchmarked using [BenchmarkDotNet](https://benchmarkdotnet.org/).



The benchmark implementation follows the Parallel unit tests but alters them slightly to isolate what is being measured.

```cs
[Benchmark(Baseline = true)]
public void Naive()
{
    var instances = new ConcurrentDictionary<Singleton.v1.Singleton, byte>();

    Parallel.ForEach(
        _strings,
        _parallelOptions,
        _ => instances.TryAdd(Singleton.v1.Singleton.Instance, 0));
}
```

A `ConcurrentDictionary` is used to ensure adding the instance to the collection is thread-safe for accurate allocation information.

### Building

The Benchmark project can be built and run from Visual Studio, although it is [recommended](https://benchmarkdotnet.org/articles/guides/good-practices.html) to run without to get the best results.

To build the Benchmark project from the command line use:

```sh
dotnet build -c Release
```

Or using MSBuild:

```sh
msbuild /t:Rebuild /p:Configuration=Release
```

> If you are having difficulty locating the `msbuild` executable, check the Visual Studio installation directory. 
> For example, `%PROGRAMFILES(X86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin`

### Running

Once built, run the console application:
```sh
DesignPatternsInCSharp.Benchmarks.exe
```

[Arguments](https://benchmarkdotnet.org/articles/guides/console-args.html) can be provided to the application if desired.

The console will display something similar to:

> Available Benchmark:
>  #0 SingletonBenchmarks
>
>
> You should select the target benchmark(s). Please, print a number of a benchmark (e.g. `0`) or a contained benchmark caption (e.g. `SingletonBenchmarks`).
> If you want to select few, please separate them with space ` ` (e.g. `1 2 3`).
> You can also provide the class name in console arguments by using --filter. (e.g. `--filter *SingletonBenchmarks*`).

### Results

Once run, the application will output the results to the console:

> BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.778 (1903/May2019Update/19H1)
> Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
> .NET Core SDK=3.1.201
>   [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
>   DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
> 
> 
> |        Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Rank |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
> |-------------- |---------:|----------:|----------:|------:|--------:|-----:|-------:|-------:|------:|----------:|
> |         Naive | 5.069 us | 0.1715 us | 0.5029 us |  1.00 |    0.00 |    2 | 0.6065 | 0.0038 |     - |   2.78 KB |
> |       Locking | 4.733 us | 0.0846 us | 0.1505 us |  0.89 |    0.07 |    1 | 0.6027 |      - |     - |    2.9 KB |
> | BetterLocking | 4.713 us | 0.0926 us | 0.0909 us |  0.86 |    0.07 |    1 | 0.6027 |      - |     - |   2.78 KB |
> |      LessLazy | 4.607 us | 0.0668 us | 0.0592 us |  0.84 |    0.07 |    1 | 0.6027 |      - |     - |   2.78 KB |
> |    NestedLazy | 4.679 us | 0.0878 us | 0.0822 us |  0.85 |    0.08 |    1 | 0.6027 |      - |     - |    2.9 KB |
> |       LazyOfT | 4.629 us | 0.0669 us | 0.0625 us |  0.84 |    0.07 |    1 | 0.6027 |      - |     - |   2.78 KB |

Note that different frameworks may yield different results.
See [Unrolling of small loops in different JIT versions](https://aakinshin.net/posts/unrolling-of-small-loops-in-different-jit-versions/) from [Awesome dotnet Performance](https://github.com/adamsitnik/awesome-dot-net-performance) for an example of this.

These results show that the `Naive` implementation allocates more in `Gen 0` while the other benchmarks do not. 
This is due to the implementation not being thread-safe.

Interestingly, the thread-safe implementations have a variable total amount of allocations.
Initial thoughts were that this was because of the `lockpad` object, but the results differ for `Locking` and `BetterLocking`.
The `IL` would need to be analyzed further to check for differences in the generated code.

The best implementations in terms of speed and allocation is the `LessLazy` and `LazyOfT` implementations.
Keep in mind that the `LessLazy` implementation does not lazily initialize if multiple `static` fields are used.
For this reason, the best implementation in terms of speed and allocation is the `LazyOfT` implementation.