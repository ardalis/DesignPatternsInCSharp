using System.Threading.Tasks;
using Xunit;

namespace DesignPatternsInCSharp.Adapter
{
    public class AdapterTests
    {
        [Fact]
        public async Task ListCharactersGivenStarWarsApiAdapterShouldReturnSomething()
        {
            var swAdapter = new StarWarsApiPeopleAdapter();
            var service = new StarWarsCharacterDisplayService(swAdapter);

            var result = await service.ListCharacters();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ListCharactersGivenLocalFileAdapterShouldReturnSomething()
        {
            var localAdapter = new LocalFilePeopleAdapter();
            var service = new StarWarsCharacterDisplayService(localAdapter);

            var result = await service.ListCharacters();

            Assert.NotNull(result);
        }
    }
}
