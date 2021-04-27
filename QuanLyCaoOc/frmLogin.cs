using BUS;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit the program?", "Message", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            string PassWork = txtPassWork.Text;
            if (AccountBUS.Instance.Login(UserName, PassWork)/*true*/)
            {
                frmMain f = new frmMain(AccountBUS.Instance.LoginAcc(UserName));
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Wrong username or password", "Message!");
        }
    }
}
