namespace SimpleWarehouse;

internal sealed record Product
{
    public Product(int id, string? name, ProductWeight weight, short price)
    {
        ID = id;
        Name = name;
        Weight = weight;
        Price = price;
    }

    internal int ID { get; init; }
    internal string? Name { get; init; }
    internal ProductWeight Weight
    {
        get;
        // Weight property with a constraint for the sake of the example
        init
        {
            if (value == ProductWeight.Heavy && Name!.StartsWith("Light"))
            {
                throw new ArgumentException("Heavy products cannot have names starting with 'Light'.");
            }
            field = value;
        }
    }
    internal short Price { get; init; }

    public override string ToString()
    {
        return $"Product[ID={ID}, Name={Name}, Weight={Weight}, Price={Price}]";
    }
}

