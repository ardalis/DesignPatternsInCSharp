using System;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class PizzaBakingServicePreparePizza : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly LoggerAdapter _logger = new LoggerAdapter();
        private readonly PizzaBakingService _service;
        public PizzaBakingServicePreparePizza(ITestOutputHelper output)
        {
            _output = output;
            _service = new PizzaBakingService(_logger);
        }

        public void Dispose()
        {
            _output.WriteLine(_logger.Dump());
        }

        [Fact]
        public void ReturnsAPizza()
        {
            var pizza = _service.Prepare();

            Assert.NotNull(pizza);
        }

        [Fact]
        public void SetsCrustTypeToThin()
        {
            var pizza = _service.Prepare();

            Assert.Equal("Thin", pizza.CrustType);
        }

        [Fact]
        public void SetsToppingsToPepSaus()
        {
            var pizza = _service.Prepare();

            Assert.Equal(2, pizza.Toppings.Count);
            Assert.Contains(pizza.Toppings, t => t == "Pepperoni");
            Assert.Contains(pizza.Toppings, t => t == "Sausage");
        }

        [Fact]
        public void SetsBakedToTrue()
        {
            var pizza = _service.Prepare();

            Assert.True(pizza.WasBaked);
        }

        [Fact]
        public void SetsNumSlicesTo8()
        {
            var pizza = _service.Prepare();

            Assert.Equal(8, pizza.NumSlices);
        }

    }
}
