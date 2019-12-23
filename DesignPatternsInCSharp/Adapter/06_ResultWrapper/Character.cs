namespace DesignPatternsInCSharp.Adapter.ResultWrapper
{
    public class Character
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [Newtonsoft.Json.JsonProperty("hair_color")]
        public string Hair { get; set; }
    }
}
