using DAO;
using DTO;
using QuanLyCaoOc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class ContractRenewalBUS
    {
        private static ContractRenewalBUS instance;

        public static ContractRenewalBUS Instance
        {
            get { if (instance == null) instance = new ContractRenewalBUS(); return instance; }
            set => instance = value;
        }
        private ContractRenewalBUS() { }
        public void LoadListRenewal(DataGridView dtgvListCusRenewal, BindingSource CustomerRenewaBinding, ComboBox cbb, TextBox tb)
        {
            cbb.SelectedIndex = 0;

            tb.Text = (ContractRenewalDAO.Instance.GetMaxIDRenewal() + 1).ToString();
            //giá trị mặc đinh cho cbb

            CustomerRenewaBinding.DataSource = CusRenewal_InfoDAO.Instance.GetListCusRenewal_Info(); // dùng custombiding để khi load lại không bị lỗi
            dtgvListCusRenewal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvListCusRenewal.Columns[dtgvListCusRenewal.ColumnCount - 6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;// cho dtgv vừa khung hình 
            dtgvListCusRenewal.Columns[0].HeaderText = "Customer's code";
            dtgvListCusRenewal.Columns[1].HeaderText = "Room Code";
            dtgvListCusRenewal.Columns[2].HeaderText = "Room rental contract code";
            dtgvListCusRenewal.Columns[3].HeaderText = "Detail code of the room rental";
            dtgvListCusRenewal.Columns[4].HeaderText = "Name of the customer rents the room";
            dtgvListCusRenewal.Columns[5].HeaderText = "Rent expiration date";
            dtgvListCusRenewal.Columns[6].HeaderText = "Room rental per month";

            dtgvListCusRenewal.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgvListCusRenewal.Columns[6].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");//set culture về vn cho dtgv
            dtgvListCusRenewal.Columns[6].DefaultCellStyle.Format = "c";
            foreach (DataGridViewColumn col in dtgvListCusRenewal.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }
        public void AddRenewal(DateTime DateRenewal, int idCus, ComboBox cbbReasonRenewal, double SumOfMoney, int RenewalPeriod, int idRoom, int idRenewal, DataGridView dtgvPrintBillRenewal, TextBox namecus)
        {
            if (ContractRenewalDAO.Instance.InsertContractRenewal(DateRenewal, idCus))
            {
                if (BillBUS.Instance.InsertBill(DateTime.Now, cbbReasonRenewal.Text.ToString(), SumOfMoney, idCus))
                {
                    ContractRenewal_InfoDAO.Instance.InsertContractRenewal_Info(RenewalPeriod, SumOfMoney, idRoom, idRenewal);
                    BillInfoDAO.Instance.InsertBillInfoWithoutIDRent(BillDAO.Instance.GetMaxIDBill(), idRenewal);
                    MessageBox.Show("Successful contract renewal!");
                    DialogResult dialog1 = MessageBox.Show("Do you want to print invoice?", "Invoice printing", MessageBoxButtons.YesNo);
                    if (dialog1 == DialogResult.Yes)
                    {
                        DGVPrinter printer = new DGVPrinter();
                        dtgvPrintBillRenewal.DataSource = BillDAO.Instance.GetBillByBillID(BillDAO.Instance.GetMaxIDBill());
                        dtgvPrintBillRenewal.Columns[0].HeaderText = "Code Bill";
                        dtgvPrintBillRenewal.Columns[1].HeaderText = "Date of payment";
                        dtgvPrintBillRenewal.Columns[2].HeaderText = "Payment reason";
                        dtgvPrintBillRenewal.Columns[3].HeaderText = "Total payment";
                        dtgvPrintBillRenewal.Columns[4].HeaderText = "Customer's code";
                        foreach (DataGridViewColumn col in dtgvPrintBillRenewal.Columns)
                        {
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
                        }
                        printer.Title = " \r\n\r\r Invoice for contract renewal\r\n\r\n  ";
                        printer.SubTitle = "Customer name:    " + namecus.Text.ToString();
                        printer.PageNumbers = true;
                        printer.PageNumberInHeader = false;
                        printer.PorportionalColumns = true;
                        printer.HeaderCellAlignment = StringAlignment.Near;
                        printer.PrintDataGridView(dtgvPrintBillRenewal);
                    }
                    else if (dialog1 == DialogResult.No)
                    {
                    }
                }
            }
        }
    }
}
