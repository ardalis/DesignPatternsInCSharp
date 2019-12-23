using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.Adapter.AdapterIntroduction
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
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters(CharacterSource.File);

            _output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters(CharacterSource.Api);

            _output.WriteLine(result);
        }
    }
}
