using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQuality
    {
        private List<Item> _items = new List<Item>();
        private GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQuality()
        {
            _service = new GildedRose(_items);
        }

        private Item GetNormalItem()
        {
            return new Item { Name = "Normal Item", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void ReducesNormalItemQualityBy1()
        {
            var normalItem = GetNormalItem();
            _items.Add(normalItem);
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 1, normalItem.Quality);
        }

        [Fact]
        public void DoesNotReduceQualityBelowZero()
        {
            var normalItem = GetNormalItem();
            normalItem.Quality = 0;
            _items.Add(normalItem);
            _service.UpdateQuality();

            Assert.Equal(0, normalItem.Quality);
        }

        [Fact]
        public void ReducesNormalItemSellInBy1()
        {
            var normalItem = GetNormalItem();
            _items.Add(normalItem);
            _service.UpdateQuality();

            Assert.Equal(INITIAL_SELL_IN - 1, normalItem.SellIn);
        }

        [Fact]
        public void DoesReduceSellInBelowZero()
        {
            var normalItem = GetNormalItem();
            normalItem.SellIn = 0;
            _items.Add(normalItem);
            _service.UpdateQuality();

            Assert.Equal(-1, normalItem.SellIn);
        }


    }
}
