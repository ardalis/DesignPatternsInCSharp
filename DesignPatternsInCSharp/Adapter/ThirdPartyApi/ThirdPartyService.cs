using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace DesignPatternsInCSharp.Adapter.ThirdPartyApi
{
    public class ThirdPartyService
    {
        public async System.Threading.Tasks.Task<List<PersonDTO>> ListCharactersAsync(int count)
        {
            var people = new List<PersonDTO>();

            using (var client = new HttpClient())
            {
                string url = ApiConstants.SWAPI_PEOPLE_ENDPOINT;
                string result = await client.GetStringAsync(url);
                people = JsonConvert.DeserializeObject<PersonDTOApiResult>(result).Results;
            }

            return people.Take(count).ToList();
        }
    }

}
