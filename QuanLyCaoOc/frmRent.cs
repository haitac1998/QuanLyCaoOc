using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaoOc
{
    public partial class frmRent : Form
    {
        BindingSource CustomerBinding = new BindingSource();
        List<RoomDTO> listRoom = new List<RoomDTO>();
        public frmRent()
        {
            InitializeComponent();
            dtgvListCusRent.DataSource = CustomerBinding;
            LoadListCustomer();
            AddCustomerBinding();
        }
        
        public List<RoomDTO> LoadRoomListRoom(List<RoomDTO> list)
        {
            double TotalPrice = 0;
            foreach (RoomDTO item in list)
            {
                TotalPrice +=(item.GiaCoBan + (double)item.SoChoLamViec * 200000 + (double)item.Tang * 500000);
                txtIDRent.Text += item.MaPhong +",";
            }
            txtPriceRent.Text = TotalPrice.ToString();
            txtIDContractRent.Text = (ContractRentalDAO.Instance.GetMaxIDRental()+1).ToString();
            CalSumMoneyrent();
            listRoom = list;
            return list;
        }
        double CalSumMoneyrent()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            double money = double.Parse(txtPriceRent.Text.ToString());
            double nudValue = double.Parse(nudRentalPeriod.Value.ToString());
            double SumMoney = money * nudValue;
            txtMoney.Text = SumMoney.ToString("c", culture);
            return SumMoney;
        }
        void LoadListCustomer()
        {
            dtgvBill.Visible = false;
            dtpFirstPay.Format = DateTimePickerFormat.Custom;
            dtpFirstPay.CustomFormat = "dd/MM/yyyy";//sửa định dạng 
            dtpValidityConTract.Format = DateTimePickerFormat.Custom;
            dtpValidityConTract.CustomFormat = "dd/MM/yyyy";//sửa định dạng 
            CustomerBinding.DataSource = CustomerDAO.Instance.GetListCustomer(); // dùng custombiding để khi load lại không bị lỗi
            dtgvListCusRent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvListCusRent.Columns[dtgvListCusRent.ColumnCount - 4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;// cho dtgv vừa khung hình 
            dtgvListCusRent.Columns[1].HeaderText = "Customer Name";
            dtgvListCusRent.Columns[2].HeaderText = "Phone Number";
            dtgvListCusRent.Columns[4].HeaderText = "Date of birth";
            dtgvListCusRent.Columns[3].HeaderText = "Sex";
            dtgvListCusRent.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy"; // chỉnh format hiển thị ngày thành dd/mm
            foreach (DataGridViewColumn col in dtgvListCusRent.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }
        List<CustomerDTO> SearchCusByName(string name)
        {
            List<CustomerDTO> listCus = CustomerDAO.Instance.SearchListCusomterByName(name);
            return listCus;
        }

        void AddCustomerBinding()
        {
            txtIDCusRent.DataBindings.Add(new Binding("text", dtgvListCusRent.DataSource, "MaKH", true, DataSourceUpdateMode.Never)); // DataSourceUpdateMode.Never để không lưu lúc chọn textbox
            txtNameCusRent.DataBindings.Add(new Binding("text", dtgvListCusRent.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
        }
        private void btnCusRent_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
            this.Show();
        }

        private void btnSearchCusRent_Click(object sender, EventArgs e)
        {
            CustomerBinding.DataSource = SearchCusByName(txtNameCusRent.Text);
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            
            if (txtNameCusRent != null && !string.IsNullOrWhiteSpace(txtNameCusRent.Text))
            {
                int idCus = 0;
                int.TryParse(txtIDCusRent.Text, out idCus);
                DateTime ValidityConTract = dtpValidityConTract.Value;
                DateTime FirstPay = dtpFirstPay.Value;
                int RentalPeriod = int.Parse(nudRentalPeriod.Value.ToString());
                double SumOfMoney = CalSumMoneyrent();
                if (ContractRentalDAO.Instance.InsertContractRent(ValidityConTract, FirstPay, idCus))
                // tạo chi tiết hợp đồng thuê phòng cho mỗi phòng,và hóa đơn thanh toán
                {
                    if (BillDAO.Instance.InsertBill(FirstPay, "Tiền Phòng", SumOfMoney, idCus))
                    {


                        foreach (var item in listRoom)
                        {
                            DateTime expiraionDate = ValidityConTract.AddMonths(RentalPeriod);
                            double price = (item.GiaCoBan + item.SoChoLamViec * 200000 + item.Tang * 500000);
                            ContractRental_InfoDAO.Instance.InsertContractRentInfo(RentalPeriod, price, item.MaPhong, ContractRentalDAO.Instance.GetMaxIDRental(), expiraionDate);// thêm chi tiết hợp đồng TP cho từng phòng
                            BillInfoDAO.Instance.InsertBillInfoWithoutIDRenewal(BillDAO.Instance.GetMaxIDBill(), ContractRentalDAO.Instance.GetMaxIDRental());//Thêm chỉ tiết hóa đơn cho mỗi phòng thanh toán
                        }
                        MessageBox.Show("Successful contract creation!");
                        DialogResult dialog = MessageBox.Show("Do you want to print invoice?", "Invoice printing", MessageBoxButtons.YesNo);
                        if(dialog == DialogResult.Yes)
                        {
                            DGVPrinter printer = new DGVPrinter();
                            dtgvBill.DataSource = BillDAO.Instance.GetBillByBillID(BillDAO.Instance.GetMaxIDBill());
                            dtgvBill.Columns[0].HeaderText = "Code Bill";
                            dtgvBill.Columns[1].HeaderText = "Date of payment";
                            dtgvBill.Columns[2].HeaderText = "Payment reason";
                            dtgvBill.Columns[3].HeaderText = "Total payment";
                            dtgvBill.Columns[4].HeaderText = "Customer's code";
                            foreach (DataGridViewColumn col in dtgvBill.Columns)
                            {
                                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
                            }
                            printer.Title= " \r\n\r\r Contract payment invoice\r\n\r\n  ";
                            printer.SubTitle = "Customer Name:    " + txtNameCusRent.Text.ToString();
                            printer.PageNumbers = true;
                            printer.PageNumberInHeader = false;
                            printer.PorportionalColumns = true;
                            printer.HeaderCellAlignment = StringAlignment.Near;
                            printer.PrintDataGridView(dtgvBill);
                        }
                        else if (dialog == DialogResult.No)
                        {
                        }
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a customer to rent a room!");
            }

        }

        private void nudRentalPeriod_ValueChanged(object sender, EventArgs e)
        {
            CalSumMoneyrent();  
        }

        private void dtgvListCusRent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpValidityConTract_ValueChanged(object sender, EventArgs e)
        {
            if(dtpValidityConTract.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Please select a validity period greater than current!");
                dtpValidityConTract.Value = DateTime.Now;
            }
        }

        private void dtpFirstPay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFirstPay.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Please select first payment time greater than current!");
                dtpFirstPay.Value = DateTime.Now;
            }
        }
    }
}
