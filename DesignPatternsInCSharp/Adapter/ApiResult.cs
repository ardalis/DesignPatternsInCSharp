using System.Collections.Generic;

namespace DesignPatternsInCSharp.Adapter
{
    public class ApiResult<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
