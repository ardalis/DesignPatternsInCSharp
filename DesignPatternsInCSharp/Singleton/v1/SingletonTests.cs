using System.Linq;
using Xunit;

namespace DesignPatternsInCSharp.Singleton.v1
{
    public class SingletonInstance
    {
        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            var result = Singleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);
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

        }
    }
}
