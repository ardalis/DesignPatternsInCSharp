namespace DesignPatternsInCSharp.TemplateMethod
{
    public class PizzaBakingService : PanFoodServiceBase<Pizza>
    {
        public PizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out and hand tossing the dough");
            _item.CrustType = "Thin";
        }

        protected override void AddToppings()
        {
            _logger.Log("Adding pizza toppings");
            _item.Toppings.Add("Pepperoni");
            _item.Toppings.Add("Sausage");
        }

        protected override void Bake()
        {
            _logger.Log("Baking for 15 minutes");
            _item.WasBaked = true;
        }

        protected override void Slice()
        {
            _logger.Log("Cutting into 8 slices.");
            _item.NumSlices = 8;
        }
    }
}
