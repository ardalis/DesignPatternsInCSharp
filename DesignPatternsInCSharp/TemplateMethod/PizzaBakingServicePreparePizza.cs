using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class PizzaBakingServicePreparePizza
    {
        private readonly ITestOutputHelper _output;
        public PizzaBakingServicePreparePizza(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReturnsAPizza()
        {
            var logger = new LoggerAdapter();
            var service = new PizzaBakingService(logger);
            
            var pizza = service.PreparePizza();

            Assert.NotNull(pizza);
            _output.WriteLine(logger.Dump());
        }
    }
}
