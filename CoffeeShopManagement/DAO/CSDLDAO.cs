using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
   public class CSDLDAO
    {
        #region design patern Singleton
        private static CSDLDAO instance;
        public static CSDLDAO Instance
        {
            get { if (instance == null) instance = new CSDLDAO(); return CSDLDAO.instance; }
            private set { CSDLDAO.instance = value; }
        }

        #endregion
        public  bool SaoLuuDuLieu(string sDuongDan)
        {
            string sTen = "CoffeeShopManagementFinal.bak";
            string sql = "BACKUP DATABASE CoffeeShopManagementFinal TO DISK = \'" + sDuongDan + "\\" + sTen + "\'";
            int kq = DataProvider.Instance.ExecuteNonQuery(sql);
            return kq > 0;
        }
    }
}
