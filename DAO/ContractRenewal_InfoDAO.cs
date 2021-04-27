using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContractRenewal_InfoDAO
    {
        private static ContractRenewal_InfoDAO instance;

        public static ContractRenewal_InfoDAO Instance 
        {
            get { if (instance == null) instance = new ContractRenewal_InfoDAO();return instance; } 
            set => instance = value; 
        }
        private ContractRenewal_InfoDAO() { }
        public List<ContractRenewal_InfoDTO> GetListContractRenewal_InfoByCustomerID(int id)
        {
            int maHDGH = ContractRenewalDAO.Instance.GetContractRenewalIDByCustomerID(id);
            List<ContractRenewal_InfoDTO> list = new List<ContractRenewal_InfoDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from CT_HOPDONGGH where MAHDGH=" + maHDGH);
            foreach (DataRow item in data.Rows)
            {
                ContractRenewal_InfoDTO ContractRenewal_Info = new ContractRenewal_InfoDTO(item);
                list.Add(ContractRenewal_Info);
            }
            return list;
        }
        public void DeleteListContractRenewal_InfoByCustomerID(int id)
        {
            List<ContractRenewal_InfoDTO> list = GetListContractRenewal_InfoByCustomerID(id);
            foreach (ContractRenewal_InfoDTO item in list)
            {
                DeleteContractRenewal_InfoByID(item.MaCTHDGH);
            }
        }
        public void GetContracRenewal_InfoIDByCustomerID(int id)
        {
            int MAHDGH = ContractRenewalDAO.Instance.GetContractRenewalIDByCustomerID(id);

        }
        public void DeleteContractRenewal_InfoByID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from CT_HOPDONGGH where MaCTHDGH=" + id);
        }
        public bool InsertContractRenewal_Info(int RenewalPeriod,double PriceRenewal,int idRoom,int idRenewal)
        {
            string query = string.Format("insert into CT_HOPDONGGH (ThoiGianGH, GiaGH, MaPhong, MaHDGH) VALUES ( {0}, {1},{2},{3})", RenewalPeriod, PriceRenewal, idRoom, idRenewal);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
