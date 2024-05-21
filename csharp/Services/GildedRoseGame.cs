using csharp;
using GildedRose.Models;
using GildedRose.Services.Updaters;
using System.Collections.Generic;

namespace GildedRose.Services;
public class GildedRoseGame
{
    private readonly IList<Item> _items;
    private readonly Dictionary<string, IItemUpdater> _updaters;

    public GildedRoseGame(IList<Item> items)
    {
        _items = items;
        _updaters = new Dictionary<string, IItemUpdater>
            {
                { "Aged Brie", new AgedBrieUpdater() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasUpdater() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdater() },
                { "Conjured Mana Cake", new ConjuredItemUpdater() }
            };
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            GetUpdater(item).Update(item);
        }
    }

    private IItemUpdater GetUpdater(Item item)
    {
        if (_updaters.TryGetValue(item.Name, out var updater))
        {
            return updater;
        }
        return new StandardItemUpdater();
    }
}
