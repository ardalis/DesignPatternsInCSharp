using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter.ResultWrapper
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
