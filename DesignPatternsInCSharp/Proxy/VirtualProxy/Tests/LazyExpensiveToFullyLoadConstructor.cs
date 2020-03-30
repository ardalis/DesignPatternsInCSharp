using System.Linq;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy.Tests
{
    public class LazyExpensiveToFullyLoadConstructor
    {
        [Fact]
        public void LogsConstructionToHistory()
        {
            var obj = new LazyExpensiveToFullyLoad();

            Assert.Equal("Constructor called.", obj.History.Last());
        }

        [Fact]
        public void LogsCollectionLoadingToHistory()
        {
            var obj = new LazyExpensiveToFullyLoad();
            var list = obj.HomeEntities;

            Assert.Equal(2, obj.History.Count());

            var anotherList = obj.AwayEntities;
            Assert.Equal(3, obj.History.Count());
        }
    }
}
