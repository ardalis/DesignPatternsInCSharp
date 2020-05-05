using System.Collections.Generic;
using Xunit;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    public class GildedRoseUpdateQuality
    {
        [Fact]
        public void ReducesNormalItemQualityBy1()
        {
            int initialQuality = 10;
            var normalItem = new Item { Name = "Normal Item", Quality = initialQuality, SellIn = 15 };
            var service = new GildedRose(new List<Item> { normalItem });

            service.UpdateQuality();

            Assert.Equal(initialQuality - 1, normalItem.Quality);
        }
    }
}
