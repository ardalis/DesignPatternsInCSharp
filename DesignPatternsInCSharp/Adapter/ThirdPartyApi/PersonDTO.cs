using Newtonsoft.Json;

namespace DesignPatternsInCSharp.Adapter.ThirdPartyApi
{
    public class PersonDTO
    {
        [JsonProperty("name")]
        public string CharacterName { get; set; }
        [JsonConverter(typeof(GenderConverter))]
        public Gender Gender { get; set; }
    }

}
