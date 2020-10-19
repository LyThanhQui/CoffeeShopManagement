using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class TableDAO
    {
        public static int BtnWidth = 106;
        public static int BtnHeight = 106;
        private TableDAO() { }

        #region design patern Singleton
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        #endregion


        #region Method

        /* public TableDTO GetTableByID(int id)
         {
             TableDTO table = null;
             DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableFood WHERE id = " + id);
             foreach (DataRow item in data.Rows)
             {
                 table = new TableDTO(item);
                 return table;
             }

             return table;

         }*/
        public List<TableDTO> ShowTableFood()
        {
            List<TableDTO> listTableFood = new List<TableDTO>();
            //string query = "SELECT id as STT, name as [Bàn ăn], status as [Trạng thái] FROM dbo.TableFood";
            string query = "SELECT * FROM dbo.TableFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TableDTO tab = new TableDTO(item);
                listTableFood.Add(tab);
            }
            return listTableFood;
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }
        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> tableList = new List<TableDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public bool InsertTable(string name, string status)
        {
            string query = String.Format("INSERT INTO dbo.TableFood(name, status) Values(N'{0}', N'{1}')", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTableFood(int id, string name, string status)
        {
            string query = String.Format("UPDATE dbo.TableFood set name = N'{0}', status = N'{1}' WHERE id = {2}",name, status, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTableFood(int idTable, string status)
        {
            string query = String.Format("DELETE dbo.TableFood WHERE id = {0} AND STATUS = N'{1}'", idTable, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
