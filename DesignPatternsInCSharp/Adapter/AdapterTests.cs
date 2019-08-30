using System.Threading.Tasks;
using Xunit;

namespace DesignPatternsInCSharp.Adapter
{
    public class AdapterTests
    {
        [Fact]
        public async Task ListCharactersShouldReturnSomething()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters();

            Assert.NotNull(result);
        }
    }
}
