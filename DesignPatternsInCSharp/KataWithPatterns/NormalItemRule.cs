namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class NormalItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            // default rule
            return true;
        }

        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
        }
    }
}
