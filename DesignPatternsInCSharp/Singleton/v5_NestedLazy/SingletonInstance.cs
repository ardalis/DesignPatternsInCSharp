using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.Singleton.v5
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;
        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;
            
            // This doesn't work with a static readonly field
            //SingletonTestHelpers.Reset(typeof(Singleton));

            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            // This no longer works
            //Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var result = Singleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            // This no longer works
            //Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            // configure logger to slow down the creation longer than the pauses below
            Logger.DelayMilliseconds = 10;

            var result1 = Singleton.Instance;
            Thread.Sleep(1);
            var result2 = Singleton.Instance;
            Thread.Sleep(1);
            var result3 = Singleton.Instance;

            var log = Logger.Output();

            // we can't check this since it depends on if this test is run alone or after others
            // Assert.Equal(1, log.Count(log => log.Contains("Constructor")));

            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact] // this test should only be run by itself
        public void NoLongerInitializesSingletonWhenAnotherStaticMemberIsReferenced()
        {
            Assert.Equal(0, Logger.Output().Count(log => log.Contains("Constructor")));

            // run this test by itself to see it really work
            var greeting = Singleton.GREETING;

            Assert.Equal(0, Logger.Output().Count(log => log.Contains("Constructor")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }
    }
}
