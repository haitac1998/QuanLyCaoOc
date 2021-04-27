using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ContractRenewal_InfoBUS
    {
        private static ContractRenewal_InfoBUS instance;

        public static ContractRenewal_InfoBUS Instance
        {
            get { if (instance == null) instance = new ContractRenewal_InfoBUS(); return instance; }
            set => instance = value;
        }
        private ContractRenewal_InfoBUS() { }
        
    }
}
