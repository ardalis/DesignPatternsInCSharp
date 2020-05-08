using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class ColdVeggiePizzaBakingServicePrepare
    {
        private readonly ITestOutputHelper _output;
        public ColdVeggiePizzaBakingServicePrepare(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReturnsAPizza()
        {
            var logger = new LoggerAdapter();
            var service = new ColdVeggiePizzaBakingService(logger);

            var pizza = service.Prepare();

            Assert.NotNull(pizza);
            _output.WriteLine(logger.Dump());
        }
    }
}
