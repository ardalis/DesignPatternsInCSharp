using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenBackstagePasses
    {
        private List<Item> _items = new List<Item>();
        private Item _item;
        private GildedRose _service;
        private const int INITIAL_QUALITY = 20;
        private const int INITIAL_SELL_IN = 15;

        public GildedRoseUpdateQualityGivenBackstagePasses()
        {
            _service = new GildedRose(_items);
            _item = GetBackstagePasses();
            _items.Add(_item);
        }

        private Item GetBackstagePasses()
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void IncreasesBackstagePassesQualityBy1GivenSellInOver10(int initialSellIn)
        {
            _item.SellIn = initialSellIn;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 1, _item.Quality);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void IncreasesBackstagePassesQualityBy2GivenSellIn6To10Days(int initialSellIn)
        {
            _item.SellIn = initialSellIn;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 2, _item.Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void IncreasesBackstagePassesQualityBy3GivenSellIn1To5Days(int initialSellIn)
        {
            _item.SellIn = initialSellIn;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 3, _item.Quality);
        }

        [Theory]
        [InlineData(50, 11)]
        [InlineData(49, 11)]
        [InlineData(50, 10)]
        [InlineData(49, 10)]
        [InlineData(48, 10)]
        [InlineData(50, 5)]
        [InlineData(49, 5)]
        [InlineData(48, 5)]
        [InlineData(47, 5)]
        public void DoesNotIncreaseQualityBeyond50NoMatterHowManyDaysRemain(int initialQuality, int initialSellIn)
        {
            _item.Quality = initialQuality;
            _item.SellIn = initialSellIn;
            _service.UpdateQuality();

            Assert.Equal(50, _item.Quality);
        }

        [Fact]
        public void ReducesBackstagePassesQualityToZeroGivenNonPositiveSellIn()
        {
            _item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(0, _item.Quality);
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
