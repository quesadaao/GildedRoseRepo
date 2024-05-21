using GildedRose.Models;

namespace GildedRose.Services.Updaters;

public class AgedBrieUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        IncreaseQuality(item, 1);
        item.SellIn--;
        if (item.SellIn < 0)
        {
            IncreaseQuality(item, 1);
        }
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