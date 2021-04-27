using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if (instance == null) instance = new BillDAO();return instance; }
            set => instance = value; 
        }
        private BillDAO() { }
        public void DeleteBillByCustomerID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from HoaDon where MaKH=" + id);
        }
        public List<BillDTO> GetListBillByCustomerID(int id)
        {
            List<BillDTO> listBill = new List<BillDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HOADON where MaKH=" + id);
            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                listBill.Add(bill);
            }
            return listBill;
        }
        public List<BillDTO> GetListBill()
        {
            List<BillDTO> listBill = new List<BillDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from hoadon");
            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                listBill.Add(bill);
            }
            return listBill;
        }
        public List<BillDTO> GetBillByBillID(int id)
        {
            List<BillDTO> listBill = new List<BillDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from hoadon where MaHoaDon=" + id);
            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                listBill.Add(bill);
            }
            return listBill;
        }
        public string GetNameCusByBillID(int id)
        {
            return (DataProvider.Instance.ExecuteQuery("select TenKH from KHACHHANG kh join HOADON hd on kh.MaKH = hd.MaKH where hd.MaHoaDon= " + id)).ToString(); 
        }
        public void DeleteBillByListCustomerID(int id)
        {
            List<BillDTO> ListBill = BillDAO.Instance.GetListBillByCustomerID(id);
            foreach (BillDTO item in ListBill)
            {
                DeleteBillByCustomerID(id);
            }
        }
        public int GetMaxIDBill()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select max(MaHoaDon) from HoaDon");
        }
        public bool InsertBill(DateTime DateOfPayment, string PaymentReason, double TotalPayment, int idCus)
        {
            string query = string.Format("insert into HoaDon (NgayTT, LyDoTT, TongTienThanhToan, MaKH )VALUES ( '{0}', N'{1}', '{2}', N'{3}')", DateOfPayment, PaymentReason, TotalPayment, idCus);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<BillDTO> SearchBillByIDBill(int id)
        {
            List<BillDTO> list = new List<BillDTO>();
            string query = string.Format("select * from HOADON where dbo.GetUnsignString(MaHoaDon) like '%' + dbo.GetUnsignString(N'{0}')+'%'", id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                list.Add(bill);
            }
            return list;
        }
    }
}
