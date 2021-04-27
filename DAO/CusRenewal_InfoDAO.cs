using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CusRenewal_InfoDAO
    {
        private static CusRenewal_InfoDAO instance;

        public static CusRenewal_InfoDAO Instance 
        {
            get{ if (instance == null) instance = new CusRenewal_InfoDAO(); return instance; }
            set => instance = value; 
        }
        private CusRenewal_InfoDAO() { }


        public List<CusRenewal_InfoDTO> SearchListContractRenewal_InfoByListCusID(List<CustomerDTO> list)
        {
            List<CusRenewal_InfoDTO> CusRenewal_InfoList = new List<CusRenewal_InfoDTO>();
            foreach (var item in list)
            {
                string query = string.Format("select * from CT_HOPDONGTP cthdtp join HOPDONGTP hdtp on cthdtp.MaHDTP=hdtp.MaHDTP join KHACHHANG kh on hdtp.MaKH = kh.MaKH where kh.MaKH={0}", item.MaKH);
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow item1 in data.Rows)
                {
                    CusRenewal_InfoDTO CusRenewal = new CusRenewal_InfoDTO(item1);
                    CusRenewal_InfoList.Add(CusRenewal);
                }
            }
            return CusRenewal_InfoList;
        }
        public List<CusRenewal_InfoDTO> GetListCusRenewal_Info()
        {
            List<CusRenewal_InfoDTO> CusRenewalList = new List<CusRenewal_InfoDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from CT_HOPDONGTP cthdtp join HOPDONGTP hdtp on cthdtp.MaHDTP=hdtp.MaHDTP join KHACHHANG kh on hdtp.MaKH = kh.MaKH");
            foreach (DataRow item in data.Rows)
            {
                CusRenewal_InfoDTO customer = new CusRenewal_InfoDTO(item);
                CusRenewalList.Add(customer);
            }
            return CusRenewalList;
        }
    }
}
