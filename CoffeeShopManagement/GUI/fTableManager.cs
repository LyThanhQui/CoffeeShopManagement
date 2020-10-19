using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoffeeShopManagement.fAccountProfile;

namespace CoffeeShopManagement
{
    public partial class fTableManager : Form
    {
        public fTableManager() { }

        #region field and properties
        private System.Drawing.Printing.PrintDocument printDoc;

        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount.Type); }
        }
        #endregion

        #region contructors
        public fTableManager(AccountDTO acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }
        #endregion

        #region Method
        void ChangeAccount(int type)
        {
            tsmAdmin.Enabled = type == 1;
            tsmInFoAccount.Text += " (" + LoginAccount.DisplayName + ")";
        }
        void LoadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<FoodDTO> listfood = FoodDAO.Instance.GetListFood(id);
            cbFood.DataSource = listfood;
            cbFood.DisplayMember = "name";
        }

        public void LoadTable()
        {

            flpTable.Controls.Clear();
            List<TableDTO> tableList = TableDAO.Instance.LoadTableList();
            foreach (TableDTO item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.BtnWidth, Height = TableDAO.BtnHeight };

                btn.Click += btn_Click;
                btn.Tag = item;
                btn.Text = item.Name + Environment.NewLine + item.Status;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.DodgerBlue;
                        btn.ForeColor = Color.White;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }


        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            CultureInfo culture = new CultureInfo("vi-VN");
            List<MenuDTO> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;

            foreach (MenuDTO item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());

                string priceCur = item.Price.ToString("c", culture);
                lsvItem.SubItems.Add(priceCur);

                string TotalPriceCur = item.TotalPrice.ToString("c", culture);
                lsvItem.SubItems.Add(TotalPriceCur);

                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }


        //end document print
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "name";
        }
        #endregion

        #region Event
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }
        void f_UpdateAccount(object sender, AccountEvent e)
        {
            tsmInFoAccount.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.InsertFood += F_InsertFood;
            f.DeleteFood += F_DeleteFood;
            f.UpdateFood += F_UpdateFood;
            f.ShowDialog();
        }

        private void F_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as CategoryDTO).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableDTO).ID);
        }

        private void F_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as CategoryDTO).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as TableDTO).ID);
                LoadTable();
            }
        }

        private void F_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as CategoryDTO).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableDTO).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lsvBill.Tag as TableDTO;
                if (table == null)
                {
                    MessageBox.Show("Hãy chọn bàn!");
                    return;

                }
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                try
                {
                    int foodID = (cbFood.SelectedItem as FoodDTO).ID;
                    int count = (int)nmFoodCount.Value;
                    if (idBill == -1)
                    {
                        BillDAO.Instance.InsertBill(table.ID);
                        BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                    }
                    else
                    {
                        BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn chưa nhập món ăn cho danh mục này!");
                }
                ShowBill(table.ID);
                LoadTable();
            }
            catch { }
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lsvBill.Tag as TableDTO;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                int discount = (int)nmDisCount.Value;
                float totalPrice = float.Parse(txbTotalPrice.Text.Split(',')[0]);
                float finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

                if (idBill != -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho {0} \nGiảm giá = {1}% ", table.Name, discount), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {

                        BillDAO.Instance.CheckOut(idBill, discount, finalTotalPrice * 1000);
                        //print here
                        PrintDialog printDialog = new PrintDialog();
                        if (printDialog.ShowDialog() == DialogResult.OK)
                            printDoc.Print();
                        //end print
                        ShowBill(table.ID);
                        LoadTable();
                    }
                }
            }
            catch { }
        }

        //print here
        private void Print_Load()
        {
            printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 140;
            int x = 200;
            Font font = new Font("Times New Roman", 13, FontStyle.Regular, GraphicsUnit.Point);
            Font fontTitle = new Font("Kristen ITC", 16, FontStyle.Regular, GraphicsUnit.Point);
            string bill = "";
            e.Graphics.DrawString("QCoffeeShop", fontTitle, Brushes.Black, 250, 40);
            e.Graphics.DrawString("----------------------------------------------", font, Brushes.Black, 200, 100);
            int length = lsvBill.Items.Count;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    bill += lsvBill.Items[i].SubItems[j].Text;
                    if (j == 0)
                        bill += ".....................";//21
                    if (j == 1)
                        bill += ".......";//7
                    // 7 + 21 + 12 + 6 = 46 

                }
                bill += "\n";
                e.Graphics.DrawString(bill, font, Brushes.Black, x, y);
                y += 50;
                bill = "";

            }
            e.Graphics.DrawString("----------------------------------------------", font, Brushes.Black, 200, y);
            string finalTotalPrice = "Tổng cộng:....................." + txbTotalPrice.Text;
            e.Graphics.DrawString(finalTotalPrice, font, Brushes.Black, 200, y + 50);
        }


        //end print

        private void btnSwtchTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id1 = (lsvBill.Tag as TableDTO).ID;
                string name1 = (lsvBill.Tag as TableDTO).Name;
                int id2 = (cbSwitchTable.SelectedItem as TableDTO).ID;
                string name2 = (cbSwitchTable.SelectedItem as TableDTO).Name;
                if (id1 == id2)
                    MessageBox.Show("Trùng bàn, hãy chọn bàn khác!");
                else
                {
                    if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển {0} qua  {1}", name1, name2), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        TableDAO.Instance.SwitchTable(id1, id2);
                        LoadTable();
                    }
                }
            }
            catch { }

        }

        private void thanhToanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            btnCheckOut_Click(this, new EventArgs());
        }

        private void thêmMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        #endregion

        private void btnMergeTable_Click(object sender, EventArgs e)
        {

        }


        private void fTableManager_Load(object sender, EventArgs e)
        {
            Print_Load();
          //  this.reportViewer1.RefreshReport();
        }

        private void HDSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Help.ShowHelp(this,"file://E:\\help.chm");
            //Help.ShowHelp(this,"file://‪C:\\Users\\QUI\\Desktop\\help\\help.chm");

        }

        private void SLuuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "Chọn thư mục lưu trữ";
            if(saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;
                if(SaoLuu(sDuongDan) == true)
                {
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                }
                else
                {
                    MessageBox.Show("Thao tác không thành công!");
                }
            }
        }

        public static bool SaoLuu(string sDuongDan)
        {
            return CSDLDAO.Instance.SaoLuuDuLieu(sDuongDan);
        }

        public static bool PhucHoi(string sDuongDan) { return true; }
        private void PHoiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
