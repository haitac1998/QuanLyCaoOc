using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CusRenewal_InfoBUS
    {
        private static CusRenewal_InfoBUS instance;

        public static CusRenewal_InfoBUS Instance
        {
            get { if (instance == null) instance = new CusRenewal_InfoBUS(); return instance; }
            set => instance = value;
        }
        private CusRenewal_InfoBUS() { }
        public List<CusRenewal_InfoDTO> SearchCusRenewal_InfoByListCus(string name)
        {
            List<CusRenewal_InfoDTO> listCus = CusRenewal_InfoDAO.Instance.SearchListContractRenewal_InfoByListCusID(CustomerDAO.Instance.SearchListCusomterByName(name));
            return listCus;
        }
    }
}
