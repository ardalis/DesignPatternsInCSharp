using System.Linq;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy.Tests
{
    public class ExpensiveToFullyLoadCreate
    {
        [Fact]
        public void LogsConstructionToHistory()
        {
            var obj = ExpensiveToFullyLoad.Create();

            Assert.Equal("Constructor called.", obj.History.Last());
        }

        [Fact]
        public void LogsCollectionLoadingToHistory()
        {
            var obj = ExpensiveToFullyLoad.Create();
            var list = obj.HomeEntities;

            Assert.Equal(2, obj.History.Count());

            var anotherList = obj.AwayEntities;
            Assert.Equal(3, obj.History.Count());

        }
    }
}
