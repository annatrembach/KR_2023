namespace KR_1.Products;

public class StandartProduct
{
    public StandartProduct(int id, string name, int cost)
    {
        Id = id;
        Cost = cost;
        Name = name;
    }

    public StandartProduct(string name, int cost)
    {
        Id = LastId + 1;
        Cost = cost;
        Name = name;
        LastId = Id;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public static int LastId { get; set; } = 6;

    private int cost;
    public int Cost
    {
        get { return cost; }
        set
        {
            cost = value;
            if (cost < 0)
            {
                cost = 0;
            }
        }
    }
    public string GetInfo()
    {
        return $"{Id}, {Name}, {Cost}";
    }
}
