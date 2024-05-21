using GildedRose.Models;
using System.Collections.Generic;
using System.Linq;

namespace csharp;

public class GildedRefactored
{
    private readonly IList<Item> Items;

    private const int MaxQuality = 50;
    private const int QualityDecreaseConjured = 2;
    private const int QualityDecreaseNormal = 1;

    public GildedRefactored(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        var listResult = Items.Where(item => item.Name != "Sulfuras, Hand of Ragnaros");
        foreach (var item in listResult)
        {
            UpdateSellIn(item);

            if (item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstage(item);
            }
            else if (item.Name.Contains("Conjured"))
            {
                UpdateConjured(item);
            }
            else
            {
                UpdateRegularQuality(item);
            }
        }
    }

    private void UpdateRegularQuality(Item item)
    {
        if (item.Quality < MaxQuality)
        {
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - 2;
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
            else if (item.SellIn < 10)
            {
                item.Quality = item.Quality - QualityDecreaseNormal;
            }
            else if (item.Quality == 0)
            {
                // Nothing to do.
            }
            else
            {
                IncreaseQuality(item);
            }
        }
    }

    private void UpdateConjured(Item item)
    {
        if (item.Quality > 2)
        {
            item.Quality -= QualityDecreaseConjured;
        }
        else
        {
            item.Quality = 0;
        }
    }

    private void UpdateAgedBrie(Item item)
    {
        if (item.Quality < MaxQuality)
        {
            if (item.Quality < 2)
            {
                IncreaseQuality(item);
            }
            else
            {
                item.Quality = item.Quality + 2;
            }
        }
    }

    private void UpdateBackstage(Item item)
    {
        if (item.Quality < MaxQuality)
        {
            IncreaseQuality(item);
            if (item.SellIn < 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 5)
            {
                IncreaseQuality(item);
            }
        }

        if (item.Quality >= MaxQuality)
        {
            item.Quality = MaxQuality;
        }

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }
    private void UpdateSellIn(Item item)
    {
        item.SellIn--;
    }

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < MaxQuality)
        {
            item.Quality++;
        }
    }
}
