using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContractRental_InfoDAO
    {
        private static ContractRental_InfoDAO instance;

        public static ContractRental_InfoDAO Instance
        {
            get { if (instance == null) instance = new ContractRental_InfoDAO();return instance; } 
            set => instance = value;
        }
        private ContractRental_InfoDAO() { }
        public List<ContractRental_InfoDTO> GetListContractRental_InfoByCustomerID(int id)
        {
            int maHDTP = ContractRentalDAO.Instance.GetContractRentalIDByCustomerID(id);
            List<ContractRental_InfoDTO> list = new List<ContractRental_InfoDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from CT_HOPDONGTP where MAHDTP=" + maHDTP);
            foreach (DataRow item in data.Rows)
            {
                ContractRental_InfoDTO ContractRental_Info = new ContractRental_InfoDTO(item);
                list.Add(ContractRental_Info);
            }
            return list;
        }
        public void DeleteListContractRental_InfoByCustomerID(int id)
        {
            List<ContractRental_InfoDTO> list = GetListContractRental_InfoByCustomerID(id);
            foreach (ContractRental_InfoDTO item in list)
            {
                DeleteContractRental_InfoByID(item.MaCTHDTP);
            }
        }
        public void GetContractRental_InfoIDByCustomerID(int id)
        {
            int MAHDGH = ContractRentalDAO.Instance.GetContractRentalIDByCustomerID(id);

        }
        public void DeleteContractRental_InfoByID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from CT_HOPDONGTP where MaCTHDTP=" + id);
        }
        public bool InsertContractRentInfo(int RentalPeriod, double RentalPrice, int idRoom,int idContractRent,DateTime ExpirationDate)
        {
            string query = string.Format("insert into CT_HOPDONGTP ( ThoiGianTP, GiaTP, MaPhong, MaHDTP, NgayHetHanTP)VALUES ( '{0}', '{1}', '{2}','{3}','{4}')", RentalPeriod, RentalPrice, idRoom, idContractRent, ExpirationDate);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
    }
}
