using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContractRenewal_InfoDTO
    {
        public ContractRenewal_InfoDTO(int maCTHDGH, int thoiGianGH, double giaGH)
        {
            this.MaCTHDGH = maCTHDGH;
            this.ThoiGianGH = thoiGianGH;
            this.GiaGH = giaGH;
        }
        public ContractRenewal_InfoDTO(DataRow row)
        {
            this.MaCTHDGH = (int)row["MaCTHDGH"];
            this.ThoiGianGH = (int)row["ThoiGianGH"];
            this.GiaGH = double.Parse((row["GiaGH"].ToString()));
        }
        private int maCTHDGH;
        private int thoiGianGH;
        private double giaGH;

        public int MaCTHDGH { get => maCTHDGH; set => maCTHDGH = value; }
        public int ThoiGianGH { get => thoiGianGH; set => thoiGianGH = value; }
        public double GiaGH { get => giaGH; set => giaGH = value; }
    }
}
