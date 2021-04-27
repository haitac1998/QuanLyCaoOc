using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;
        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return instance; }
            private set => instance = value;
        }


        private AccountBUS()
        {

        }
      
        public AccountDTO LoginAcc(string UserName)
        {
            return AccountDAO.Instance.GetAccountByUserName(UserName);
        }
        public bool Login(string UserName, string PassWork)
        {
            return   AccountDAO.Instance.Login(UserName, PassWork);
        }
        public void LoadListAccount(DataGridView dtgvAccount, BindingSource AccountBinding)
        {
            AccountBinding.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.Columns[0].HeaderText = "User Name";
            dtgvAccount.Columns[1].HeaderText = "Jurisdiction";
            foreach (DataGridViewColumn col in dtgvAccount.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn lề giữ cho tiêu đề
            }
        }
        public void AddAccount(DataGridView dtgvAccount, BindingSource AccountBinding,string Username,string Type)
        {
            string username = Username;
            string type = Type;
            if (string.IsNullOrWhiteSpace(Username)) // check các textbox phải điền đầy đủ mới cho thêm 
            {
                MessageBox.Show("Please enter the name", "Message");
                return;
            }
            if (string.IsNullOrWhiteSpace(Type))
            {
                MessageBox.Show("Please select the user type", "Message");
                return;
            }
            if (AccountDAO.Instance.InsertAcc(username, type))
            {
                MessageBox.Show("Add to public", "Message");
                AccountBUS.Instance.LoadListAccount(dtgvAccount, AccountBinding);
            }
            else
                MessageBox.Show("Add failed", "Message");
        }
        
        public void DeleteAccount(DataGridView dtgvAccount, BindingSource AccountBinding,string UserName,AccountDTO LoginAccount)
        {
            string username = UserName;
            if (string.IsNullOrWhiteSpace(UserName)) // phải chọn người xóa
            {
                MessageBox.Show("Please select the user is to delete", "Message");
                return;
            }
            if (LoginAccount.TenDangNhap.Equals(username))
            {
                MessageBox.Show("Can't destroy myself !!!", "Message");
                return;
            }
            if (AccountDAO.Instance.DeleteAcc(username))
            {
                MessageBox.Show("Deleted successfully", "Message");
                AccountBUS.Instance.LoadListAccount(dtgvAccount, AccountBinding);
            }
            else
                MessageBox.Show("Deletion failed", "Message");
        }
        public void EditAccount(DataGridView dtgvAccount, BindingSource AccountBinding,string UserName,string Type)
        {
            string username = UserName;
            string type = Type;
            if (string.IsNullOrWhiteSpace(UserName)) // check các textbox phải điền đầy đủ mới cho thêm 
            {
                MessageBox.Show("Please select a user to edit", "Message");
                return;
            }
            if (string.IsNullOrWhiteSpace(Type))
            {
                MessageBox.Show("Please select the type of user to repair", "Message");
                return;
            }
            if (AccountDAO.Instance.UpdateAcc(username, type))
            {
                MessageBox.Show("Successfully repaired", "Message");
                AccountBUS.Instance.LoadListAccount(dtgvAccount, AccountBinding);
            }
            else
                MessageBox.Show("Fix failed", "Message");
        }
        public void ResetAccount(DataGridView dtgvAccount, BindingSource AccountBinding,string UserName)
        {
            string username = UserName;
            if (AccountDAO.Instance.ResetAcc(username))
            {
                MessageBox.Show("Update successful", "Message");
                AccountBUS.Instance.LoadListAccount(dtgvAccount, AccountBinding);
            }
            else
                MessageBox.Show("Fix failed", "Message");
        }
        public DataTable SearchAccByName(string name)
        {
            return AccountDAO.Instance.SearchAccByUserName(name);
        }
    }
}
