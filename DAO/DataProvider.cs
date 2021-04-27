using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider();return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }


        private DataProvider()
        {

        }

        private string connectionSTR = @"Data Source=103.82.26.162,1433;Database=QLTPCO;User Id = sa; Password=0905521036Hai98;";
        public DataTable ExecuteQuery(string query,object[] parameter = null)//có thể null 
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
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
        public int ExecuteNonQuery(string query, object[] parameter = null)// trả về kết quả là số dòng dữ liệu bị ảnh hưởng(số dòng xóa, số dòng update...)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
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
        public object ExecuteScalar(string query, object[] parameter = null)//sẽ thi hành câu lệnh SQL và trả về 1 giá trị là cột đầu tiên của dòng đầu tiên. (Cho dù câu lệnh SQL thực tế trả về tập kết quả nhiều dòng nhiều cột)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
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
    }
}
