using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class FoodDTO
    {
        #region field
        private int iD;
        private string name;
        private int idCategory;
        private float price;
        #endregion

        #region properties
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
        #endregion

        #region contructors
        public FoodDTO(int id, string name, int idCatergoy, float price)
        {
            this.ID = id;
            this.name = name;
            this.IdCategory = idCategory;
            this.Price = price;
        }

        public FoodDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        #endregion
    }
}
