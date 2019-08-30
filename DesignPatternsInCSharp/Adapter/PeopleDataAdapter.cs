using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter
{
    public abstract class PeopleDataAdapter
    {
        public abstract Task<List<Person>> GetPeople();
    }
}
