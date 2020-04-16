using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Adapter
{
    public class StarWarsApiPeopleAdapter : PeopleDataAdapter
    {
        public override async Task<List<Person>> GetPeople()
        {
            var people = new List<Person>();

            using (var client = new HttpClient())
            {
                string url = ApiConstants.SWAPI_PEOPLE_ENDPOINT;
                string result = await client.GetStringAsync(url);
                people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
            }

            return people;
        }
    }
}
