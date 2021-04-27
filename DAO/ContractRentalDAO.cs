using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContractRentalDAO
    {
        private static ContractRentalDAO instance;

        public static ContractRentalDAO Instance 
        {
            get { if (instance == null) instance = new ContractRentalDAO(); return instance; } 
            set => instance = value; 
        }
        private ContractRentalDAO() { }
        public void DeteleContractRentalByCustomerID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from HOPDONGTP where MaKH=" + id);
        }
        public int GetContractRentalIDByCustomerID(int id)
        {
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("select MAHDTP from HOPDONGTP where MaKH=" + id));
        }
        public bool InsertContractRent(DateTime ValidiContract,DateTime FirstPay,int idCus)
        {
            string query = string.Format("insert into HOPDONGTP ( NgayHieuLucHD, NgayTTDauTien, MaKH)VALUES ( '{0}', '{1}', '{2}')", ValidiContract, FirstPay, idCus);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int GetMaxIDRental()
        {
            
            if (DataProvider.Instance.ExecuteScalar("select max(maHDTP) from HOPDONGTP") != DBNull.Value)
            {
                return (int)DataProvider.Instance.ExecuteScalar("select max(maHDTP) from HOPDONGTP");
            }
            return 0;
        }
    }
}
