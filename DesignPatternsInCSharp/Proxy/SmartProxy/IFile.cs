using System.IO;

namespace DesignPatternsInCSharp.Proxy.SmartProxy
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}
