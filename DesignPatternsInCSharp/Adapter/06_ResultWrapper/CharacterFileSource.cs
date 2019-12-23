using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter.ResultWrapper
{
    public class CharacterFileSource
    {
        public async Task<List<Character>> GetCharactersFromFile(string filename)
        {
            var characters = JsonConvert.DeserializeObject<List<Character>>(await File.ReadAllTextAsync(filename));

            return characters;
        }
    }
}
