using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter.TwoProviderClasses
{
    public partial class StarWarsCharacterDisplayService
    {
        public enum CharacterSource
        {
            File,
            Api
        }
        public async Task<string> ListCharacters(CharacterSource source)
        {
            List<Person> people;
            if (source == CharacterSource.File)
            {
                string filePath = @"Adapter/People.json";
                var characterSource = new CharacterFileSource();
                people = await characterSource.GetCharactersFromFile(filePath);
            } 
            else if (source == CharacterSource.Api)
            {
                var swapiSource = new StarWarsApi();
                people = await swapiSource.GetCharacters();
            }
            else
            {
                throw new Exception("Invalid character source");
            }
            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"HAIR"}");
            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}
