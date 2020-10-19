using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        #region Methods
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        #endregion

        #region Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txbUserName.Text;
                string password = txbPassWord.Text;

                if (Login(username, password))
                {

                    AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                    fTableManager f = new fTableManager(loginAccount);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
                }
            }
            catch { }
        }
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Thông báo", "Bạn có muốn thoát?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;

        }
        #endregion

    }
}
