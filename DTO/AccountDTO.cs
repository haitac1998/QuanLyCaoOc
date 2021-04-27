using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class AccountDTO
    {
        public AccountDTO(string tenDangNhap, string matKhau, string loai)
        {
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.Loai = loai;
        }
        public AccountDTO(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.Loai = row["Loai"].ToString();
        }
        private string tenDangNhap;
        private string matKhau;
        private string loai;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Loai { get => loai; set => loai = value; }
    }
}
