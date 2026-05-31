[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("SimpleWarehouseTests")]

namespace SimpleWarehouse;

internal class Program
{
    static void Main()
    {
        #region Setup
        Warehouse warehouse = new();
        Product product1 = new(1, "Light Widget", ProductWeight.Light, 10);
        Product product2 = new(2, "Medium Widget", ProductWeight.Medium, 20);
        Product product3 = new(3, "Heavy Widget", ProductWeight.Heavy, 30);
        Product product4 = new(4, "Light Widget", ProductWeight.Light, 10);
        Product product5 = new(5, "Medium Widget", ProductWeight.Medium, 20);
        Product product6 = new(6, "Heavy Widget", ProductWeight.Heavy, 30);
        warehouse.AddStockItem(new StockItem(product1, 100));
        warehouse.AddStockItem(new StockItem(product2, 200));
        warehouse.AddStockItem(new StockItem(product3, 300));
        warehouse.AddStockItem(new StockItem(product4, 400));
        warehouse.AddStockItem(new StockItem(product5, 500));
        warehouse.AddStockItem(new StockItem(product6, 1));
        #endregion
        warehouse.GetAFullReport();
    }
}
