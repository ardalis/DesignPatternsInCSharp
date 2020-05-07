namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class SulfurasRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public override void AdjustQuality(ItemProxy item)
        {
            // do nothing
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            // do nothing
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            // do nothing
        }
    }
}
