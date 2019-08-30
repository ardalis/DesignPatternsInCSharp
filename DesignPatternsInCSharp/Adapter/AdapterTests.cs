using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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

    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters()
        {
            using (var client = new HttpClient())
            {
                string url = "https://swapi.co/api/people";
                string result = await client.GetStringAsync(url);
                var people =  JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;

                var sb = new StringBuilder();
                int nameWidth = 20;
                sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"GENDER"}");
                foreach (Person person in people)
                {
                    sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.Gender}");
                }

                return sb.ToString();
            }

        }
    }
}
