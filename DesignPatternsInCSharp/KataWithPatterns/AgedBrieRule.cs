namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class AgedBrieRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.IncrementQuality();
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Aged Brie";
        }
    }
}
