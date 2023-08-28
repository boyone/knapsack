using FluentAssertions;
using Lib;

namespace Test;

public class KnapsackTest
{
    [Fact]
    public void ShouldGet6ItemsWithMaxCapacityAndValue()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("television", 50, 500));
        items.Add(new Item("candlesticks", 2, 300));
        items.Add(new Item("stereo", 35, 400));
        items.Add(new Item("laptop", 3, 1000));
        items.Add(new Item("food", 15, 50));
        items.Add(new Item("clothing", 20, 800));
        items.Add(new Item("jewelry", 1, 4000));
        items.Add(new Item("books", 100, 300));
        items.Add(new Item("printer", 18, 30));
        items.Add(new Item("refrigerator", 200, 700));
        items.Add(new Item("painting", 10, 1000));

        List<Item> expectedItems = new List<Item>();
        expectedItems.Add(new Item("painting", 10, 1000));
        expectedItems.Add(new Item("jewelry", 1, 4000));
        expectedItems.Add(new Item("clothing", 20, 800));
        expectedItems.Add(new Item("laptop", 3, 1000));
        expectedItems.Add(new Item("stereo", 35, 400));
        expectedItems.Add(new Item("candlesticks", 2, 300));
        
        Knapsack knapsack = new Knapsack();
        List<Item> toPickUp = knapsack.MaxCapacity(items, 75);
        
        Assert.Equal(6, toPickUp.Count);
        expectedItems.Should().BeEquivalentTo(toPickUp);
    }
}