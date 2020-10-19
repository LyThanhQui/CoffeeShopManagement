using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class AccountDTO
    {
        #region fields

        private int type;
        private string password;
        private string displayName;
        private string userName;
        #endregion

        #region properties
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        #endregion

        #region Contructors
        public AccountDTO(string userName, string displayName, int type, string password = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.Password = password;
        }

        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Type = (int)row["type"];
            this.Password = row["PassWord"].ToString();
        }
        #endregion
    }
}

