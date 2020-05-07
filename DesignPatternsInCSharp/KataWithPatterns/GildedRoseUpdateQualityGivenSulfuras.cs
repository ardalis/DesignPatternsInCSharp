using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQualityGivenSulfuras
    {
        private List<Item> _items = new List<Item>();
        private Item _item;
        private GildedRose _service;
        private const int INITIAL_QUALITY = 80;
        private const int INITIAL_SELL_IN = 0;

        public GildedRoseUpdateQualityGivenSulfuras()
        {
            _service = new GildedRose(_items);
            _item = GetSulfuras();
            _items.Add(_item);
        }

        private Item GetSulfuras()
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void DoesNotIncreaseQualityGivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY, _item.Quality);
        }

        [Fact]
        public void DoesNotIncreaseQualityGivenNonPositiveSellIn()
        {
            _item.SellIn = -1;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY, _item.Quality);
        }

        [Fact]
        public void DoesNotReduceSell()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_SELL_IN, _item.SellIn);
        }
    }
}
