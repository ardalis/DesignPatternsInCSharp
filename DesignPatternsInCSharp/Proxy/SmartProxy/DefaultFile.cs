using System.IO;

namespace DesignPatternsInCSharp.Proxy.SmartProxy
{
    public class DefaultFile : IFile
    {
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}
