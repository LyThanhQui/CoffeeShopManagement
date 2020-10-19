using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class DataProvider
    {
        private DataProvider() { }

        #region design patern Singleton
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance;}
            private set { DataProvider.instance = value; }
        }
      
        private string connectionSTR = "Data Source=QUI;Initial Catalog=CoffeeShopManagementFinal;Integrated Security=True";
        #endregion

        #region  Method

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            //using de giai phong bo nho cac thanh phan duoc tao ra ben trong no, han che loi
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            { 
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
                
            if(parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listpara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                     }

                }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            }

            return data;
        }

        //return number of rows is success. When insert, delete, update
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            //using de giai phong bo nho cac thanh phan duoc tao ra ben trong no, han che loi
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }

  
        public object ExecuteScalarQuery(string query, object[] parameter = null)
        {
           object data = 0; 
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
        #endregion
    }

}
