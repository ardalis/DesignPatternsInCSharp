using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter.DependencyInjection
{
    public class CharacterFileSource
    {
        public async Task<List<Person>> GetCharactersFromFile(string filename)
        {
            var characters = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filename));

            return characters;
        }
    }
}
