using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void SellInOf_NonLegendaryItems_Decreases()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Test Vest", SellIn = 5, Quality = 3 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 3 },
                new Item { Name = "Backstage passes to a TEST concert", SellIn =1,Quality = 5}
            };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(5-daysPassed, Items[0].SellIn);
                Assert.AreEqual(2-daysPassed,Items[1].SellIn);
                Assert.AreEqual(1 - daysPassed, Items[2].SellIn);
            }
            

            
        }

        [Test]
        public void QualityOf_NormalItems_DecreasesBeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test Vest", SellIn = 5, Quality = 3 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
