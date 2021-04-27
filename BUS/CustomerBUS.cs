using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class CustomerBUS
    {
        private static CustomerBUS instance;

        public static CustomerBUS Instance
        {
            get { if (instance == null) instance = new CustomerBUS(); return instance; }
            set => instance = value;
        }
        
        private CustomerBUS() { }
        
            
        public void LoadCustomerList(DataGridView dtgvCustomer, BindingSource CustomerBinding)
        {
            CustomerBinding.DataSource = CustomerDAO.Instance.GetListCustomer(); // dùng custombiding để khi load lại không bị lỗi
            dtgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvCustomer.Columns[dtgvCustomer.ColumnCount - 4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;// cho dtgv vừa khung hình 
            dtgvCustomer.Columns[0].HeaderText = "Customer's code";
            dtgvCustomer.Columns[1].HeaderText = "First and Last name";
            dtgvCustomer.Columns[2].HeaderText = "Sex";
            dtgvCustomer.Columns[3].HeaderText = "Birthday";
            dtgvCustomer.Columns[4].HeaderText = "Phone Number";
            dtgvCustomer.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy"; // chỉnh format hiển thị ngày thành dd/mm
            foreach (DataGridViewColumn col in dtgvCustomer.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }
        public void InsertCus(DataGridView dtgvCustomer, BindingSource CustomerBinding,string Name,string Phone,DateTime dob,string Sex)
        {
            string name = Name;
            string phone = Phone;
            DateTime DOB = dob;
            string sex = Sex;
            if (string.IsNullOrWhiteSpace(name)) // check các textbox phải điền đầy đủ mới cho thêm 
            {
                MessageBox.Show("Please enter your name", "Message");
                return;
            }
            if (string.IsNullOrWhiteSpace(phone.ToString()))
            {
                MessageBox.Show("Please enter your phone number ", "Message");
                return;
            }
            if (string.IsNullOrWhiteSpace(DOB.ToString()))
            {
                MessageBox.Show("Please select a date of birth", "Message");
                return;
            }
            if (string.IsNullOrWhiteSpace(sex))
            {
                MessageBox.Show("Please select your gender", "Message");
                return;
            }

            if (CustomerDAO.Instance.InsertCus(name, phone, DOB, sex))
            {
                MessageBox.Show("More success", "Message");
                CustomerBUS.Instance.LoadCustomerList(dtgvCustomer, CustomerBinding);
            }
            else
                MessageBox.Show("Add failure", "Message");
        }
        public void EditCus(DataGridView dtgvCustomer, BindingSource CustomerBinding,string ID, string Name, string Phone, DateTime dob, string Sex)
        {
            int id = 0;
            int.TryParse(ID, out id);
            string name = Name;
            string phone = Phone;
            DateTime DOB = dob;
            string sex = Sex;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(DOB.ToString()) ||
                string.IsNullOrWhiteSpace(phone.ToString()) || string.IsNullOrWhiteSpace(sex.ToString())) // check các textbox phải điền đầy đủ mới cho sửa 
            {
                MessageBox.Show("Please select the customer to be repaired", "Message");
                return;
            }
            if (CustomerDAO.Instance.UpdateCus(id, name, phone, DOB, sex))
            {
                MessageBox.Show("Successfully repaired", "Message");
                CustomerBUS.Instance.LoadCustomerList(dtgvCustomer, CustomerBinding);
            }
            else
                MessageBox.Show("Fix failed ", "Message");
        }

        public void DeleteCus(DataGridView dtgvCustomer, BindingSource CustomerBinding, string ID, string Name, string Phone, DateTime dob, string Sex)
        {
            int id = 0;
            int.TryParse(ID, out id);
            if (string.IsNullOrWhiteSpace(id.ToString())) // check các textbox phải điền đầy đủ mới cho sửa 
            {
                MessageBox.Show("Please select the customer ID to delete", "Message");
                return;
            }
            BillInfoDAO.Instance.DeleteBillInfoByListCustomerID(id);
            BillDAO.Instance.DeleteBillByCustomerID(id);
            ContractRenewal_InfoDAO.Instance.DeleteListContractRenewal_InfoByCustomerID(id);
            ContractRental_InfoDAO.Instance.DeleteListContractRental_InfoByCustomerID(id);
            ContractRenewalDAO.Instance.DeteleContractRenewalByCustomerID(id);
            ContractRentalDAO.Instance.DeteleContractRentalByCustomerID(id);
            if (CustomerDAO.Instance.DeleteCus(id))
            {
                MessageBox.Show("Deleted successfully", "Message");
                CustomerBUS.Instance.LoadCustomerList(dtgvCustomer, CustomerBinding);
            }
            else
                MessageBox.Show("Deletion failed", "Message");
        }
        public List<CustomerDTO> SearchListCusByName(string name)
        {
            List<CustomerDTO> listCus = CustomerDAO.Instance.SearchListCusomterByName(name);
            return listCus;
        }
    }
}
