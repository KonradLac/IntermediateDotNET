namespace SimpleWarehouse;

internal class StockItem
{
    public StockItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    internal Product Product
    {
        get;
        init
        {
            if (value.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            field = value ?? throw new ArgumentNullException(nameof(value), "Product cannot be null.");
        }
    }
    internal int Quantity { get; set; } = 0;

    public override string ToString()
    {
        return $"StockItem[Product={Product}, Quantity={Quantity}]";
    }
}
