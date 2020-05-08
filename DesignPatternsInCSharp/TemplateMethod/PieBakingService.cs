namespace DesignPatternsInCSharp.TemplateMethod
{
    public class Pie { }

    public class PieBakingService
    {
        private readonly LoggerAdapter _logger;
        private Pie _pie;

        public PieBakingService(LoggerAdapter logger)
        {
            _logger = logger;
        }

        public Pie PreparePie()
        {
            _pie = new Pie();

            PrepareCrust();

            AddFilling();

            Cover();

            Bake();

            Slice();

            return _pie;
        }

        private void PrepareCrust()
        {
            _logger.Log("Rolling out crust and pressing into pie pan");
        }

        private void AddFilling()
        {
            _logger.Log("Adding pie filling");
        }

        private void Cover()
        {
            _logger.Log("Adding lattice top");
        }
        private void Bake()
        {
            _logger.Log("Baking for 45 minutes");
        }

        private void Slice()
        {
            _logger.Log("Cutting into 6 slices.");
        }
    }
}
