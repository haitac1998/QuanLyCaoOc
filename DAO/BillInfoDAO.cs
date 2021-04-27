using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO();return instance; } 
            set => instance = value; 
        }
        private BillInfoDAO() { }
        public void DeleteBillInfoByListBillInfo(int id)
        {
            List<BillInfoDTO> ListBillInfo = GetListBillInfoByCustomerID(id);

            foreach (BillInfoDTO item in ListBillInfo)
            {
                DeleteBillInfoByBillID(item.MaCTHoaDon);
            }
        }
        public void DeleteBillInfoByListCustomerID(int id)
        {
            List<BillDTO> ListBill = BillDAO.Instance.GetListBillByCustomerID(id);
            
            foreach (BillDTO item in ListBill)
            {
                DeleteBillInfoByBillID(item.MaHoaDon);
            }
        }
        public List<BillInfoDTO> GetListBillInfoByCustomerID(int id)
        {
            List<BillInfoDTO> ListBillInfo = new List<BillInfoDTO>();
            List<BillDTO> ListBill = BillDAO.Instance.GetListBillByCustomerID(id);
             DataTable data = new DataTable();
            foreach (BillDTO item in ListBill) //lấy danh sách MaCTHoaDon thêm vào data
            {
                DataTable temp = new DataTable();
                temp = DataProvider.Instance.ExecuteQuery("select * from CT_HoaDon where MaHoaDon=" + item.MaHoaDon);
                data.Merge(temp);
            }
            foreach (DataRow item in data.Rows)
            {
                BillInfoDTO billinfo = new BillInfoDTO(item);
                ListBillInfo.Add(billinfo);
            }
            return ListBillInfo;
        }
        public int GetBillInfoIDByCustomerID(int id)
        {
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("select MaCTHoaDon from CT_HOADON ct join HOADON hd on ct.MaHoaDon = hd.MaHoaDon where MaKH= " + id));
        }
        public void DeleteBillInfoByCustomerID(int id)
        {
            int BillInfoID = GetBillInfoIDByCustomerID(id);
            DataProvider.Instance.ExecuteQuery("delete from CT_HoaDon where MaCTHoaDon=" + BillInfoID);
        }
        public void DeleteBillInfoByBillID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from CT_HoaDon where MaCTHoaDon=" + id);
        }
        public bool InsertBillInfoWithoutIDRenewal(int idBill, int idContractRent)
        {
            string query = string.Format("insert into CT_HoaDon (MaHoaDon, MaHDTP ) VALUES ( {0}, {1})", idBill, idContractRent);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertBillInfoWithoutIDRent(int idBill, int idContractRenewal)
        {
            string query = string.Format("insert into CT_HoaDon (MaHoaDon, MaHDGH ) VALUES ( {0}, {1})", idBill, idContractRenewal);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
