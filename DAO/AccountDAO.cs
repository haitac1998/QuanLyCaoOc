using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value; 
        }
        private AccountDAO()
        {

        }
        public bool Login(string UserName, string PassWork)
        {
            //byte[] temp = ASCIIEncoding.ASCII.GetBytes(PassWork);
            //byte[] hash = new MD5CryptoServiceProvider().ComputeHash(temp); //mã hóa mật khẩu
            //string hashPass="";
            //foreach (byte item in hash)
            //{
            //    hashPass += item;
            //}
            string query = "USP_LOGIN @username , @passwork";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {UserName,PassWork});
            return result.Rows.Count > 0;
        }
        public bool ChangeInfoAcc(string username,string pass,string newpass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_SUAMATKHAU @username , @passwork , @newpasswork ", new object[] {username, pass, newpass });
            return result > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select tendangnhap,loai from NGUOIDUNG");
        }
        public AccountDTO GetAccountByUserName(string UserName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from NGUOIDUNG where tendangnhap='" + UserName+"'");
            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }
            return null;
        }
        public DataTable SearchAccByUserName(string username)
        {
            string query = string.Format("select TenDangNhap,Loai from NGUOIDUNG where dbo.GetUnsignString(TenDangNhap) like '%' + dbo.GetUnsignString(N'{0}')+'%'", username);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        //public List<AccountDTO> SearchAccByUserName(string username)
        //{
        //    List<AccountDTO> accList = new List<AccountDTO>();
        //    string query = string.Format("select TenDangNhap,Loai from NGUOIDUNG where dbo.GetUnsignString(TenDangNhap) like '%' + dbo.GetUnsignString(N'{0}')+'%'", username);
        //    DataTable data = DataProvider.Instance.ExecuteQuery(query);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        AccountDTO acc = new AccountDTO(item);
        //        accList.Add(acc);
        //    }
        //    return accList;
        //}

        public bool InsertAcc(string username,string type)
        {
            if (isExists(username))
            {
                string query = string.Format("insert into NGUOIDUNG ( TenDangNhap, Loai,MatKhau )VALUES ( N'{0}', N'{1}',N'{2}')", username, type, "123456");
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateAcc(string username,string type)
        {
            string query = string.Format("update NGUOIDUNG set Loai=N'{1}' where TenDangNhap=N'{0}'", username, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAcc(string username)
        {
            string query = string.Format("delete from NGUOIDUNG where TenDangNhap=N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetAcc(string username)
        {
            string query = string.Format("update NGUOIDUNG set MatKhau=N'123456' where TenDangNhap=N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool isExists(string userName)
        {
            string query = string.Format("SELECT * FROM NGUOIDUNG WHERE TenDangNhap = N'{0}'", userName);
            var test = DataProvider.Instance.ExecuteScalar(query);
            if (test == null)
                return true;
            else
                return false;
        }
    }
}
