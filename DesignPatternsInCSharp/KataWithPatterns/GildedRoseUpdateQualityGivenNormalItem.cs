using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenNormalItem
    {
        private List<Item> _items = new List<Item>();
        private Item _item;
        private GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQualityGivenNormalItem()
        {
            _service = new GildedRose(_items);
            _item = GetNormalItem();
            _items.Add(_item);
        }

        private Item GetNormalItem()
        {
            return new Item { Name = "Normal Item", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void ReducesNormalItemQualityBy1GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 1, _item.Quality);
        }

        [Fact]
        public void ReducesNormalItemQualityBy2GivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 2, _item.Quality);
        }

        [Fact]
        public void DoesNotReduceQualityBelowZero()
        { 
            _item.Quality = 0;
            _service.UpdateQuality();

            Assert.Equal(0, _item.Quality);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(0)]
        public void DoesNotReduceQualityBelowZeroGivenNonPositiveSellIn(int initialQuality)
        {
            _item.SellIn = 0;
            _item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void ReducesNormalItemSellInBy1()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_SELL_IN - 1, _item.SellIn);
        }

        [Fact]
        public void DoesReduceSellInBelowZero()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(-1, _item.SellIn);
        }
    }
}
