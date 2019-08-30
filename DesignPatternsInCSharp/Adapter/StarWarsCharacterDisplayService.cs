using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter
{
    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters()
        {
            List<Person> people;
            //people = await GetPeopleFromSWAPI();
            people = await GetPeopleFromLocalFile();
            var sb = new StringBuilder();
            int nameWidth = 20;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"GENDER"}");
            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.Gender}");
            }

            return sb.ToString();

        }

        private Task<List<Person>> GetPeopleFromLocalFile()
        {
            return Task.FromResult(JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(@"C:\dev\GitHub\DesignPatternsInCSharp\DesignPatternsInCSharp\Adapter\People.json")));
        }

        private static async Task<List<Person>> GetPeopleFromSWAPI()
        {
            var people = new List<Person>();

            using (var client = new HttpClient())
            {
                string url = "https://swapi.co/api/people";
                string result = await client.GetStringAsync(url);
                people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
            }

            return people;
        }
    }
}
