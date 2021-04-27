using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContractRentalDTO
    {
        public ContractRentalDTO(int maHDTP, DateTime ngayHieuLucHD, DateTime ngayTTDauTIen)
        {
            this.maHDTP = maHDTP;
            this.ngayHieuLucHD = ngayHieuLucHD;
            this.ngayTTDauTIen = ngayTTDauTIen;
        }
        public ContractRentalDTO(DataRow row)
        {
            this.MaHDTP = (int)row["MaHDTP"];
            this.NgayHieuLucHD = (row["NgayHieuLucHD"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayHieuLucHD"]));
            this.NgayTTDauTIen = (row["NgayTTDauTIen"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayTTDauTIen"]));
        }

        private int maHDTP;
        DateTime ngayHieuLucHD;
        DateTime ngayTTDauTIen;

        public int MaHDTP { get => maHDTP; set => maHDTP = value; }
        public DateTime NgayHieuLucHD { get => ngayHieuLucHD; set => ngayHieuLucHD = value; }
        public DateTime NgayTTDauTIen { get => ngayTTDauTIen; set => ngayTTDauTIen = value; }
    }
}
