using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class PieBakingServicePreparePie
    {
        private readonly ITestOutputHelper _output;
        public PieBakingServicePreparePie(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReturnsAPie()
        {
            var logger = new LoggerAdapter();
            var service = new PieBakingService(logger);
            
            var pie = service.Prepare();

            Assert.NotNull(pie);
            _output.WriteLine(logger.Dump());
        }
    }
}
