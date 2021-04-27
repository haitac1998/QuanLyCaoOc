using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContractRental_InfoDTO
    {
        public ContractRental_InfoDTO(int maCTHDTP, int thoiGianTP, double giaTP, DateTime ngayHetHanTP)
        {
            this.MaCTHDTP = maCTHDTP;
            this.ThoiGianTP = thoiGianTP;
            this.GiaTP = giaTP;
            this.NgayHetHanTP = ngayHetHanTP;
        }
        public ContractRental_InfoDTO(DataRow row)
        {
            this.MaCTHDTP = (int)row["MaCTHDTP"];
            this.ThoiGianTP = (int)row["ThoiGianTP"];
            this.GiaTP = double.Parse((row["GiaTP"].ToString()));
            this.NgayHetHanTP = (row["NgayHetHanTP"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayHetHanTP"]));
        }
        private int maCTHDTP;
        private int thoiGianTP;
        private double giaTP;
        private DateTime ngayHetHanTP;

        public int MaCTHDTP { get => maCTHDTP; set => maCTHDTP = value; }
        public int ThoiGianTP { get => thoiGianTP; set => thoiGianTP = value; }
        public double GiaTP { get => giaTP; set => giaTP = value; }
        public DateTime NgayHetHanTP { get => ngayHetHanTP; set => ngayHetHanTP = value; }
    }
}
