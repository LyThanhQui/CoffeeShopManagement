using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class TableDTO
    {
        #region field
        private int iD;
        private string name;
        private string status;
        #endregion

        #region properties
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region contructors
        public TableDTO(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
        public TableDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();


        }
        #endregion

    }
}
