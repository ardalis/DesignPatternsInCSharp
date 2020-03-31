using System;
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
            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. ardalis.com\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");

            using var file = File.OpenWrite(_testFile);
            Assert.Throws<IOException>(() => 
                //var file2 = 
                File.OpenWrite(_testFile));

            file.Write(outputBytes1);
            //file2.Write(outputBytes2);

            file.Close();
            //file2.Close();
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
