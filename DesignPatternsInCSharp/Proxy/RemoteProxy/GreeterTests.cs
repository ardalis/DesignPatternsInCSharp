using Grpc.Net.Client;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatternsInCSharp.Proxy.RemoteProxy
{
    // NOTE: GreeterService must be running for these to pass
    // The remote proxy code is generated at build time and found in the /obj/Debug folder
    public class GreeterTests
    {
        // [Fact] 
        public async Task GreetReturnsResponseAsync()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GreeterService.Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new GreeterService.HelloRequest { Name = "GreeterClient" });

            Assert.Equal("Hello GreeterClient", reply.Message);
        }
    }
}
