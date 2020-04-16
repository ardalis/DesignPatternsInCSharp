namespace DesignPatternsInCSharp.Adapter
{
    public static class ApiConstants
    {
        // NOTE: swapi.dev collection URIs must end with a / or you will get 301 redirect errors
        public const string SWAPI_BASE_URI = "https://swapi.dev/";
        public static readonly string SWAPI_PEOPLE_ENDPOINT = $"{SWAPI_BASE_URI}api/people/";
    }
}
