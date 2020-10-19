namespace CoffeeShopManagement
{
    partial class fTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            this.mnsTableManager = new System.Windows.Forms.MenuStrip();
            this.tsmAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInFoAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chưcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SLuuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PHoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HDSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmMergeTable = new System.Windows.Forms.ComboBox();
            this.btnMergeTable = new System.Windows.Forms.Button();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwtchTable = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.printBill = new System.Drawing.Printing.PrintDocument();
            this.mnsTableManager.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsTableManager
            // 
            this.mnsTableManager.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.mnsTableManager.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsTableManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdmin,
            this.tsmInFoAccount,
            this.chưcNăngToolStripMenuItem,
            this.hệThốngToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnsTableManager.Location = new System.Drawing.Point(0, 0);
            this.mnsTableManager.Name = "mnsTableManager";
            this.mnsTableManager.Size = new System.Drawing.Size(1414, 27);
            this.mnsTableManager.TabIndex = 0;
            this.mnsTableManager.Text = "mnsTableManager";
            // 
            // tsmAdmin
            // 
            this.tsmAdmin.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAdmin.ForeColor = System.Drawing.Color.White;
            this.tsmAdmin.Name = "tsmAdmin";
            this.tsmAdmin.Size = new System.Drawing.Size(70, 23);
            this.tsmAdmin.Text = "Admin";
            this.tsmAdmin.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // tsmInFoAccount
            // 
            this.tsmInFoAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tsmInFoAccount.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmInFoAccount.ForeColor = System.Drawing.Color.White;
            this.tsmInFoAccount.Name = "tsmInFoAccount";
            this.tsmInFoAccount.Size = new System.Drawing.Size(173, 23);
            this.tsmInFoAccount.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.thôngTinCáNhânToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // chưcNăngToolStripMenuItem
            // 
            this.chưcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhToanToolStripMenuItem,
            this.thêmMonToolStripMenuItem});
            this.chưcNăngToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chưcNăngToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.chưcNăngToolStripMenuItem.Name = "chưcNăngToolStripMenuItem";
            this.chưcNăngToolStripMenuItem.Size = new System.Drawing.Size(108, 23);
            this.chưcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // thanhToanToolStripMenuItem
            // 
            this.thanhToanToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.thanhToanToolStripMenuItem.Name = "thanhToanToolStripMenuItem";
            this.thanhToanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.thanhToanToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.thanhToanToolStripMenuItem.Text = "Thanh toán";
            this.thanhToanToolStripMenuItem.Click += new System.EventHandler(this.thanhToanToolStripMenuItem_Click);
            // 
            // thêmMonToolStripMenuItem
            // 
            this.thêmMonToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.thêmMonToolStripMenuItem.Name = "thêmMonToolStripMenuItem";
            this.thêmMonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.thêmMonToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.thêmMonToolStripMenuItem.Text = "Thêm món";
            this.thêmMonToolStripMenuItem.Click += new System.EventHandler(this.thêmMonToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SLuuToolStripMenuItem,
            this.PHoiToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(97, 23);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // SLuuToolStripMenuItem
            // 
            this.SLuuToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.SLuuToolStripMenuItem.Name = "SLuuToolStripMenuItem";
            this.SLuuToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.SLuuToolStripMenuItem.Text = "Sao Lưu";
            this.SLuuToolStripMenuItem.Click += new System.EventHandler(this.SLuuToolStripMenuItem_Click);
            // 
            // PHoiToolStripMenuItem
            // 
            this.PHoiToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.PHoiToolStripMenuItem.Name = "PHoiToolStripMenuItem";
            this.PHoiToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.PHoiToolStripMenuItem.Text = "Phục Hồi";
            this.PHoiToolStripMenuItem.Click += new System.EventHandler(this.PHoiToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HDSDToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // HDSDToolStripMenuItem
            // 
            this.HDSDToolStripMenuItem.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.HDSDToolStripMenuItem.Name = "HDSDToolStripMenuItem";
            this.HDSDToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.HDSDToolStripMenuItem.Text = "Hướng dẫn sử dụng";
            this.HDSDToolStripMenuItem.Click += new System.EventHandler(this.HDSDToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tomato;
            this.panel2.Controls.Add(this.nmFoodCount);
            this.panel2.Controls.Add(this.btnAddFood);
            this.panel2.Controls.Add(this.cbFood);
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Location = new System.Drawing.Point(791, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 82);
            this.panel2.TabIndex = 2;
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmFoodCount.ForeColor = System.Drawing.Color.Black;
            this.nmFoodCount.Location = new System.Drawing.Point(490, 46);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(98, 28);
            this.nmFoodCount.TabIndex = 2;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddFood.FlatAppearance.BorderSize = 0;
            this.btnAddFood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnAddFood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFood.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.Color.Tomato;
            this.btnAddFood.Location = new System.Drawing.Point(253, 31);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(208, 44);
            this.btnAddFood.TabIndex = 0;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFood.ForeColor = System.Drawing.Color.Black;
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(17, 46);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(214, 27);
            this.cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.ForeColor = System.Drawing.Color.Black;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(17, 10);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(214, 27);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lsvBill);
            this.panel3.Location = new System.Drawing.Point(791, 134);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(611, 451);
            this.panel3.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBill.ForeColor = System.Drawing.Color.Black;
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(605, 451);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 140;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumPurple;
            this.panel4.Controls.Add(this.cmMergeTable);
            this.panel4.Controls.Add(this.btnMergeTable);
            this.panel4.Controls.Add(this.txbTotalPrice);
            this.panel4.Controls.Add(this.cbSwitchTable);
            this.panel4.Controls.Add(this.btnSwtchTable);
            this.panel4.Controls.Add(this.nmDisCount);
            this.panel4.Controls.Add(this.btnCheckOut);
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Location = new System.Drawing.Point(791, 591);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(611, 94);
            this.panel4.TabIndex = 3;
            // 
            // cmMergeTable
            // 
            this.cmMergeTable.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmMergeTable.FormattingEnabled = true;
            this.cmMergeTable.Location = new System.Drawing.Point(151, 53);
            this.cmMergeTable.Name = "cmMergeTable";
            this.cmMergeTable.Size = new System.Drawing.Size(106, 27);
            this.cmMergeTable.TabIndex = 8;
            // 
            // btnMergeTable
            // 
            this.btnMergeTable.BackColor = System.Drawing.Color.White;
            this.btnMergeTable.FlatAppearance.BorderSize = 0;
            this.btnMergeTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnMergeTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnMergeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMergeTable.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnMergeTable.Location = new System.Drawing.Point(151, 9);
            this.btnMergeTable.Name = "btnMergeTable";
            this.btnMergeTable.Size = new System.Drawing.Size(106, 36);
            this.btnMergeTable.TabIndex = 7;
            this.btnMergeTable.Text = "Gộp bàn";
            this.btnMergeTable.UseVisualStyleBackColor = false;
            this.btnMergeTable.Click += new System.EventHandler(this.btnMergeTable_Click);
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.txbTotalPrice.Location = new System.Drawing.Point(280, 14);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(181, 30);
            this.txbTotalPrice.TabIndex = 6;
            this.txbTotalPrice.Text = "0";
            this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(17, 53);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(116, 27);
            this.cbSwitchTable.TabIndex = 3;
            // 
            // btnSwtchTable
            // 
            this.btnSwtchTable.BackColor = System.Drawing.Color.White;
            this.btnSwtchTable.FlatAppearance.BorderSize = 0;
            this.btnSwtchTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSwtchTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSwtchTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwtchTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwtchTable.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnSwtchTable.Location = new System.Drawing.Point(17, 10);
            this.btnSwtchTable.Name = "btnSwtchTable";
            this.btnSwtchTable.Size = new System.Drawing.Size(116, 34);
            this.btnSwtchTable.TabIndex = 5;
            this.btnSwtchTable.Text = "Chuyển bàn";
            this.btnSwtchTable.UseVisualStyleBackColor = false;
            this.btnSwtchTable.Click += new System.EventHandler(this.btnSwtchTable_Click);
            // 
            // nmDisCount
            // 
            this.nmDisCount.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDisCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmDisCount.Location = new System.Drawing.Point(280, 52);
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.Size = new System.Drawing.Size(181, 28);
            this.nmDisCount.TabIndex = 3;
            this.nmDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.White;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnCheckOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnCheckOut.Location = new System.Drawing.Point(481, 10);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(117, 72);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Thanh Toán";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(12, 46);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(773, 639);
            this.flpTable.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(515, 692);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "© by CoffeeShop QuiHandsome";
            // 
            // fTableManager
            // 
            this.AcceptButton = this.btnCheckOut;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 725);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.mnsTableManager);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsTableManager;
            this.MaximizeBox = false;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán cà phê";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.mnsTableManager.ResumeLayout(false);
            this.mnsTableManager.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsTableManager;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmInFoAccount;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btnSwtchTable;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmMergeTable;
        private System.Windows.Forms.Button btnMergeTable;
        private System.Windows.Forms.ToolStripMenuItem chưcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMonToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printBill;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HDSDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SLuuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PHoiToolStripMenuItem;
    }
}