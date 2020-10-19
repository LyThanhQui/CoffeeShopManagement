using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class BillInfoDTO
    {
        #region field
        private int count;
        private string foodID;
        private int billID;
        private int iD;
        #endregion

        #region properties
        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public string FoodID { get => foodID; set => foodID = value; }
        public int Count { get => count; set => count = value; }
        #endregion

        #region contructors
        public BillInfoDTO(int id, int billID, string foodID, int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.Count = count;
        }

        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.FoodID = row["idfood"].ToString();
            this.Count = (int)row["count"];
        }
        #endregion
    }
}
