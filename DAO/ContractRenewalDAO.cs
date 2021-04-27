using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContractRenewalDAO
    {
        private static ContractRenewalDAO instance;

        public static ContractRenewalDAO Instance
        {
            get { if (instance == null) instance = new ContractRenewalDAO(); return instance; }
            set => instance = value;
        }
        private ContractRenewalDAO() { }
        public void DeteleContractRenewalByCustomerID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from HOPDONGGH where MaKH=" + id);
        }
        public int GetContractRenewalIDByCustomerID(int id)
        {
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("select MAHDGH from HOPDONGGH where MaKH=" + id));
        }
        public int GetMaxIDRenewal()
        {
            if (DataProvider.Instance.ExecuteScalar("select max(MaHDGH) from HOPDONGGH") != DBNull.Value)
            {
                return (int)DataProvider.Instance.ExecuteScalar("select max(MaHDGH) from HOPDONGGH");
            }
            return 0;
        }
        public bool InsertContractRenewal(DateTime DateRenewal, int idCus)
        {
            string query = string.Format("insert into HOPDONGGH ( NgayKyGiaHan, MaKH)VALUES ( '{0}', {1})", DateRenewal, idCus);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
