using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class FoodDAO
    {
        public FoodDAO() { }

        #region design patern Singleton
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }
        #endregion
      

        #region Method
        public List<FoodDTO> GetListFood(int id)     
        {
            List<FoodDTO> listFood = new List<FoodDTO>();
            string query = "SELECT * FROM Food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
        {
                FoodDTO food = new FoodDTO(item);
                listFood.Add(food);
        }
            return listFood;
        }
        public List<FoodDTO> GetListFood()
        {
            List<FoodDTO> listFood = new List<FoodDTO>();
            string query = "SELECT * FROM Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                listFood.Add(food);
            }
            return listFood;
        }   
        
        public List<FoodDTO> SearchFoodByName(string name)
        {
            List<FoodDTO> listFood = new List<FoodDTO>();
            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1 (name) LIKE  N'%' + dbo.fuConvertToUnsign1 (N'{0}') + N'%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public bool InsertFood(string name, int id, float price)
        {
          string query = string.Format( "INSERT INTO Food(name, idCategory, price) VALUES(N'{0}', {1}, {2})", name, id, price);
          int result =  DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(string name, int idCategory, float price, int id)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, idCategory, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleleFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void DeleteFoodByFoodID(int idCategory)
        {
            List<FoodDTO> listFood = new List<FoodDTO>();
            string query = string.Format("SELECT * FROM dbo.Food WHERE idCategory = {0}", idCategory);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                int id = food.ID;
                BillInfoDAO.Instance.DeleteBillInfoByFoodID(id);
                DeleleFood(id);

            }
        }

        public void DeleteFood(int idFood)
        {

            string query = string.Format("DELETE dbo.Food where idCategory = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
        }
        #endregion
    }
}
