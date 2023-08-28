namespace Lib;

public class Knapsack
{
    public List<Item> MaxCapacity(List<Item> items, int maxCapacity)
    {
        // build up dynamic programming table
        double[,] table = new double[items.Count + 1, maxCapacity + 1];
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            for (int capacity = 1; capacity <= maxCapacity; capacity++)
            {
                double prevItemValue = table[i, capacity];
                if (capacity >= item.weight)
                {
                    // item fits in knapsack
                    double valueFreeingWeightForItem = table[i, capacity - item.weight];
                    // only take if more valuable than previous item
                    table[i + 1, capacity] = Math.Max(valueFreeingWeightForItem + item.value, prevItemValue);
                }
                else
                {
                    // no room for this item
                    table[i + 1, capacity] = prevItemValue;
                }
            }
        }

        // figure out solution from table
        List<Item> solution = new List<Item>();
        int mcapacity = maxCapacity;
        for (int i = items.Count; i > 0; i--)
        {
            // work backwards
            // was this item used?
            if (table[i - 1, mcapacity] != table[i, mcapacity])
            {
                solution.Add(items[i - 1]);
                // if the item was used, remove its weight
                mcapacity -= items[i - 1].weight;
            }
        }

        return solution;
    }
}