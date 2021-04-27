using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaoOc
{
    public partial class frmProfile : Form
    {
        private AccountDTO loginacc;
        public frmProfile(AccountDTO acc)
        {

            InitializeComponent();
            loginacc = acc;
            ChangeAcc(loginacc);
        }

        void ChangeAcc(AccountDTO acc)
        {
            txtUserNameProfile.Text = Loginacc.TenDangNhap;

        }
        void UpdateAcc()
        {
            string username = txtUserNameProfile.Text;
            string passwork = txtPassworkProfile.Text;
            string newpass = txtNewPassProfile.Text;
            string repass = txtRePassworkProfile.Text;
            if (!newpass.Equals(repass))
                MessageBox.Show("Password incorrect, please try again", "Message");
            else
            {
                if (AccountDAO.Instance.ChangeInfoAcc(username, passwork, newpass))
                {
                    MessageBox.Show("Update successful");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("The password is not correct", "Message");
                    //if (MessageBox.Show("Mật khẩu nhập không đúng", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                    //{
                        
                    //}
                }
            }


        }
        public AccountDTO Loginacc { get => loginacc; set => loginacc = value; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAcc();
        }
    }
}
