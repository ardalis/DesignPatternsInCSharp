using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenConjuredItem
    {
        private List<Item> _items = new List<Item>();
        private Item _item;
        private GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQualityGivenConjuredItem()
        {
            _service = new GildedRose(_items);
            _item = GetConjuredItem();
            _items.Add(_item);
        }

        private Item GetConjuredItem()
        {
            return new Item { Name = "Conjured Mana Cake", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void ReducesConjuredItemQualityBy2GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 2, _item.Quality);
        }

        [Fact]
        public void ReducesConjuredItemQualityBy4GivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 4, _item.Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void DoesNotReduceQualityBelowZero(int initialQuality)
        { 
            _item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.Equal(0, _item.Quality);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(3)]
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
        public void ReducesConjuredItemSellInBy1()
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
