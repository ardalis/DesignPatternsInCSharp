namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class BackstagePassesRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.IncrementQuality();
            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality();
            }
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.ResetQuality();
            }
        }
    }
}
