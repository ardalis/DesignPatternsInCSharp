using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter
{
    public class StarWarsCharacterDisplayService
    {
        private readonly PeopleDataAdapter _peopleDataAdapter;

        public StarWarsCharacterDisplayService(PeopleDataAdapter peopleDataAdapter)
        {
            _peopleDataAdapter = peopleDataAdapter;
        }

        public async Task<string> ListCharacters()
        {
            var people = await _peopleDataAdapter.GetPeople();

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
