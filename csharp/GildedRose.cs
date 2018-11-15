using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private const int MaxQuality = 50;

        public GildedRose(IList<Item> items)
        {
            var copy = new List<Item>();
            copy = copy.Concat(items).ToList();
            Items = copy;
        }

        public void UpdateStock()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                    {
                        SulfurasUpdater(item);
                        break;
                    }

                    case "Aged Brie":
                    {
                        SellInUpdater(item);
                        AgedBrieQualityUpdater(item);
                        break;
                    }

                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        SellInUpdater(item);
                        BackstagePassQualityUpdater(item);
                        break;
                    }

                    default:
                    {
                        SellInUpdater(item);
                        if (item.Name.StartsWith("Conjured"))
                            ConjuredItemQualityUpdater(item);
                        else
                            DefaultItemQualityUpdater(item);
                        break;
                    }
                }
            }
        }

        private void SellInUpdater(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private void ConjuredItemQualityUpdater(Item item)
        {
            if (item.Quality > 1)
            {
                item.Quality = item.Quality - 2;
            }
            else if (item.Quality == 1)
            {
                item.Quality = item.Quality - 1;
            }
            
            if (item.SellIn < 0)
            {
                if (item.Quality > 1)
                {
                    item.Quality = item.Quality - 2;
                }
                else if (item.Quality == 1)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        public void AgedBrieQualityUpdater(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
            
            if (item.SellIn < 0 && item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public void BackstagePassQualityUpdater(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 10 && item.Quality < MaxQuality)
                {
                    item.Quality = item.Quality + 1;
                }

                if (item.SellIn < 5 && item.Quality < MaxQuality)
                {
                    item.Quality = item.Quality + 1;
                }
            }
            
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }

        }

        public void SulfurasUpdater(Item item)
        {
            // Intentionally blank. Sulfuras does not change.
        }

        public void DefaultItemQualityUpdater(Item item)
        {

            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }


            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }

        }

    }
}