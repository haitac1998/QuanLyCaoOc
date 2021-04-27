using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        public CustomerDTO(int maKH, string tenKH, string sDTKH, DateTime ngaySinhKH, string gioiTinhKH)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SDTKH = sDTKH;
            this.NgaySinhKH = ngaySinhKH;
            this.GioiTinhKH = gioiTinhKH;
        }
        public CustomerDTO(DataRow row)
        {
            this.MaKH = (int)row["MaKH"];
            this.TenKH = row["TenKH"].ToString();
            this.SDTKH = row["SDTKH"].ToString();
            this.NgaySinhKH = (row["NgaySinhKH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinhKH"]));
            this.GioiTinhKH = row["GioiTinhKH"].ToString();
        }
        private int maKH;
        private string tenKH;
        private string sDTKH;
        DateTime ngaySinhKH;
        string gioiTinhKH;

        public int MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string GioiTinhKH { get => gioiTinhKH; set => gioiTinhKH = value; }
        public DateTime NgaySinhKH { get => ngaySinhKH; set => ngaySinhKH = value; }
        public string SDTKH { get => sDTKH; set => sDTKH = value; }
    }
}
