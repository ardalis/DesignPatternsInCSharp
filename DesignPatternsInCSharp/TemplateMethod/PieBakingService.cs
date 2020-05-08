using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class Pie : BakedPanFood { }

    public class PieBakingService : PanBakingServiceBase<Pie>
    {
        private readonly LoggerAdapter _logger;
        private Pie _pie;

        public PieBakingService(LoggerAdapter logger)
        {
            _logger = logger;
        }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out crust and pressing into pie pan");
        }

        protected override void AddToppings()
        {
            _logger.Log("Adding pie filling");
        }

        protected override void Cover()
        {
            _logger.Log("Adding lattice top");
        }

        protected override void Bake()
        {
            _logger.Log("Baking for 45 minutes");
        }

        protected override void Slice()
        {
            _logger.Log("Cutting into 6 slices.");
        }

    }
}
