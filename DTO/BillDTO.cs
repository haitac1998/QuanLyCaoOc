using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        public BillDTO(int maHoaDon, DateTime ngayTT,string lyDoTT, double tongTienThanhToan,int maKH)
        {
            this.MaHoaDon = maHoaDon;
            this.NgayTT = ngayTT;
            this.LyDoTT = lyDoTT;
            this.TongTienThanhToan = tongTienThanhToan;
            this.MaKH = maKH;
        }
        public BillDTO(DataRow row)
        {
            this.MaHoaDon = (int)row["MaHoaDon"];
            this.NgayTT = (row["NgayTT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayTT"]));
            this.LyDoTT = row["LyDoTT"].ToString();
            this.TongTienThanhToan = double.Parse(row["TongTienThanhToan"].ToString());
            this.MaKH = (int)row["MaKH"];

        }
        private int maHoaDon;
        private DateTime ngayTT;
        private string lyDoTT;
        private double tongTienThanhToan;
        private int maKH;
        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime NgayTT { get => ngayTT; set => ngayTT = value; }
        public string LyDoTT { get => lyDoTT; set => lyDoTT = value; }
        public double TongTienThanhToan { get => tongTienThanhToan; set => tongTienThanhToan = value; }
        public int MaKH { get => maKH; set => maKH = value; }
    }
}
