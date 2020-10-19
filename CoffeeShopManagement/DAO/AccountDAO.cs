using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class AccountDAO
    {
        private AccountDAO() { }

        #region design patern Singleton
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        #endregion

        #region Method
        public bool Login(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

           // var list = hasData.ToString();
            //list.Reverse();
    

            string query = "EXEC USP_Login @userName , @passWord ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName, hasPass /*list*/});
            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }


            byte[] tempNew = ASCIIEncoding.ASCII.GetBytes(newPass);
            byte[] hasDataNew = new MD5CryptoServiceProvider().ComputeHash(tempNew);

            string hasPassNew = "";

            foreach (byte item in hasDataNew)
            {
                hasPassNew += item;
            }

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, hasPass, hasPassNew });
            return result > 0;
        }

        public bool UpdateAccount(string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} Where UserName = N'{0}'", userName, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = string.Format("Delete dbo.Account where userName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool InsertAccount( string userName, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account (UserName, DisplayName, Type, passWord) VALUES (N'{0}' , N'{1}', {2}, N'{3}')", userName, displayName, type, "1962026656160185351301320480154111117132155");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPassWord(string userName)
        {
            string query = string.Format("UPDATE dbo.Account SET PassWord = N'20720532132149213101239102231223249249135100218' where userName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public AccountDTO GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }

            return null;
        }

       public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery(" SELECT Username [Tên tài khoản], DisplayName [Tên hiển thị], Type [Loại] FROM dbo.Account");
        }

        public List<AccountDTO> GetListAccountByRows()
        {
            List<AccountDTO> listAccout = new List<AccountDTO>();
            string query = "SELECT * FROM dbo.Account";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
;           foreach(DataRow item in data.Rows)
            {
                AccountDTO acc = new AccountDTO(item);
                listAccout.Add(acc);
            }

            return listAccout;
        }


        public static implicit operator AccountDAO(AccountDTO v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
