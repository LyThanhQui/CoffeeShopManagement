using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class fAccountProfile : Form
    {
        #region field and properties
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        #endregion

        #region contructors
        public fAccountProfile(AccountDTO acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        #endregion

        #region Method
        void ChangeAccount(AccountDTO acc)
        {
            txbUserName.Text = acc.UserName;
            txbDisplayName.Text = acc.DisplayName;
        }
        void UpdateAccountInfo()
        {
            try
            {
                string displayName = txbDisplayName.Text;
                string password = txbPassWord.Text;
                string newpass = txbNewPassWord.Text;
                string returnPass = txbNewPassWordAgain.Text;
                string userName = txbUserName.Text;

                if (!newpass.Equals(returnPass))
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
                }
                else
                {
                    if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        if (updateAccount != null)
                            updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng điền đúng mật khấu");
                    }
                }
            }
            catch { }
        }
        #endregion

        #region Event
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        public class AccountEvent : EventArgs
        {
            private AccountDTO acc;

            public AccountDTO Acc
            {
                get { return acc; }
                set { acc = value; }
            }

            public AccountEvent(AccountDTO acc)
            {
                this.Acc = acc;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void cbrePass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbrePass.Checked)
            {
                txbNewPassWord.ReadOnly = false;
                txbNewPassWordAgain.ReadOnly = false;
            }
            else
            {
                txbNewPassWord.ReadOnly = true;
                txbNewPassWordAgain.ReadOnly = true;
            }
        }
        #endregion

    }
}