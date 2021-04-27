using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomDTO
    {
        public RoomDTO(int maPhong, double dTSuDung, double giaCoBan, int tang, int soChoLamViec, int maCaoOc, string tinhTrang)
        {
            this.MaPhong = maPhong;
            this.DTSuDung = dTSuDung;
            this.GiaCoBan = giaCoBan;
            this.Tang = tang;
            this.SoChoLamViec = soChoLamViec;
            this.MaCaoOc = maCaoOc;
            this.tinhTrang = tinhTrang;

        }
        public RoomDTO(DataRow row)
        {
            this.MaPhong = (int)(row["MaPhong"]);
            this.DTSuDung = double.Parse((row["DTSuDung"].ToString()));
            this.GiaCoBan = double.Parse((row["GiaCoBan"].ToString()));
            this.Tang = (int)row["Tang"];
            this.SoChoLamViec = (int)row["SoChoLamViec"];
            this.MaCaoOc = (int)row["MaCaoOc"];
            this.tinhTrang = row["TinhTrang"].ToString();
        }
        private int maPhong;
        private double dTSuDung;
        private double giaCoBan;
        private int tang;
        private int soChoLamViec;
        private int maCaoOc;
        private string tinhTrang;

        public int MaPhong { get => maPhong; set => maPhong = value; }
        public double DTSuDung { get => dTSuDung; set => dTSuDung = value; }
        public double GiaCoBan { get => giaCoBan; set => giaCoBan = value; }
        public int Tang { get => tang; set => tang = value; }
        public int SoChoLamViec { get => soChoLamViec; set => soChoLamViec = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int MaCaoOc { get => maCaoOc; set => maCaoOc = value; }
    }
}
