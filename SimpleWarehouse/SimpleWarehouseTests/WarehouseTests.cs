using SimpleWarehouse;

namespace SimpleWarehouseTests;

public class WarehouseTests
{
    [Fact]
    public void ProductInitTest()
    {
        Product product = new(1, "Test Product", ProductWeight.Medium, 100);
        Assert.Equal(1, product.ID);
        Assert.Equal("Test Product", product.Name);
        Assert.Equal(ProductWeight.Medium, product.Weight);
        Assert.Equal(100, product.Price);
    }

    [Fact]
    public void StockItemInitTest()
    {
        Product product = new(1, "Test Product", ProductWeight.Medium, 100);
        StockItem stockItem = new(product, 50);
        Assert.Equal(product, stockItem.Product);
        Assert.Equal(50, stockItem.Quantity);
    }

    [Fact]
    public void WarehouseInitTest()
    {
        Warehouse warehouse = new Warehouse();
        Assert.NotNull(warehouse);
        Assert.Empty(warehouse.GetAllStockItems());
    }

    [Fact]
    public void WarehouseInitWithListTest1()
    {
        List<StockItem> initList = [];
        Product product = new(1, "Test Product", ProductWeight.Medium, 100);
        StockItem stockItem = new(product, 50);
        initList.Add(stockItem);
        Warehouse warehouse = new(initList);
        Assert.Single(warehouse.GetAllStockItems());
    }

    [Fact]
    public void WarehouseInitWithListTest2()
    {
        List<StockItem> initList = [];
        Product product1 = new(1, "Test Product 1", ProductWeight.Medium, 100);
        StockItem stockItem1 = new(product1, 50);
        Product product2 = new(2, "Test Product 2", ProductWeight.Medium, 100);
        StockItem stockItem2 = new(product2, 50);
        initList.Add(stockItem1);
        initList.Add(stockItem2);
        Warehouse warehouse = new(initList);
        Assert.Equal(2, warehouse.GetAllStockItems().Count);
    }

    [Fact]
    public void WarehouseAddStockItemTest()
    {
        Warehouse warehouse = new();
        Product product = new(1, "Test Product", ProductWeight.Medium, 100);
        StockItem stockItem = new(product, 50);
        warehouse.AddStockItem(stockItem);
        Assert.Single(warehouse.GetAllStockItems());
    }

    [Fact]
    public void WarehouseRemoveStockItemTest1()
    {
        Warehouse warehouse = new();
        Product product = new(1, "Test Product", ProductWeight.Medium, 100);
        StockItem stockItem = new(product, 50);
        warehouse.AddStockItem(stockItem);
        warehouse.RemoveStockItem(1);
        Assert.Empty(warehouse.GetAllStockItems());
    }

    [Fact]
    public void WarehouseRemoveStockItemTest2()
    {
        List<StockItem> initList = [];
        Product product1 = new(1, "Test Product 1", ProductWeight.Medium, 100);
        StockItem stockItem1 = new(product1, 50);
        Product product2 = new(1, "Test Product 2", ProductWeight.Medium, 100);
        StockItem stockItem2 = new(product2, 50);
        initList.Add(stockItem1);
        initList.Add(stockItem2);
        Warehouse warehouse = new(initList);
        warehouse.RemoveStockItem(1);
        Assert.Empty(warehouse.GetAllStockItems());
    }

    [Fact]
    public void WarehouseRemoveStockItemTest3()
    {
        List<StockItem> initList = [];
        Product product1 = new(1, "Test Product 1", ProductWeight.Medium, 100);
        StockItem stockItem1 = new(product1, 50);
        Product product2 = new(2, "Test Product 2", ProductWeight.Medium, 100);
        StockItem stockItem2 = new(product2, 50);
        initList.Add(stockItem1);
        initList.Add(stockItem2);
        Warehouse warehouse = new(initList);
        warehouse.RemoveStockItem(2);
        Assert.Single(warehouse.GetAllStockItems());
    }

    [Fact]
    public void ReportTest()
    {
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
        warehouse.GetAFullReport();
    }

    [Fact]
    public void ProductNotFoundException()
    {
        List<StockItem> initList = [];
        Product product1 = new(1, "Test Product 1", ProductWeight.Medium, 100);
        StockItem stockItem1 = new(product1, 50);
        Product product2 = new(2, "Test Product 2", ProductWeight.Medium, 100);
        StockItem stockItem2 = new(product2, 50);
        initList.Add(stockItem1);
        initList.Add(stockItem2);
        Warehouse warehouse = new(initList);
        Assert.Throws<ProductNotFoundException>(() => warehouse.RemoveStockItem(3));
    }

    [Fact]
    public void GetItemTest1()
    {
        List<StockItem> initList = [];
        Product product1 = new(1, "Test Product 1", ProductWeight.Medium, 100);
        StockItem stockItem1 = new(product1, 50);
        Product product2 = new(2, "Test Product 2", ProductWeight.Medium, 100);
        StockItem stockItem2 = new(product2, 50);
        initList.Add(stockItem1);
        initList.Add(stockItem2);
        Warehouse warehouse = new(initList);
        List<StockItem> items = warehouse.GetStockItem(1);
        Assert.Single(items);
        Assert.Equal(product1, items[0].Product);
    }

    [Fact]
    public void GetItemTest2()
    {
        List<StockItem> initList = [];
        Product product1 = new(1, "Test Product 1", ProductWeight.Medium, 100);
        StockItem stockItem1 = new(product1, 50);
        Product product2 = new(1, "Test Product 2", ProductWeight.Medium, 100);
        StockItem stockItem2 = new(product2, 50);
        initList.Add(stockItem1);
        initList.Add(stockItem2);
        Warehouse warehouse = new(initList);
        List<StockItem> items = warehouse.GetStockItem(1);
        Assert.Equal(2, items.Count);
    }
}
