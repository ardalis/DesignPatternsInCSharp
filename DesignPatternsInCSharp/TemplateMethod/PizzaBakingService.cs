using Xunit.Sdk;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class Pizza : BakedPanFood { }

    public class PizzaBakingService : PanBakingServiceBase<Pizza>
    {
        private readonly LoggerAdapter _logger;
        private Pizza _pizza;

        public PizzaBakingService(LoggerAdapter logger)
        {
            _logger = logger;
        }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out and hand tossing the dough");
        }

        protected override void AddToppings()
        {
            _logger.Log("Adding pizza toppings");
        }

        protected override void Bake()
        {
            _logger.Log("Baking for 15 minutes");
        }

        protected override void Slice()
        {
            _logger.Log("Cutting into 8 slices.");
        }

    }
}
