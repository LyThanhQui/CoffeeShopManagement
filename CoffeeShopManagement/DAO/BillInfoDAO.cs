using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class BillInfoDAO
    {
        private BillInfoDAO() { }

        #region design patern Singleton
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        #endregion

        #region Method
        public List<BillInfoDTO> GetListBillInfor(int id)
        {
            List<BillInfoDTO> listBillInfo = new List<BillInfoDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill =" + id);
            foreach(DataRow item in data.Rows)
            {
                BillInfoDTO info = new BillInfoDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfor @idBill , @idFood , @count ", new object[] { idBill, idFood, count });
        }

        public void DeleteBillInfoByFoodID(int idFood)
        {
         int retsult = DataProvider.Instance.ExecuteNonQuery(" DELETE dbo.BillInfo WHERE idFood = " + idFood);
        }


        public void DeleteBillInforByBillID(int idBill)
        {
            string query = string.Format("DELETE dbo.BillInfo WHERE idBill = {0}", idBill);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
        }
        #endregion
    }
}
