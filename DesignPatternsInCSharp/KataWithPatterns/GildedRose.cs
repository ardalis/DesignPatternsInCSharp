using System.Collections.Generic;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public abstract class RuleBase
    {
        public abstract bool IsMatch(ItemProxy item);
        public abstract void UpdateItem(ItemProxy item);
    }

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
    public class SulfurasRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public override void UpdateItem(ItemProxy item)
        {
            // do nothing
        }
    }
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

        public void UpdateAgedBrie(ItemProxy item)
        {
            item.IncrementQuality();
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }

        public void UpdateBackstagePasses(ItemProxy item)
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

        public void UpdateConjuredItem(ItemProxy item)
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

        public void UpdateQuality(ItemProxy item)
        {
            if (item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
                return;
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePasses(item);
                return;
            }
            if (item.Name == "Conjured Mana Cake")
            {
                UpdateConjuredItem(item);
                return;
            }
            var rules = new List<RuleBase>();
            rules.Add(new SulfurasRule());
            rules.Add(new NormalItemRule());
            foreach (var rule in rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
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
