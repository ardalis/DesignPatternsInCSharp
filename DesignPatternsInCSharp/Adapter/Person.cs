namespace DesignPatternsInCSharp.Adapter
{
    public class Person
    {
        public string Name { get; set;  }
        public string Gender { get; set; }
        [Newtonsoft.Json.JsonProperty("hair_color")]
        public string HairColor { get; set; }
    }
}
