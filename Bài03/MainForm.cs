using System.ComponentModel;
using System.Globalization;

namespace TechMartProductManager;

public partial class MainForm : Form
{
    private readonly ProductService _service = new ProductService();
    private string _currentImagePath = null;
    private bool _loading = false;

    public MainForm()
    {
        InitializeComponent();

        // ComboBox danh mục: DisplayMember / ValueMember
        cboCategory.DisplayMember = "Name";
        cboCategory.ValueMember = "Id";
        cboCategory.DataSource = _service.Categories;

        _service.Load();
        ApplyFilter();

        // Khi form hiện ra: bỏ chọn dòng đầu để ô nhập trống, sẵn sàng thêm mới
        Shown += (s, e) =>
        {
            _loading = true;
            dgvProducts.ClearSelection();
            dgvProducts.CurrentCell = null;
            _loading = false;
            ClearInputs();
        };
    }

    /// <summary>Sản phẩm đang được người dùng chọn trên lưới (null nếu chưa chọn).</summary>
    private Product GetSelectedProduct()
    {
        if (dgvProducts.SelectedRows.Count == 0) return null;
        return dgvProducts.SelectedRows[0].DataBoundItem as Product;
    }

    // ============================================================
    //  HIỂN THỊ DỮ LIỆU
    // ============================================================
    private void ApplyFilter()
    {
        _loading = true;
        var filtered = _service.Search(txtSearch.Text);
        bindingSource.DataSource = new BindingList<Product>(filtered);
        bindingSource.ResetBindings(false);
        dgvProducts.ClearSelection();       // không tự chọn dòng đầu
        dgvProducts.CurrentCell = null;
        _loading = false;
        lblStatus.Text = $"Tổng số sản phẩm: {_service.Count}";
    }

    // ============================================================
    //  SỰ KIỆN
    // ============================================================
    private void TxtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter(); // Live search

    private void DgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Hiển thị "25,000,000 VNĐ"
        if (e.RowIndex >= 0 && dgvProducts.Columns[e.ColumnIndex].Name == "colPrice" && e.Value is decimal d)
        {
            e.Value = d.ToString("N0", CultureInfo.InvariantCulture) + " VNĐ";
            e.FormattingApplied = true;
        }
    }

    private void DgvProducts_SelectionChanged(object sender, EventArgs e)
    {
        if (_loading) return;
        var p = GetSelectedProduct();
        if (p == null) return;

        ClearErrors();
        txtProductId.Text = p.ProductId;
        txtProductName.Text = p.ProductName;
        txtUnitPrice.Text = p.UnitPrice.ToString("0");
        txtQuantity.Text = p.Quantity.ToString();
        cboCategory.SelectedValue = p.CategoryId;
        ShowImage(p.ImagePath);
    }

    private void BtnChooseImage_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Chọn ảnh sản phẩm",
            Filter = "Ảnh (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Tất cả file (*.*)|*.*"
        };
        if (ofd.ShowDialog() == DialogResult.OK)
            ShowImage(ofd.FileName);
    }

    private void ShowImage(string path)
    {
        picAvatar.Image?.Dispose();
        picAvatar.Image = null;
        _currentImagePath = null;
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

        try
        {
            using var img = Image.FromFile(path);
            picAvatar.Image = new Bitmap(img); // copy để không khóa file
            _currentImagePath = path;
        }
        catch
        {
            MessageBox.Show("Không thể đọc file ảnh này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        _service.Add(
            txtProductName.Text,
            (Category)cboCategory.SelectedItem,
            ProductService.ParsePrice(txtUnitPrice.Text),
            int.Parse(txtQuantity.Text.Trim()),
            _currentImagePath);

        ApplyFilter();
        ClearInputs();
    }

    private void BtnUpdate_Click(object sender, EventArgs e)
    {
        var p = GetSelectedProduct();
        if (p == null)
        {
            MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!ValidateInputs()) return;

        _service.Update(
            p,
            txtProductName.Text,
            (Category)cboCategory.SelectedItem,
            ProductService.ParsePrice(txtUnitPrice.Text),
            int.Parse(txtQuantity.Text.Trim()),
            _currentImagePath);

        ApplyFilter();
        ClearInputs();
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        var p = GetSelectedProduct();
        if (p == null)
        {
            MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm \"{p.ProductName}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            _service.Delete(p);
            ApplyFilter();
            ClearInputs();
        }
    }

    private void BtnClear_Click(object sender, EventArgs e) => ClearInputs();
    private void BtnExport_Click(object sender, EventArgs e) => ExportCsv();
    private void MnuExport_Click(object sender, EventArgs e) => ExportCsv();
    private void MnuExit_Click(object sender, EventArgs e) => Close();

    // ============================================================
    //  VALIDATION (hiển thị lỗi qua ErrorProvider)
    // ============================================================
    private bool ValidateInputs()
    {
        ClearErrors();
        var r = _service.Validate(txtProductName.Text, txtUnitPrice.Text, txtQuantity.Text);

        errorProvider.SetError(txtProductName, r.NameError);
        errorProvider.SetError(txtUnitPrice, r.PriceError);
        errorProvider.SetError(txtQuantity, r.QuantityError);

        return r.IsValid;
    }

    private void ClearErrors()
    {
        errorProvider.SetError(txtProductName, "");
        errorProvider.SetError(txtUnitPrice, "");
        errorProvider.SetError(txtQuantity, "");
    }

    private void ClearInputs()
    {
        ClearErrors();
        txtProductId.Clear();
        txtProductName.Clear();
        txtUnitPrice.Clear();
        txtQuantity.Clear();
        if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
        ShowImage(null);
    }

    // ============================================================
    //  XUẤT CSV (hộp thoại ở form, ghi file ở service)
    // ============================================================
    private void ExportCsv()
    {
        using var sfd = new SaveFileDialog
        {
            Title = "Xuất danh sách sản phẩm",
            Filter = "CSV file (*.csv)|*.csv",
            FileName = "DanhSachSanPham.csv"
        };
        if (sfd.ShowDialog() != DialogResult.OK) return;

        try
        {
            _service.ExportCsv(sfd.FileName);
            MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
