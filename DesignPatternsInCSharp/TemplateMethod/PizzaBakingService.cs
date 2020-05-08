namespace DesignPatternsInCSharp.TemplateMethod
{
    public class Pizza { }

    public class PizzaBakingService
    {
        private readonly LoggerAdapter _logger;
        private Pizza _pizza;

        public PizzaBakingService(LoggerAdapter logger)
        {
            _logger = logger;
        }

        public Pizza PreparePizza()
        {
            _pizza = new Pizza();
            PrepareCrust();

            AddToppings();

            Bake();

            Slice();

            return _pizza;
        }

        private void PrepareCrust()
        {
            _logger.Log("Rolling out and hand tossing the dough");
        }

        private void AddToppings()
        {
            _logger.Log("Adding pizza toppings");
        }

        private void Bake()
        {
            _logger.Log("Baking for 15 minutes");
        }

        private void Slice()
        {
            _logger.Log("Cutting into 8 slices.");
        }
    }
}
