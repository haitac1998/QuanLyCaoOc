using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            set => instance = value; 
        }
        private CustomerDAO() { }
        public List<CustomerDTO> GetListCustomer()
        {
            List<CustomerDTO> CustomerList = new List<CustomerDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from khachhang");
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                CustomerList.Add(customer);
            }
            return CustomerList;
        }
        public bool InsertCus(string name,string phone,DateTime DOB,string sex)
        {
            string query = string.Format("insert into KHACHHANG ( TenKH, SDTKH, NgaySinhKH, GioiTinhKH )VALUES ( N'{0}', N'{1}', '{2}', N'{3}')", name, phone, DOB, sex);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCus(int id,string name, string phone, DateTime DOB, string sex)
        {
            string query = string.Format("update KHACHHANG set TenKH = N'{0}', SDTKH= N'{1}', NgaySinhKH='{2}', GioiTinhKH=N'{3}' where MaKH={4}",name, phone, DOB, sex,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCus(int id)
        {
            string query = string.Format("delete from KHACHHANG where MaKH={0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<CustomerDTO> SearchListCusomterByName(string name)
        {
            List<CustomerDTO> CustomerList = new List<CustomerDTO>();
            string query = string.Format("select * from KHACHHANG where dbo.GetUnsignString(TenKH) like '%' + dbo.GetUnsignString(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO customer = new CustomerDTO(item);
                CustomerList.Add(customer);
            }
            return CustomerList;
        }
    }
}
