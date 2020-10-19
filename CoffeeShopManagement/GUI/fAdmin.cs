using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class fAdmin : Form
    {

        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        public AccountDTO loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            LoadAll();
        }
        #region Methods
        void LoadAll()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvTable.DataSource = tableList;
            dtgvCategory.DataSource = categoryList;

            LoadDateTimePickerBill();
            LoadListBillByDate();
            LoadListFood();
            LoadAccount();
            LoadCategoryIntoCombobox(cbFoodCategory);
            LoadCategory();
            ShowTableFood();
            //LoadTypeIntoCobobox(cbTableStatus);

            AddBindingCatergory();
            AddFoodBidding();
            AddTableBinding();
            // AddAccountBinding();

        }
        /*Start Table Category*/
        public void DeleleCategory(int id)
        {
            if (CategoryDAO.Instance.DeleteCategoryFood(id))
            {
                MessageBox.Show("Xóa danh mục thành công!");
                LoadCategory();
            }
            else
            {
                MessageBox.Show("Xóa danh mục khoản thất bại!");
            }
        }
        void EditCategory(int id, string name)
        {
            if (CategoryDAO.Instance.EditCategory(id, name))
            {
                MessageBox.Show("Sửa danh mục thành công!");
                LoadCategory();
            }
            else
            {
                MessageBox.Show("Sửa danh mục khoản thất bại!");
            }
        }

        void AddCategory(string name)
        {

            if (CategoryDAO.Instance.AddCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadCategory();
            }
            else
            {
                MessageBox.Show("Thêm danh mục khoản thất bại!");
            }
        }

        void AddBindingCatergory()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }
        void LoadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
            dtgvCategory.Columns[0].HeaderText = "STT";
            dtgvCategory.Columns[1].HeaderText = "Tên danh mục";
        }

        /*End Table Category*/


        /*Start Table Food*/
        void ShowTableFood()
        {
            tableList.DataSource = TableDAO.Instance.ShowTableFood();
            dtgvTable.Columns[0].HeaderText = "STT";
            dtgvTable.Columns[1].HeaderText = "Tên bàn";
            dtgvTable.Columns[2].HeaderText = "Trạng thái";

        }
        void InsertTableFood(string name, string status)
        {
            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công!");
            }
            else
            {
                MessageBox.Show("Thêm bàn khoản thất bại!");
            }
            ShowTableFood();

        }

        void UpdateTableFood(int id, string name, string status)
        {
            if (TableDAO.Instance.UpdateTableFood(id, name, status))
            {
                MessageBox.Show("Sửa bàn thành công!");
            }
            else
            {
                MessageBox.Show("Sửa bàn  thất bại!");

            }
            ShowTableFood();

            /*End Table Food*/
        }
        void AddAcount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
            LoadAccount();
        }
        void EditAcount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại!");
            }
            LoadAccount();
        }
        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng không xóa chính bạn!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại \nXóa tài khoản thất bại!");
            }
            LoadAccount();
        }

        void RessetPassWord(string userName)
        {
            if (AccountDAO.Instance.ResetPassWord(userName))
            {
                MessageBox.Show("Reset mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Reset mật khẩu thất bại!");
            }


        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate()
        {
            dtgBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpFromDate.Value, dtpToDate.Value, Convert.ToInt32(txbBillPage.Text));
            dtgBill.Columns["Tổng tiền"].DefaultCellStyle.Format = "#,#";
            dtgBill.Columns["Giảm giá"].DefaultCellStyle.Format = "0\\%";
        }

        void LoadListFood()
        {
            // dtgvFood.DataSource = FoodDAO.Instance.GetListFood();
            foodList.DataSource = FoodDAO.Instance.GetListFood();
            dtgvFood.Columns["price"].DefaultCellStyle.Format = "#,#";
            dtgvFood.Columns[0].HeaderText = "STT";
            dtgvFood.Columns[1].HeaderText = "Tên món";
            dtgvFood.Columns[2].HeaderText = "STT";
            dtgvFood.Columns[3].HeaderText = "Tên danh mục";

        }

        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));

        }
        void AddFoodBidding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "id", true, DataSourceUpdateMode.Never));
            // cbFoodCategory.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "idCategory"));
            nmFoodPrice.DataBindings.Add(new Binding("value", dtgvFood.DataSource, "price", true, DataSourceUpdateMode.Never));

        }
        /* void AddAccountBinding()
         {
             txbUserNameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
             txbDisplayNameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
             nmTypeAccount.DataBindings.Add(new Binding("value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));

         }*/

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        /* void LoadTypeIntoCobobox(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "status";
        }*/

        List<FoodDTO> SearchFoodByName(string name)
        {
            List<FoodDTO> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        #endregion

        #region events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            // LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
            dtgBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpFromDate.Value, dtpToDate.Value, Convert.ToInt32(txbBillPage.Text));
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }


        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                    CategoryDTO category = CategoryDAO.Instance.GetCategoryByID(id);


                    int index = -1;
                    int i = 0;
                    foreach (CategoryDTO item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbFoodCategory.SelectedIndex = index;

                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbFoodName.Text;
                int checkName = 1;
                if (name == "")
                    MessageBox.Show("Bạn chưa nhập tên món cần thêm!");
                else
                {
                    List<FoodDTO> foodList = FoodDAO.Instance.GetListFood();
                    foreach (FoodDTO item in foodList)
                    {
                        string nameFood = item.Name;
                        if (name == nameFood)
                        {
                            MessageBox.Show("Tên món này đã tồn tại, vui lòng nhập tên món khác!");
                            checkName = 0;
                            break;
                        }
                    }
                    if (checkName == 1)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm món không", "Thêm món?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int categoryID = (cbFoodCategory.SelectedItem as CategoryDTO).ID;
                            float price = (float)nmFoodPrice.Value;
                            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
                            {
                                MessageBox.Show("Thêm thành công!");
                                LoadListFood();
                                if (insertFood != null)
                                    insertFood(this, new EventArgs());
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi khi thêm món!");
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbFoodName.Text;
                int checkName = 1;
                if (name == "")
                    MessageBox.Show("Bạn chưa nhập tên món cần sửa!");
                else
                {
                    List<FoodDTO> foodList = FoodDAO.Instance.GetListFood();
                    foreach (FoodDTO item in foodList)
                    {
                        string nameFood = item.Name;
                        if (name == nameFood)
                        {
                            MessageBox.Show("Tên món này đã tồn tại, vui lòng nhập tên món khác!");
                            checkName = 0;
                            break;
                        }
                    }
                    if (checkName == 1)
                    {
                        if (MessageBox.Show("Bạn có muốn sửa món không", "Sửa món?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            int categoryID = (cbFoodCategory.SelectedItem as CategoryDTO).ID;
                            float price = (float)nmFoodPrice.Value;
                            int id = Convert.ToInt32(txbFoodID.Text);
                            if (FoodDAO.Instance.UpdateFood(name, categoryID, price, id))
                            {
                                MessageBox.Show("Sửa thành công!");
                                LoadListFood();
                                if (updateFood != null)
                                    updateFood(this, new EventArgs());
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi khi sửa!");
                            }
                        }
                    }
                }
            }
            catch { }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa món không", "Xóa món?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txbFoodID.Text);
                    if (FoodDAO.Instance.DeleleFood(id))
                    {
                        MessageBox.Show("Xóa món thành công!");
                        LoadListFood();
                        if (deleteFood != null)
                            deleteFood(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa món!");
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Create Event
        /// </summary>
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txbUserNameAccount.Text;
                if (userName == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản cần xóa!");
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa tài khoản này không", "Thêm tài khoản?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DeleteAccount(userName);
                    }
                }
            }
            catch { }
        }

        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txbUserNameAccount.Text;
                string displayName = txbDisplayNameAccount.Text;
                int type = (int)nmTypeAccount.Value;
                int checkName = 1;
                if (userName == "" || displayName == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản hoặc tên hiển thị!");
                }
                else
                {
                    List<AccountDTO> accountList = AccountDAO.Instance.GetListAccountByRows();
                    foreach (AccountDTO item in accountList)
                    {
                        string userNameAcc = item.UserName;
                        if (userName == userNameAcc)
                        {
                            MessageBox.Show("Tên tài khoản này đã tồn tại, vui lòng nhập tên tài khoản khác!");
                            checkName = 0;
                            break;
                        }
                    }
                    if (checkName == 1)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm tài khoản này không", "Thêm tài khoản?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            AddAcount(userName, displayName, type);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại, vui lòng nhập tên tài khoản khác!");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txbUserNameAccount.Text;
                string displayName = txbDisplayNameAccount.Text;
                int type = (int)nmTypeAccount.Value;
                if (userName == "" || displayName == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản hoặc tên hiển thị!");
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn sửa tài khoản này không", "Sửa tài khoản?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        EditAcount(userName, displayName, type);
                    }
                }
            }
            catch { }

        }
        private void btnRessetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txbUserNameAccount.Text;
                if (userName == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản!");
                }
                if (MessageBox.Show("Bạn có muốn đặt lại mật khẩu cho tài khoản này không?", "Đặt lại mật khẩu?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    RessetPassWord(userName);
                }
            }
            catch { }
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            ShowTableFood();
        }

        /*Start TableFood*/
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbTableName.Text;
                int checkName = 1;
                if (name == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên bàn!");
                }
                else
                {
                    List<TableDTO> tableList = TableDAO.Instance.LoadTableList();
                    foreach (TableDTO item in tableList)
                    {
                        string nameTable = item.Name;
                        if (name == nameTable)
                        {
                            MessageBox.Show("Tên bàn này đã tồn tại, vui lòng nhập tên bàn khác!");
                            checkName = 0;
                            break;
                        }
                    }
                    if (checkName == 1)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm bàn này không", "Thêm bàn?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string status = txbTableStatus.Text;
                            InsertTableFood(name, status);

                        }
                    }
                }
            }
            catch { }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbTableID.Text);
                string name = txbTableName.Text;
                int checkName = 1;
                if (name == "")
                    MessageBox.Show("Bạn chưa nhập tên bàn!");
                else
                {
                    List<TableDTO> tableList = TableDAO.Instance.LoadTableList();
                    foreach (TableDTO item in tableList)
                    {
                        string nameTable = item.Name;
                        if (name == nameTable)
                        {
                            MessageBox.Show("Tên bàn này đã tồn tại, vui lòng nhập tên bàn khác!");
                            checkName = 0;
                            break;
                        }
                    }
                    if (checkName == 1)
                    {
                        if (MessageBox.Show("Bạn có muốn sửa tên bàn này không", "Sửa tên bàn?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string status = txbTableStatus.Text;
                            UpdateTableFood(id, name, status);
                        }
                    }
                }
            }
            catch { }

        }


        private void btnDeledteTable_Click(object sender, EventArgs e)
        {
            try
            {
                int idTable = Convert.ToInt32(txbTableID.Text);
                string status = txbTableStatus.Text;
                if (MessageBox.Show("Bạn có muốn xóa bàn này không", "Xóa bàn?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    BillDAO.Instance.DeleteBillByTableID(idTable);

                    if (TableDAO.Instance.DeleteTableFood(idTable, status))
                    {
                        MessageBox.Show("Xóa bàn thành công!");
                        ShowTableFood();
                    }
                    else
                    {
                        MessageBox.Show("Xóa bàn thất bại!");
                    }
                }
            }
            catch { }
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbCategory.Text;
                int checkName = 1;
                if (name == "")
                    MessageBox.Show("Bạn chưa nhập tên danh mục!");
                else
                {
                    List<CategoryDTO> categoryList = CategoryDAO.Instance.GetListCategory();
                    foreach (CategoryDTO item in categoryList)
                    {
                        string nameCategory = item.Name;
                        if (name == nameCategory)
                        {
                            MessageBox.Show("Tên danh mục này đã tồn tại, vui lòng nhập tên danh mục khác!");
                            checkName = 0;
                            break;
                        }
                    }
                    if (checkName == 1)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm danh mục không", "Thêm danh mục?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            AddCategory(name);
                    }
                }
            }
            catch { }

        }


        private void btnEditCategory_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txbCategoryID.Text);
            string name = txbCategory.Text;
            int checkName = 1;
            if (name == "")
                MessageBox.Show("Bạn chưa nhập tên danh mục!");
            else
            {
                List<CategoryDTO> categoryList = CategoryDAO.Instance.GetListCategory();
                foreach (CategoryDTO item in categoryList)
                {
                    string nameCategory = item.Name;
                    if (name == nameCategory)
                    {
                        MessageBox.Show("Tên danh mục này đã tồn tại, vui lòng nhập tên danh mục khác!");
                        checkName = 0;
                        break;
                    }
                }
                if (checkName == 1)
                {
                    if (MessageBox.Show("Bạn có muốn sửa danh mục không", "Sửa danh mục?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        EditCategory(id, name);
                }
            }

        }

        private void btnDeletedCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa danh mục không", "Xóa danh mục?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txbCategoryID.Text);
                    DeleleCategory(id);
                }
            }
            catch { }
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txbBillPage.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpFromDate.Value, dtpToDate.Value);
            int lastPage = sumRecord / 20;
            if (sumRecord % 20 != 0)
                lastPage++;
            txbBillPage.Text = lastPage.ToString();
        }

        private void txbBillPage_TextChanged(object sender, EventArgs e)
        {
            dtgBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpFromDate.Value, dtpToDate.Value, Convert.ToInt32(txbBillPage.Text));
        }

        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbBillPage.Text);
            if (page > 1)
                page--;

            txbBillPage.Text = page.ToString();
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbBillPage.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpFromDate.Value, dtpToDate.Value);

            int lastPage = sumRecord / 20;
            if (page < lastPage)
                page++;
            if (sumRecord % 20 != 0)
            {
                if (page == lastPage)
                    page++;
            }
            txbBillPage.Text = page.ToString();
        }



        private void fAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CoffeeShopManagementDataSet.USP_GetListBillBylDateForReport' table. You can move, or remove it, as needed.
            //this.USP_GetListBillBylDateForReportTableAdapter.Fill(this.CoffeeShopManagementDataSet.USP_GetListBillBylDateForReport, dtpFromDate.Value, dtpToDate.Value);
            // TODO: This line of code loads data into the 'CoffeeShopManagementDataSet.USP_GetListBillBylDateForReport' table. You can move, or remove it, as needed.

           //  this.USP_GetListBillBylDateForReportTableAdapter.Fill(this.CoffeeShopManagementFinalDataSet.USP_GetListBillBylDateForReport, dtpFromDate.Value, dtpToDate.Value); 
            // this.rpViewAllBills.RefreshReport();
        }



        /*End TableFood*/

        /*  private void txbTableID_TextChanged(object sender, EventArgs e)
          {
              try
              {
                  if (dtgvTable.SelectedCells.Count > 0)
                  {
                      int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["id"].Value;
                      TableDTO table = TableDAO.Instance.GetTableByID(id);

                      int index = -1;
                      int i = 0;
                      foreach (TableDTO item in cbTableStatus.Items)
                      {
                          if (item.ID == table.ID)
                          {
                              index = i;
                              break;
                          }
                          i++;
                      }
                      cbTableStatus.SelectedIndex = index;


                  }
              }
              catch { }
          }
          */
        #endregion

        private void fAdmin_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CoffeeShopManagementFinalDataSet.FoodCategory' table. You can move, or remove it, as needed.
            this.FoodCategoryTableAdapter.Fill(this.CoffeeShopManagementFinalDataSet.FoodCategory);
            // TODO: This line of code loads data into the 'CoffeeShopManagementFinalDataSet.USP_GetListBillBylDateForReport' table. You can move, or remove it, as needed.
            this.USP_GetListBillBylDateForReportTableAdapter.Fill(this.CoffeeShopManagementFinalDataSet.USP_GetListBillBylDateForReport, dtpFromDate.Value, dtpToDate.Value);



            this.reportViewer1.RefreshReport();
         
        }

        private void tpBill_Click(object sender, EventArgs e)
        {

        }
    }
}
