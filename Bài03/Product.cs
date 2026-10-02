namespace TechMartProductManager;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string ImagePath { get; set; }
}
