using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
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
                        AgedBrieUpdater(item);
                        break;
                    }

                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        BackstagePassUpdater(item);
                        break;
                    }

                    default:
                    {
                        if (item.Name.StartsWith("Conjured"))
                            ConjuredItemUpdater(item);
                        else
                            DefaultItemUpdater(item);
                        break;
                    }
                }
            }
        }

        private void ConjuredItemUpdater(Item item)
        {
            if (item.Quality > 1)
            {
                item.Quality = item.Quality - 2;
            }
            else if (item.Quality == 1)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

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

        public void AgedBrieUpdater(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;


            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0 && item.Quality < 50)
            {

                item.Quality = item.Quality + 1;

            }


        }

        public void BackstagePassUpdater(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                }

                if (item.SellIn < 6 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }

        }

        public void SulfurasUpdater(Item item)
        {

        }

        public void DefaultItemUpdater(Item item)
        {

            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

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