using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillInfoDTO
    {
        public BillInfoDTO(int maCTHoaDon)
        {
            this.MaCTHoaDon = maCTHoaDon;
        }
        public BillInfoDTO(DataRow row)
        {
            this.MaCTHoaDon = (int)row["MaCTHoaDon"];
        }
        private int maCTHoaDon;

        public int MaCTHoaDon { get => maCTHoaDon; set => maCTHoaDon = value; }
    }
}
