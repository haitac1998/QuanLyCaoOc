using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BillBUS
    {
        private static BillBUS instance;

        public static BillBUS Instance
        {
            get { if (instance == null) instance = new BillBUS(); return instance; }
            set => instance = value;
        }
        private BillBUS() { }
        public void LoadListBill(DataGridView dtgvBill, BindingSource BillBinding)
        {
            BillBinding.DataSource = BillDAO.Instance.GetListBill();
            dtgvBill.Columns[0].HeaderText = "Code Bill";
            dtgvBill.Columns[1].HeaderText = "Date of payment";
            dtgvBill.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; //format datetime
            dtgvBill.Columns[2].HeaderText = "Payment reason";
            dtgvBill.Columns[3].HeaderText = "Total payment";
            dtgvBill.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");//set culture về vn cho dtgv
            dtgvBill.Columns[3].DefaultCellStyle.Format = "c";
            foreach (DataGridViewColumn col in dtgvBill.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }
        public List<BillDTO> SearchBillByID(int id)
        {
            List<BillDTO> listCus = BillDAO.Instance.SearchBillByIDBill(id);
            return listCus;
        }
        public bool InsertBill(DateTime DateOfPayment, string PaymentReason, double TotalPayment, int idCus)
        {
            return BillDAO.Instance.InsertBill(DateOfPayment, PaymentReason, TotalPayment, idCus);
        }
    }
}
