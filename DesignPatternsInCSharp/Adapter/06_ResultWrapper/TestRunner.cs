using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.Adapter.ResultWrapper
{
    public class TestRunner
    {
        private readonly ITestOutputHelper _output;

        public TestRunner(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task DisplayCharactersFromFile()
        {
            string filename = @"Adapter/People.json";
            var service = new StarWarsCharacterDisplayService(
                new CharacterFileSourceAdapter(filename, new CharacterFileSource()));

            var result = await service.ListCharacters();

            _output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService(
                new StarWarsApiCharacterSourceAdapter(new StarWarsApi()));

            var result = await service.ListCharacters();

            _output.WriteLine(result);
        }
    }
}
