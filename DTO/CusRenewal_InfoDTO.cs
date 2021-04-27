using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CusRenewal_InfoDTO
    {
        public CusRenewal_InfoDTO(int maKH,int maPhong,int maHDTP,int maCTHDTP,DateTime ngayHetHanTP, string tenKH,double giaTP)
        {
            this.MaKH = maKH;
            this.MaPhong = maPhong;
            this.MaHDTP = maHDTP;
            this.MaCTHDTP = maCTHDTP;
            this.NgayHetHanTP = ngayHetHanTP;
            this.TenKH = tenKH;
            this.GiaTP = giaTP;
        }
        public CusRenewal_InfoDTO(DataRow row)
        {
            this.MaKH = (int)row["MaKH"];
            this.MaPhong = (int)row["MaPhong"];
            this.maHDTP = (int)row["MaHDTP"];
            this.MaCTHDTP = (int)row["MaCTHDTP"];
            this.NgayHetHanTP = (row["NgayHetHanTP"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayHetHanTP"]));
            this.TenKH = row["TenKH"].ToString();
            this.GiaTP =double.Parse((row["GiaTP"].ToString()));
        }
        private int maKH;
        private int maPhong;
        private int maHDTP;
        private int maCTHDTP;
        private string tenKH;
        DateTime ngayHetHanTP;
        private double giaTP;
        public int MaKH { get => maKH; set => maKH = value; }
        public int MaPhong { get => maPhong; set => maPhong = value; }
        public int MaHDTP { get => maHDTP; set => maHDTP = value; }
        public int MaCTHDTP { get => maCTHDTP; set => maCTHDTP = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public DateTime NgayHetHanTP { get => ngayHetHanTP; set => ngayHetHanTP = value; }
        public double GiaTP { get => giaTP; set => giaTP = value; }
    }
}
