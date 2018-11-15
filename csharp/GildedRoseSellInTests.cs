using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseSellInTests
    {
        [TestCase("Test Vest")]
        [TestCase("Aged Brie")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        [TestCase("Conjured Mana Cake")]
        public void SellInOf_NonLegendaryItems_DecreasesBy1(string name)
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = name, SellIn = 3, Quality = 3},
            };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 5; daysPassed++)
            {
                app.UpdateStock();
                Assert.AreEqual(3 - daysPassed, Items[0].SellIn);
            }

        }

    }
}

