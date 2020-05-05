namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class ConjuredItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Conjured Mana Cake";
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();

            item.DecrementSellIn();

            if (item.SellIn < 0)
            {
                item.DecrementQuality();
                item.DecrementQuality();
            }
        }
    }
}
