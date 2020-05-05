namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class NormalItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            // default rule
            return true;
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.DecrementQuality();

            item.DecrementSellIn();

            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }
    }
}
