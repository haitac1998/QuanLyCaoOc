using BUS;
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
    public partial class frmAdmin : Form
    {
        BindingSource CustomerBinding = new BindingSource();
        BindingSource AccountBinding = new BindingSource();
        BindingSource BillBinding = new BindingSource();
        BindingSource CustomerRenewaBinding = new BindingSource();
        public AccountDTO LoginAccount;
        public frmAdmin()
        {
            InitializeComponent();
            LoadAll();

        }
        void LoadAll()
        {
            dtgvCustomer.DataSource = CustomerBinding;
            dtgvAccount.DataSource = AccountBinding;
            dtgvBill.DataSource = BillBinding;
            dtgvListCusRenewal.DataSource = CustomerRenewaBinding;
            CustomerBUS.Instance.LoadCustomerList(dtgvCustomer, CustomerBinding);
            AddCustomerBinding();
            AccountBUS.Instance.LoadListAccount(dtgvAccount, AccountBinding);
            AddAccountBinding();
            BillBUS.Instance.LoadListBill(dtgvBill,BillBinding);
            AddBillBinding();
            ContractRenewalBUS.Instance.LoadListRenewal(dtgvListCusRenewal, CustomerRenewaBinding, cbbReasonRenewal, txtIDRenewal);
            AddCustomerRenewalBinding();
            LoadListRoomEmpty();
            LoadListRoomRented();
            LoadListRoomRentalExpiresInMonth();
        }
        private void tcAdmin_SelectedIndexChanged(object sender, EventArgs e) // chọn accept button cho mỗi tag
        {
            if (tcAdmin.SelectedTab == tcAdmin.TabPages["tpCustomer"])
            {
                this.AcceptButton = btnSearchCus;
                txtSearchCus.Focus(); //focus textbox
            }
            else if (tcAdmin.SelectedTab == tcAdmin.TabPages["tpAccount"])
            {
                this.AcceptButton = btnSearchUser;
                txtSearchUser.Focus();
            }
            else if (tcAdmin.SelectedTab == tcAdmin.TabPages["tpBill"])
            {
                this.AcceptButton = btnSearchBill;
                txtSearchBill.Focus();
            }
            else if (tcAdmin.SelectedTab == tcAdmin.TabPages["tpContractRenewal"])
            {
                this.AcceptButton = btnSearchCusRenewa;
                txtNameCusRenewal.Focus();
            }
        }
        #region Customer
        void AddCustomerBinding()
        {
            dtpDOBCus.Format = DateTimePickerFormat.Custom;
            dtpDOBCus.CustomFormat = "dd/MM/yyyy";//sửa định dạng 
            txtIDCUS.DataBindings.Add(new Binding("text", dtgvCustomer.DataSource, "MaKH", true, DataSourceUpdateMode.Never)); // DataSourceUpdateMode.Never để không lưu lúc chọn textbox
            txtNameCus.DataBindings.Add(new Binding("text", dtgvCustomer.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            cbbSexCus.DataBindings.Add(new Binding("text", dtgvCustomer.DataSource, "GioiTinhKH", true, DataSourceUpdateMode.Never));
            txtPhoneCus.DataBindings.Add(new Binding("text", dtgvCustomer.DataSource, "SDTKH", true, DataSourceUpdateMode.Never));
            dtpDOBCus.DataBindings.Add(new Binding("text", dtgvCustomer.DataSource, "NgaySinhKH", true, DataSourceUpdateMode.Never)); //Thêm true để format theo dtgv

        }

        private void BtnLoadCus_Click(object sender, EventArgs e)
        {
            CustomerBUS.Instance.LoadCustomerList(dtgvCustomer, CustomerBinding);
        }
        private void btnInsertCus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneCus.Text))
            {
                MessageBox.Show("Please enter the phone number");
                return;
            }
            CustomerBUS.Instance.InsertCus(dtgvCustomer, CustomerBinding, txtNameCus.Text, txtPhoneCus.Text, dtpDOBCus.Value, cbbSexCus.Text);
        }

        private void btnEditCus_Click(object sender, EventArgs e)
        {
            CustomerBUS.Instance.EditCus(dtgvCustomer, CustomerBinding, txtIDCUS.Text, txtNameCus.Text, txtPhoneCus.Text, dtpDOBCus.Value, cbbSexCus.Text);
        }

        private void btnDeleteCus_Click(object sender, EventArgs e)
        {
            CustomerBUS.Instance.DeleteCus(dtgvCustomer, CustomerBinding, txtIDCUS.Text, txtNameCus.Text, txtPhoneCus.Text, dtpDOBCus.Value, cbbSexCus.Text);
        }
        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            CustomerBinding.DataSource = CustomerBUS.Instance.SearchListCusByName(txtSearchCus.Text);
        }
        
        private void txtPhoneCus_KeyPress(object sender, KeyPressEventArgs e) // chỉ nhập số 0-9
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtPhoneCus_Leave(object sender, EventArgs e) // khác 10 số thì reset
        {
            if (txtPhoneCus.Text.Length != 9)
            {
                txtPhoneCus.Clear();
                MessageBox.Show("Please enter 9 numbers");
            }
        }
        #endregion
        #region Bill
    
        void AddBillBinding()
        {
            txtIDBill.DataBindings.Add(new Binding("text", dtgvBill.DataSource, "MaHoaDon", true, DataSourceUpdateMode.Never));
            txtIDCusBill.DataBindings.Add(new Binding("text", dtgvBill.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txtPaymentReason.DataBindings.Add(new Binding("text", dtgvBill.DataSource, "LyDoTT", true, DataSourceUpdateMode.Never));
            txtTotalPayment.DataBindings.Add(new Binding("text", dtgvBill.DataSource, "TongTienThanhToan", true, DataSourceUpdateMode.Never));
            //cbbUserType.DataBindings.Add(new Binding("text", dtgvBill.DataSource, "Loai", true, DataSourceUpdateMode.Never));
        }
        private void btnLoadListBill_Click(object sender, EventArgs e)
        {
            BillBUS.Instance.LoadListBill(dtgvBill,BillBinding);
        }

        private void btnSearchBill_Click(object sender, EventArgs e)
        {
            BillBinding.DataSource = BillBUS.Instance.SearchBillByID(int.Parse(txtSearchBill.Text.ToString()));
        }

      

        #endregion
        #region Account
        //void LoadListAccount()
        //{
        //    AccountBinding.DataSource = AccountDAO.Instance.GetListAccount();
        //    dtgvAccount.Columns[0].HeaderText = "Tên đăng nhập";
        //    dtgvAccount.Columns[1].HeaderText = "Quyền hạn";
        //    foreach (DataGridViewColumn col in dtgvAccount.Columns)
        //    {
        //        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
        //    }
        //}
        void AddAccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("text", dtgvAccount.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            cbbUserType.DataBindings.Add(new Binding("text", dtgvAccount.DataSource, "Loai", true, DataSourceUpdateMode.Never));

        }
        private void btnLoadUser_Click(object sender, EventArgs e)
        {
            AccountBUS.Instance.LoadListAccount(dtgvAccount, AccountBinding);
        }

        

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AccountBUS.Instance.AddAccount(dtgvAccount, AccountBinding, txtUserName.Text, cbbUserType.Text);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            AccountBUS.Instance.DeleteAccount(dtgvAccount, AccountBinding, txtUserName.Text,LoginAccount);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            AccountBUS.Instance.EditAccount(dtgvAccount, AccountBinding, txtUserName.Text, cbbUserType.Text);
        }

        private void btnResetAccPW_Click(object sender, EventArgs e)
        {
            AccountBUS.Instance.ResetAccount(dtgvAccount, AccountBinding, txtUserName.Text);
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            AccountBinding.DataSource =AccountBUS.Instance.SearchAccByName(txtSearchUser.Text);
        }

        #endregion
        #region Renewal

        
        void AddCustomerRenewalBinding()
        {
            txtIDCusRenewal.DataBindings.Add(new Binding("text", dtgvListCusRenewal.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txtNameCusRenewal.DataBindings.Add(new Binding("text", dtgvListCusRenewal.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            txtIDRoomRenewal.DataBindings.Add(new Binding("text", dtgvListCusRenewal.DataSource, "MaPhong", true, DataSourceUpdateMode.Never));
            txtPriceRenewal.DataBindings.Add(new Binding("text", dtgvListCusRenewal.DataSource, "GiaTP", true, DataSourceUpdateMode.Never));
            //cbbUserType.DataBindings.Add(new Binding("text", dtgvBill.DataSource, "Loai", true, DataSourceUpdateMode.Never));
        }
        private void btnSearchCusRenewa_Click(object sender, EventArgs e)
        {
            CustomerRenewaBinding.DataSource = CusRenewal_InfoBUS.Instance.SearchCusRenewal_InfoByListCus(txtNameCusRenewal.Text);
        }
        double CalSumMoneyRenewal()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            if (txtUtilityBills.Enabled == true)//tính tiền điện nước
            {
                double Ultility = 0;
                double.TryParse(txtUtilityBills.Text, out Ultility);
                txtTotalMoneyRenewal.Text = Ultility.ToString("c", culture);
                return Ultility;

            }
            else //tính tiền phong
            {
                double money = 0;
                double.TryParse(txtPriceRenewal.Text, out money);
                double nudValue = double.Parse(nudRenewalPeriod.Value.ToString());
                double SumMoney = money * nudValue;
                txtTotalMoneyRenewal.Text = SumMoney.ToString("c", culture);
                return SumMoney;
            }
        }
        private void nudRenewalPeriod_ValueChanged(object sender, EventArgs e)
        {

            CalSumMoneyRenewal();

        }
        private void btnRenewal_Click(object sender, EventArgs e)
        {
            DateTime DateRenewal = dtpDateContractRenewal.Value;
            int idCus = 0;
            int idRoom = 0;
            int idRenewal = 0;
            int.TryParse(txtIDCusRenewal.Text, out idCus);
            int.TryParse(txtIDRoomRenewal.Text, out idRoom);
            int.TryParse(txtIDRenewal.Text, out idRenewal);
            double SumOfMoney = CalSumMoneyRenewal();
            int RenewalPeriod = int.Parse(nudRenewalPeriod.Value.ToString());
            if (nudRenewalPeriod.Value == 0 && cbbReasonRenewal.SelectedItem.ToString() == "Room charge")
            {
                MessageBox.Show("Please select the month to renew!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtUtilityBills.Text) && cbbReasonRenewal.SelectedItem.ToString() == "Utility bills")
            {
                MessageBox.Show("Please enter your total utility bill!");
                return;
            }
            else
            {
                ContractRenewalBUS.Instance.AddRenewal(DateRenewal, idCus, cbbReasonRenewal, SumOfMoney, RenewalPeriod, idRoom, idRenewal, dtgvPrintBillRenewal, txtNameCusRenewal);
                this.Close();
            }

        }

        private void cbbReasonRenewal_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbReasonRenewal.SelectedItem.ToString() == "Room charge") // nếu cbb có giá trị là tiền phòng thì sẻ disable tiền điện nước
            {
                nudRenewalPeriod.Enabled = true;
                txtUtilityBills.Enabled = false;
            }
            else
            {
                nudRenewalPeriod.Enabled = false;
                txtUtilityBills.Enabled = true;
            }
        }
        private void txtIDRoomRenewal_TextChanged(object sender, EventArgs e)
        {
            CalSumMoneyRenewal();
        }
        private void txtUtilityBills_TextChanged(object sender, EventArgs e)
        {
            CalSumMoneyRenewal();
        }

        private void txtUtilityBills_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chỉ cho phép nhập kiểu float 
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        private void dtpDateContractRenewal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateContractRenewal.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Please select first payment time greater than current!");
                dtpDateContractRenewal.Value = DateTime.Now;
            }
        }


        #endregion
        #region EmptyRoom
        void LoadListRoomEmpty()
        {
            dtgvListRoomEmpty.DataSource = RoomDAO.Instance.GetListRoomEmpty();
            dtgvListRoomEmpty.Columns[0].HeaderText = "Room code";
            dtgvListRoomEmpty.Columns[1].HeaderText = "Usable area (m²)";
            dtgvListRoomEmpty.Columns[2].HeaderText = "Basic price (VND)";
            dtgvListRoomEmpty.Columns[3].HeaderText = "Floor";
            dtgvListRoomEmpty.Columns[4].HeaderText = "Number of workplaces";
            dtgvListRoomEmpty.Columns[5].HeaderText = "Status";
            dtgvListRoomEmpty.Columns[6].HeaderText = "Building code";
            foreach (DataGridViewColumn col in dtgvListRoomEmpty.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }
        #endregion
        #region RentedRoom
        void LoadListRoomRented()
        {
            dtgvListRoomRented.DataSource = RoomDAO.Instance.GetListRoomRented();
            dtgvListRoomRented.Columns[0].HeaderText = "Room code";
            dtgvListRoomRented.Columns[1].HeaderText = "Usable area (m²)";
            dtgvListRoomRented.Columns[2].HeaderText = "Basic price (VND)";
            dtgvListRoomRented.Columns[3].HeaderText = "Floor";
            dtgvListRoomRented.Columns[4].HeaderText = "Number of workplaces";
            dtgvListRoomRented.Columns[5].HeaderText = "Status";
            dtgvListRoomRented.Columns[6].HeaderText = "Building code";
            foreach (DataGridViewColumn col in dtgvListRoomRented.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }

        }
        #endregion
        #region RentalExpires
        void LoadListRoomRentalExpiresInMonth()
        {
            dtgvListRoomRentalExpires.DataSource = RoomDAO.Instance.GetListRoomRentalExpires();
            dtgvListRoomRentalExpires.Columns[0].HeaderText = "Room code";
            dtgvListRoomRentalExpires.Columns[1].HeaderText = "Usable area (m²)";
            dtgvListRoomRentalExpires.Columns[2].HeaderText = "Basic price (VND)";
            dtgvListRoomRentalExpires.Columns[3].HeaderText = "Floor";
            dtgvListRoomRentalExpires.Columns[4].HeaderText = "Number of workplaces";
            dtgvListRoomRentalExpires.Columns[5].HeaderText = "Status";
            dtgvListRoomRentalExpires.Columns[6].HeaderText = "Building code";
            foreach (DataGridViewColumn col in dtgvListRoomRentalExpires.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }

        #endregion

    }
}
