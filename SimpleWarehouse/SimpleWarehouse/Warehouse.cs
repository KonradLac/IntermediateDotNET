namespace SimpleWarehouse;

internal class Warehouse
{
    public Warehouse(){}
    public Warehouse(List<StockItem> initialStockItems)
    {
        stockItems = initialStockItems ?? throw new ArgumentNullException(nameof(initialStockItems), "Initial stock items cannot be null.");
    }

    private readonly List<StockItem> stockItems = [];

    /// <summary>
    /// Adds a stock item.
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void AddStockItem(StockItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Stock item cannot be null.");
        }
        stockItems.Add(item);
    }

    /// <summary>
    /// Removes a stock item with a given ID.
    /// </summary>
    /// <param name="ID"></param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ProductNotFoundException"></exception>
    public void RemoveStockItem(int ID)
    {
        if(ID <= 0)
        {
            throw new ArgumentException("ID must be a positive integer.", nameof(ID));
        }
        if(stockItems.Count == 0)
        {
            Console.WriteLine("No stock items to remove.");
            return;
        }
        if(!stockItems.Any(item => item.Product.ID == ID))
        {
            throw new ProductNotFoundException($"No product found with ID {ID}.");
        }
        stockItems.RemoveAll(item => item.Product.ID == ID);
    }

    /// <summary>
    /// Returns all stock items with a given ID.
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public List<StockItem> GetStockItem(int ID)
    {
        if (ID <= 0)
        {
            throw new ArgumentException("ID must be a positive integer.", nameof(ID));
        }
        if (stockItems.Count == 0)
        {
            Console.WriteLine("No stock items available.");
            return [];
        }
        return stockItems.Where(item => item.Product.ID == ID).ToList();
    }

    /// <summary>
    /// Returns all stock items.
    /// </summary>
    /// <returns></returns>
    public List<StockItem> GetAllStockItems()
    {
        if (stockItems.Count == 0)
        {
            Console.WriteLine("No stock items available.");
            return [];
        }
        return stockItems;
    }

    /// <summary>
    /// Displays a full warehouse report.
    /// </summary>
    public void GetAFullReport()
    {
        if (stockItems.Count == 0)
        {
            Console.WriteLine("No stock items available.");
            return;
        }
        stockItems.ForEach(item => Console.WriteLine(item));
        int totalValue = stockItems.Sum(item => item.Quantity * item.Product.Price);
        Console.WriteLine($"Total inventory value: {totalValue}");
        stockItems.Where(item => item.Quantity < 5).ToList().ForEach(lowStockItem => Console.WriteLine($"Low stock item: {lowStockItem}"));
    }
}
