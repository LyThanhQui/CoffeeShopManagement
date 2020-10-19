using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class CategoryDAO
    {
        private CategoryDAO() { }

        #region design patern Singleton
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        #endregion
       
        #region Method
        public List<CategoryDTO> GetListCategory()
        {
            List<CategoryDTO>  listCategory = new List<CategoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FoodCategory");
            foreach(DataRow item in data.Rows)
            {
                CategoryDTO category = new CategoryDTO(item);
                listCategory.Add(category);
            }
            return listCategory;
        }
           
        public CategoryDTO GetCategoryByID(int id)
        {
            CategoryDTO category = null;
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FoodCategory WHERE id = " + id);
            foreach (DataRow item in data.Rows)
            {
                category = new CategoryDTO(item);
                return category;
            }

            return category;
          
        }

        public bool DeleteCategoryFood(int idCategory)
        {
            FoodDAO.Instance.DeleteFoodByFoodID(idCategory);
            string query = string.Format("DELETE DBO.FoodCategory where id = {0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool AddCategory(string name)
        {
            string query = string.Format("INSERT INTO dbo.FoodCategory(name)values(N'{0}')",name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditCategory(int id, string name)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1}", name, id );
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
