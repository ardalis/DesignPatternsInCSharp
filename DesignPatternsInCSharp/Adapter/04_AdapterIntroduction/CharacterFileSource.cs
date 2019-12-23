using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter.AdapterIntroduction
{
    public class CharacterFileSource
    {
        public async Task<List<Person>> GetCharactersFromFile(string filename)
        {
            var characters = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filename));

            return characters;
        }
    }

    public class CharacterFileSourceAdapter : ICharacterSourceAdapter
    {
        private CharacterFileSource _fileSource = new CharacterFileSource();
        private string _fileName;

        public CharacterFileSourceAdapter(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await _fileSource.GetCharactersFromFile(_fileName);
        }
    }
}
