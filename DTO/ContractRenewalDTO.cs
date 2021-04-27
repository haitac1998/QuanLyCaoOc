using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContractRenewalDTO
    {
        public ContractRenewalDTO(int mahdgh,DateTime ngaykygiahan)
        {
            this.MaHDGH = mahdgh;
            this.NgayKyGiaHan = ngaykygiahan;
        }
        public ContractRenewalDTO(DataRow row)
        {
            this.MaHDGH = (int)row["MaHDGH"];
            this.NgayKyGiaHan= (row["NgayKyGiaHan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayKyGiaHan"]));
        }
        private int maHDGH;
        private DateTime ngayKyGiaHan;

        public int MaHDGH { get => maHDGH; set => maHDGH = value; }
        public DateTime NgayKyGiaHan { get => ngayKyGiaHan; set => ngayKyGiaHan = value; }
    }
}
