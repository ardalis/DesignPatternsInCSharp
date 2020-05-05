using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenAgedBrie
    {
        private List<Item> _items = new List<Item>();
        private Item _item;
        private GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQualityGivenAgedBrie()
        {
            _service = new GildedRose(_items);
            _item = GetAgedBrie();
            _items.Add(_item);
        }

        private Item GetAgedBrie()
        {
            return new Item { Name = "Aged Brie", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void IncreasesAgedBrieQualityBy1GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 1, _item.Quality);
        }

        [Fact]
        public void IncreasesAgedBrieQualityBy2GivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 2, _item.Quality);
        }

        [Fact]
        public void DoesNotIncreaseQualityBeyond50()
        {
            _item.Quality = 50;
            _service.UpdateQuality();

            Assert.Equal(50, _item.Quality);
        }

        [Theory]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public void DoesNotIncreaseQualityAbove50GivenNonPositiveSellIn(int initialQuality)
        {
            _item.SellIn = 0;
            _item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.Equal(50, _item.Quality);
        }

        [Fact]
        public void ReducesAgedBrieSellInBy1()
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
