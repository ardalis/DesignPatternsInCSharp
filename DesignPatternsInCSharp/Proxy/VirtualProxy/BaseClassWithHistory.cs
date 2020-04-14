using System.Collections.Generic;

namespace DesignPatternsInCSharp.Proxy.VirtualProxy
{
    public abstract class BaseClassWithHistory
    {
        public List<string> History { get; } = new List<string>();
    }
}
