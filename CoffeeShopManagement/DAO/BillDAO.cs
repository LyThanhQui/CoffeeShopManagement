using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class BillDAO
    {
        private BillDAO() { }

        #region design patern Singleton
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        #endregion
       

        #region Method
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable =" + id + " AND status = 0");
            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE DBO.Bill SET dateCheckOut = GETDATE(), status  = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice +" WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery(" EXEC USP_InsertBill @idtable", new object[] { id });
        }

        public void DeleteBillByTableID(int idtable)
        {
            List<BillDTO> listBill = new List<BillDTO>();
            string query = string.Format("SELECT * FROM dbo.Bill WHERE idtable = {0}", idtable);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                int id = bill.ID;   
                BillInfoDAO.Instance.DeleteBillInforByBillID(id);
                DeleteBill(id);
             
            }
        }
        public void DeleteBill(int id)
        {
            
            string query = string.Format("DELETE dbo.Bill WHERE id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
        }

 
         public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
          
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillBylDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
     

        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillBylDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum });
        }

        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalarQuery("exec USP_GetNumBillBylDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalarQuery("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }

        #endregion
    }
}
