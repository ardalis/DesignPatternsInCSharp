namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class AgedBrieRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Aged Brie";
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.IncrementQuality();
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }
    }
}
