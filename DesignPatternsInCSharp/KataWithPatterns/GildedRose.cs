using System.Collections.Generic;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    /// <summary>
    /// Source: https://github.com/emilybache/GildedRose-Refactoring-Kata/tree/master/csharpcore
    /// Instructions: https://github.com/ardalis/kata-catalog/blob/master/katas/Gilded%20Rose.md
    /// Cannot change the Items collection
    /// </summary>
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality(ItemProxy item)
        {
            var engine = new ItemQualityRuleEngine.Builder()
                .WithAgedBrieRule()
                .WithBackstagePassesRule()
                .WithConjuredItemRule()
                .WithSulfurasRule()
                .Build();
            engine.ApplyRules(item);
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQuality(new ItemProxy(Items[i]));
            }
        }
    }
}
