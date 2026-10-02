using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace TechMartProductManager;

/// <summary>Kết quả kiểm tra dữ liệu nhập. Chuỗi lỗi rỗng nghĩa là hợp lệ.</summary>
public class ValidationResult
{
    public string NameError { get; set; } = "";
    public string PriceError { get; set; } = "";
    public string QuantityError { get; set; } = "";

    public bool IsValid =>
        NameError == "" && PriceError == "" && QuantityError == "";
}

/// <summary>Lớp xử lý toàn bộ nghiệp vụ và dữ liệu, không phụ thuộc giao diện.</summary>
public class ProductService
{
    private int _autoId = 1;
    private readonly string _dataFile = Path.Combine(AppContext.BaseDirectory, "products.json");

    /// <summary>Danh sách gốc chứa toàn bộ sản phẩm.</summary>
    public BindingList<Product> AllProducts { get; } = new BindingList<Product>();

    public List<Category> Categories { get; } = new List<Category>
    {
        new Category { Id = 1, Name = "Điện thoại" },
        new Category { Id = 2, Name = "Laptop" },
        new Category { Id = 3, Name = "Phụ kiện" }
    };

    public int Count => AllProducts.Count;

    // ---------- Lưu / nạp dữ liệu (products.json cạnh file .exe) ----------
    public void Load()
    {
        try
        {
            if (File.Exists(_dataFile))
            {
                var list = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(_dataFile, Encoding.UTF8));
                if (list != null)
                {
                    foreach (var p in list) AllProducts.Add(p);
                    int max = 0;
                    foreach (var p in list)
                        if (p.ProductId != null && p.ProductId.Length > 2 &&
                            int.TryParse(p.ProductId.Substring(2), out int n) && n > max)
                            max = n;
                    _autoId = max + 1;
                    return;
                }
            }
        }
        catch
        {
            // File hỏng thì bỏ qua và dùng dữ liệu mẫu
            AllProducts.Clear();
        }

        SeedData();
    }

    public void Save()
    {
        try
        {
            var json = JsonSerializer.Serialize(AllProducts.ToList(),
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataFile, json, Encoding.UTF8);
        }
        catch
        {
            // Không để lỗi ghi file làm sập ứng dụng
        }
    }

    // ---------- Dữ liệu mẫu ----------
    public void SeedData()
    {
        Add("iPhone 15 Pro", Categories[0], 28990000, 10, null);
        Add("Laptop Dell XPS 13", Categories[1], 32500000, 5, null);
        Add("Chuột Logitech MX Master 3", Categories[2], 2190000, 25, null);
    }

    private string NextId() => "SP" + (_autoId++).ToString("D3");

    // ---------- CRUD ----------
    public Product Add(string name, Category cat, decimal price, int qty, string imagePath)
    {
        var p = new Product
        {
            ProductId = NextId(),
            ProductName = name.Trim(),
            CategoryId = cat.Id,
            CategoryName = cat.Name,
            UnitPrice = price,
            Quantity = qty,
            ImagePath = imagePath
        };
        AllProducts.Add(p);
        Save();
        return p;
    }

    public void Update(Product p, string name, Category cat, decimal price, int qty, string imagePath)
    {
        p.ProductName = name.Trim();
        p.CategoryId = cat.Id;
        p.CategoryName = cat.Name;
        p.UnitPrice = price;
        p.Quantity = qty;
        p.ImagePath = imagePath;
        Save();
    }

    public void Delete(Product p)
    {
        AllProducts.Remove(p);
        Save();
    }

    // ---------- Tìm kiếm ----------
    public List<Product> Search(string keyword)
    {
        string kw = (keyword ?? "").Trim().ToLower();
        return string.IsNullOrEmpty(kw)
            ? AllProducts.ToList()
            : AllProducts.Where(p => p.ProductName.ToLower().Contains(kw)).ToList();
    }

    // ---------- Validation ----------
    public ValidationResult Validate(string name, string priceText, string qtyText)
    {
        var r = new ValidationResult();

        if (string.IsNullOrWhiteSpace(name))
            r.NameError = "Tên sản phẩm không được để trống!";

        if (!TryParsePrice(priceText, out decimal price) || price <= 0)
            r.PriceError = "Đơn giá phải là số lớn hơn 0!";

        if (!int.TryParse((qtyText ?? "").Trim(), out int qty) || qty < 0)
            r.QuantityError = "Số lượng phải là số nguyên >= 0!";

        return r;
    }

    public static bool TryParsePrice(string text, out decimal value)
    {
        string s = (text ?? "").Trim().Replace(",", "").Replace(".", "").Replace(" ", "");
        return decimal.TryParse(s, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value);
    }

    public static decimal ParsePrice(string text)
    {
        TryParsePrice(text, out decimal v);
        return v;
    }

    // ---------- Xuất CSV ----------
    public void ExportCsv(string filePath)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng");
        foreach (var p in AllProducts)
            sb.AppendLine($"{Csv(p.ProductId)},{Csv(p.ProductName)},{Csv(p.CategoryName)},{p.UnitPrice:0},{p.Quantity}");

        // UTF-8 có BOM để Excel đọc đúng tiếng Việt
        File.WriteAllText(filePath, sb.ToString(), new UTF8Encoding(true));
    }

    private static string Csv(string s)
    {
        s ??= "";
        return s.Contains(',') || s.Contains('"') || s.Contains('\n')
            ? "\"" + s.Replace("\"", "\"\"") + "\""
            : s;
    }
}
