using GildedRose.Models;

namespace GildedRose.Services.Updaters;
public class BackstagePassUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
        else if (item.SellIn <= 5)
        {
            IncreaseQuality(item, 3);
        }
        else if (item.SellIn <= 10)
        {
            IncreaseQuality(item, 2);
        }
        else
        {
            IncreaseQuality(item, 1);
        }
        item.SellIn--;
    }

    private void IncreaseQuality(Item item, int amount)
    {
        if (item.Quality + amount <= 50)
        {
            item.Quality += amount;
        }
        else
        {
            item.Quality = 50;
        }
    }
}