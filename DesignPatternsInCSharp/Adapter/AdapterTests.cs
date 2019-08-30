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

            await CallListCharactersAndAssertContainsExpectedCharacters(service);
        }

        [Fact]
        public async Task ListCharactersGivenLocalFileAdapterShouldReturnSomething()
        {
            var localAdapter = new LocalFilePeopleAdapter();
            var service = new StarWarsCharacterDisplayService(localAdapter);

            await CallListCharactersAndAssertContainsExpectedCharacters(service);
        }

        [Fact]
        public async Task ListCharactersGivenThirdPartyApiAdapterShouldReturnSomething()
        {
            var adapter = new ThirdPartyApiAdapter();
            var service = new StarWarsCharacterDisplayService(adapter);

            await CallListCharactersAndAssertContainsExpectedCharacters(service);
        }

        private static async Task CallListCharactersAndAssertContainsExpectedCharacters(StarWarsCharacterDisplayService service)
        {
            var result = await service.ListCharacters();

            Assert.Contains("Luke Skywalker", result);
            Assert.Contains("Darth Vader", result);
        }
    }
}
