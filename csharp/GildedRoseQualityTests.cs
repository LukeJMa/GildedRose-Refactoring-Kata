using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class GildedRoseQualityTests
    {
        [Test]
        public void QualityOf_Sulfuras_NeverDecreases()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
            };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(80, Items[0].Quality);
                Assert.AreEqual(80, Items[0].Quality);
                Assert.AreEqual(80, Items[0].Quality);
            }

        }

        [Test]
        public void QualityOf_NormalItems_DecreasesBy1_WhileSellInIsPositive()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "Test Vest", SellIn = 5, Quality = 3}};
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(3 - daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_NormalItems_DecreasesBy2_WhileSellInIsNonPositive()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "Test Vest", SellIn = 0, Quality = 10}};
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(10 -2* daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_NormalItems_DoesntGoNegative()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "Test Vest", SellIn = 2, Quality = 1}};
            GildedRose app = new GildedRose(Items);


            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(0, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_AgedBrie_IncreasesBy1_WhileSellInIsNonnegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 3 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(3+daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_AgedBrie_IncreasesBy2_WhileSellInIsNonpositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(10 + 2*daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_AgedBrie_DoesntGoAbove50()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 3, Quality = 49 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 }
            };
            GildedRose app = new GildedRose(Items);


            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(50, Items[0].Quality);
                Assert.AreEqual(50, Items[1].Quality);
            }
        }

        [Test]
        public void QualityOf_BackstagePasses_IncreasesBy1_WhileSellInGreaterThan10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 13, Quality = 3 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(3 + daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_BackstagePasses_IncreasesBy2_WhileSellInLessOrEqual10AndGreaterThan5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 3 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(3 + 2*daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_BackstagePasses_IncreasesBy3_WhileSellInLessOrEqual5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 3 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(3 + 3 * daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_BackstagePasses_DoesntGoAbove50()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 49 }
            };
            GildedRose app = new GildedRose(Items);


            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(50, Items[0].Quality);
                Assert.AreEqual(50, Items[1].Quality);
            }
        }

        [Test]
        public void QualityOf_BackstagePasses_ZerosAfterSellDate()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 15 },
            };
            GildedRose app = new GildedRose(Items);


            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(0, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_Conjured_DecreasesBy2_WhileSellInIsPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(20 -2* daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_ConjuredItems_DecreasesBy4_WhileSellInIsNonPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(20 - 4* daysPassed, Items[0].Quality);
            }
        }

        [Test]
        public void QualityOf_ConjuredItems_DoesntGoNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 1 } };
            GildedRose app = new GildedRose(Items);


            for (var daysPassed = 1; daysPassed <= 3; daysPassed++)
            {
                app.UpdateQuality();
                Assert.AreEqual(0, Items[0].Quality);
            }
        }
    }
}