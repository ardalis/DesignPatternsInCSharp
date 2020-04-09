using System.IO;
using System.Text;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.SmartProxy.Tests
{

    public class FileConcurrentWrites
    {
        private readonly string _testFile = "output.txt";

        [Fact]
        public void RaisesExceptionWithDirectFileAccess()
        {
            var fs = new DefaultFile();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. ardalis.com\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");

            using var file = fs.OpenWrite(_testFile);
            Assert.Throws<IOException>(() =>
                //var file2 = fs.OpenWrite(_testFile)); can't run this code
                fs.OpenWrite(_testFile));

            file.Write(outputBytes1);
            //file2.Write(outputBytes2); // we never get here

            file.Close();
            //file2.Close(); // we never get here
        }

        [Fact]
        public void ManageReferences()
        {
            var fs = new FileSmartProxy();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. ardalis.com\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");
            using var file = fs.OpenWrite(_testFile);
            using var file2 = fs.OpenWrite(_testFile);

            file.Write(outputBytes1);
            file2.Write(outputBytes2);

            file.Close();
            file2.Close();
        }
    }
}
