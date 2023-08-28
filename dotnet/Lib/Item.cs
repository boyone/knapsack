namespace Lib;

public class Item
{
    public String name { set; get; }
    public int weight { set; get; }
    public double value  { set; get; }

    public Item(String name, int weight, double value)
    {
        this.name = name;
        this.weight = weight;
        this.value = value;
    }
}