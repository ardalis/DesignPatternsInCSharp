using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.Singleton.v1
{
    [CollectionDefinition("one", DisableParallelization = true)]
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;
        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            var result = Singleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);
        }
    }

    [CollectionDefinition("two", DisableParallelization = true)]
    public class SingletonInstance2
    {
        private readonly ITestOutputHelper _output;
        public SingletonInstance2(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Logger.Clear();
            var result1 = Singleton.Instance;
            var result2 = Singleton.Instance;
            var result3 = Singleton.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }
    }
}
