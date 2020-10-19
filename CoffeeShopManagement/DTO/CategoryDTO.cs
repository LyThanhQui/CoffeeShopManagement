using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class CategoryDTO
    {
        #region field
        private int iD;
        private string name;
        #endregion

        #region properties
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region contructors
        public CategoryDTO (int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public CategoryDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
        }
        #endregion
    }
}
