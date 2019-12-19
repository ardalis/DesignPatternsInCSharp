using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.Adapter.Initial
{
    public class TestRunner
    {
        private readonly ITestOutputHelper _output;

        public TestRunner(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task DisplayCharacters()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters();

            _output.WriteLine(result);
        }
    }
}
