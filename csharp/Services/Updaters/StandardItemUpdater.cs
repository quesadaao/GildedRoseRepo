using GildedRose.Models;

namespace GildedRose.Services.Updaters;

public class StandardItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        DecreaseQuality(item, 1);
        item.SellIn--;
        if (item.SellIn < 0)
        {
            DecreaseQuality(item, 1);
        }
    }

    private void DecreaseQuality(Item item, int amount)
    {
        if (item.Quality - amount >= 0)
        {
            item.Quality -= amount;
        }
        else
        {
            item.Quality = 0;
        }
    }
}
