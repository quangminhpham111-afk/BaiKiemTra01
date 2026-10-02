namespace TechMartProductManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle styleId = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stylePrice = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleQty = new System.Windows.Forms.DataGridViewCellStyle();

            this.errorProvider = new System.Windows.Forms.ErrorProvider(components);
            this.bindingSource = new System.Windows.Forms.BindingSource(components);

            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();

            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();

            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();

            this.panelPic = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new System.Windows.Forms.Button();

            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.panelPic.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();

            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            //
            // menuStrip
            //
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuFile });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1100, 27);
            this.menuStrip.TabIndex = 2;
            //
            // mnuFile
            //
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuExport, this.toolStripSeparator1, this.mnuExit });
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Text = "File";
            //
            // mnuExport
            //
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuExport.Text = "Export CSV";
            this.mnuExport.Click += new System.EventHandler(this.MnuExport_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            //
            // mnuExit
            //
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.TabIndex = 1;
            //
            // lblStatus
            //
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Tổng số sản phẩm: 0";
            //
            // tlpMain  (35% - 65%)
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.TabIndex = 0;
            //
            // tlpLeft
            //
            this.tlpLeft.ColumnCount = 2;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tlpLeft.Controls.Add(this.lblId, 0, 0);
            this.tlpLeft.Controls.Add(this.txtProductId, 1, 0);
            this.tlpLeft.Controls.Add(this.lblName, 0, 1);
            this.tlpLeft.Controls.Add(this.txtProductName, 1, 1);
            this.tlpLeft.Controls.Add(this.lblPrice, 0, 2);
            this.tlpLeft.Controls.Add(this.txtUnitPrice, 1, 2);
            this.tlpLeft.Controls.Add(this.lblQty, 0, 3);
            this.tlpLeft.Controls.Add(this.txtQuantity, 1, 3);
            this.tlpLeft.Controls.Add(this.lblCategory, 0, 4);
            this.tlpLeft.Controls.Add(this.cboCategory, 1, 4);
            this.tlpLeft.Controls.Add(this.lblImage, 0, 5);
            this.tlpLeft.Controls.Add(this.panelPic, 1, 5);
            this.tlpLeft.Controls.Add(this.flowButtons, 0, 6);
            this.tlpLeft.SetColumnSpan(this.flowButtons, 2);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.Padding = new System.Windows.Forms.Padding(4);
            this.tlpLeft.RowCount = 7;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlpLeft.TabIndex = 0;
            //
            // labels
            //
            this.lblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblId.Name = "lblId";
            this.lblId.Text = "Mã SP:";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Name = "lblName";
            this.lblName.Text = "Tên SP:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Đơn giá:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQty.Name = "lblQty";
            this.lblQty.Text = "Số lượng:";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImage.Name = "lblImage";
            this.lblImage.Text = "Ảnh:";
            this.lblImage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblImage.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            //
            // textboxes + combobox
            //
            this.txtProductId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductId.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.TabIndex = 0;

            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.TabIndex = 1;

            this.txtUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.TabIndex = 2;

            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.TabIndex = 3;

            this.cboCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.TabIndex = 4;
            //
            // panelPic
            //
            this.panelPic.Controls.Add(this.picAvatar);
            this.panelPic.Controls.Add(this.btnChooseImage);
            this.panelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPic.Name = "panelPic";
            this.panelPic.TabIndex = 5;
            //
            // picAvatar
            //
            this.picAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabStop = false;
            //
            // btnChooseImage
            //
            this.btnChooseImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(95, 100);
            this.btnChooseImage.TabIndex = 0;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.BtnChooseImage_Click);
            //
            // flowButtons
            //
            this.flowButtons.Controls.Add(this.btnAdd);
            this.flowButtons.Controls.Add(this.btnUpdate);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnClear);
            this.flowButtons.Controls.Add(this.btnExport);
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.TabIndex = 6;
            //
            // buttons
            //
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 34);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 34);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 34);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 34);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Xuất CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            //
            // tlpRight
            //
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.txtSearch, 0, 0);
            this.tlpRight.Controls.Add(this.dgvProducts, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.Padding = new System.Windows.Forms.Padding(4);
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.TabIndex = 1;
            //
            // txtSearch
            //
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm theo tên sản phẩm...";
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colName, this.colCategory, this.colPrice, this.colQty });
            this.dgvProducts.DataSource = this.bindingSource;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvProducts_CellFormatting);
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.DgvProducts_SelectionChanged);
            //
            // columns
            //
            this.colId.DataPropertyName = "ProductId";
            this.colId.FillWeight = 12F;
            this.colId.HeaderText = "Mã SP";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;

            this.colName.DataPropertyName = "ProductName";
            this.colName.FillWeight = 34F;
            this.colName.HeaderText = "Tên SP";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;

            this.colCategory.DataPropertyName = "CategoryName";
            this.colCategory.FillWeight = 17F;
            this.colCategory.HeaderText = "Danh Mục";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;

            stylePrice.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            stylePrice.Format = "N0";
            this.colPrice.DataPropertyName = "UnitPrice";
            this.colPrice.DefaultCellStyle = stylePrice;
            this.colPrice.FillWeight = 24F;
            this.colPrice.HeaderText = "Đơn Giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;

            styleQty.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DataPropertyName = "Quantity";
            this.colQty.DefaultCellStyle = styleQty;
            this.colQty.FillWeight = 13F;
            this.colQty.HeaderText = "Số Lượng";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TechMart Product Manager";

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpRight.PerformLayout();
            this.panelPic.ResumeLayout(false);
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Panel panelPic;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
