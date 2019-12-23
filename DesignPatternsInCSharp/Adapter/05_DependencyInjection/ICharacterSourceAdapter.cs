using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter.DependencyInjection
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
