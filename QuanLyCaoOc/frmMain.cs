using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace QuanLyCaoOc
{
    public partial class frmMain : Form
    {
        public delegate List<RoomDTO> del_ListRoom(List<RoomDTO> list);
        public del_ListRoom GetListRoom;
        List<RoomDTO> ListRoomGB = new List<RoomDTO>();
        public frmMain()
        {
            InitializeComponent();

        }
        public frmMain(AccountDTO acc)
        {
            InitializeComponent();
            this.LoginAcc = acc;
            cbbFloor.SelectedItem = "1";
            ChangeAccount(acc.Loai);
        }
        private AccountDTO LoginAcc;

        public AccountDTO LoginAcc1 { get => LoginAcc; set => LoginAcc = value; }

        void LoadRoom(int floor)
        {
            /*CultureInfo culture = new CultureInfo("vi-VN"); *///Chuyển culture về VN
            //Thread.CurrentThread.CurrentCulture = culture; // chỉ dùng trong thread này,xài cái này sẻ lỗi format kiểu dữ liệu datetime
            flpRoom.Controls.Clear();
            List<RoomDTO> RoomList = RoomBUS.Instance.LoadRoomList();
            foreach (RoomDTO item in RoomList)
            {
                if (item.Tang == floor)
                {
                    Button btn = new Button() { Width = RoomBUS.width, Height = RoomBUS.height };
                    btn.Text = item.MaPhong + "\n" + item.TinhTrang;
                    btn.Click += Btn_Click;
                    btn.Tag = item;
                    switch (item.TinhTrang)
                    {
                        case "Trống":
                            btn.BackColor = Color.AliceBlue;
                            break;
                        case "Có Người":
                            btn.BackColor = Color.Goldenrod;
                            btn.Click -= Btn_Click;
                            break;
                    }
                    flpRoom.Controls.Add(btn);

                }
            }
            
        }
        List<RoomDTO> ShowListRoomRent(string id)
        {
            List<RoomDTO> listRoom = new List<RoomDTO>();
            try
            {
                DataTable data = RoomBUS.Instance.GetRoomByRoomid(int.Parse(id)); //lấy 1 room
                foreach (DataRow item in data.Rows)
                {
                    RoomDTO room = new RoomDTO(item);
                    listRoom.Add(room);

                }

                foreach (RoomDTO item in listRoom)
                {
                    CultureInfo culture = new CultureInfo("vi-VN");
                    bool found = false;
                    foreach (ListViewItem item1 in lvRoom.Items) // nếu phòng đả có trong danh sách thì cho người dùng nhập lại
                    {
                        if (item1.Text == item.MaPhong.ToString())
                        {
                            found = true;
                            MessageBox.Show("The room is in the rental list, please choose another room!");
                            break;
                        }
                    }
                    if (!found)
                    {
                        ListViewItem lvItem = new ListViewItem(item.MaPhong.ToString());
                        double Price = item.GiaCoBan + item.SoChoLamViec * 200000 + item.Tang * 500000;
                        lvItem.SubItems.Add(item.Tang.ToString());
                        lvItem.SubItems.Add(item.DTSuDung.ToString());
                        lvItem.SubItems.Add(item.SoChoLamViec.ToString());
                        lvItem.SubItems.Add(Price.ToString("c", culture));
                        lvRoom.Items.Add(lvItem);
                        ListRoomGB.AddRange(listRoom);
                    }
                }
                
                CalSumMoney();
            }
            catch (Exception e)
            {
                MessageBox.Show("Please select a room!");
            }

            return listRoom;

        }
        void CalSumMoney()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            double TotalPrice = 0;
            foreach (RoomDTO item in ListRoomGB)
            {
                TotalPrice += (item.GiaCoBan + item.SoChoLamViec * 200000 + item.Tang * 500000);
            }
            txtTotalPrice.Text = TotalPrice.ToString("c", culture);
        }
        void ChangeAccount(string type)
        {
            adminToolStripMenuItem.Visible = type == "Admin";
            TaiKhoanToolStripMenuItem.Text += " (" + LoginAcc1.TenDangNhap + ") ";
        }
        private void cbbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoom(Convert.ToInt32(cbbFloor.SelectedItem));
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int RoomID = ((sender as Button).Tag as RoomDTO).MaPhong;
            txtIDRoom.Text = RoomID.ToString();
            txtAera.Text = ((sender as Button).Tag as RoomDTO).DTSuDung.ToString();
            txtNOW.Text = ((sender as Button).Tag as RoomDTO).SoChoLamViec.ToString();
            txtAddress.Text = RoomBUS.Instance.GetAddressBuildingByRoomID(RoomID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfile f = new frmProfile(LoginAcc);
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            f.LoginAccount = LoginAcc;
            f.ShowDialog();
        }
        public List<RoomDTO> GetListCurrentRoom(List<RoomDTO> list)
        {
            return list;
        }
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (lvRoom.Items.Count != 0)
            {
                this.Hide();
                frmRent f = new frmRent();
                GetListRoom += new del_ListRoom(f.LoadRoomListRoom);
                GetListRoom(ListRoomGB);
                f.ShowDialog();
                this.Show();
                ClearAll();
            }
            else
                MessageBox.Show("Please select the room you want to rent in advance!");
        }

        private void btnAddListRoomRent_Click(object sender, EventArgs e)
        {
            ShowListRoomRent(txtIDRoom.Text);
        }

        private void btnResetLV_Click(object sender, EventArgs e)
        {
            lvRoom.Items.Clear();
            ListRoomGB.Clear();
            CalSumMoney();
        }
        void ClearAll() // Xóa tất cả sau khi lập hợp đồng
        {
            lvRoom.Items.Clear();
            ListRoomGB.Clear();
            txtIDRoom.Clear();
            txtAera.Clear();
            txtNOW.Clear();
            txtTotalPrice.Clear();
            txtAddress.Clear();
            LoadRoom(Convert.ToInt32(cbbFloor.SelectedItem));
        }
        private void btnDeleteOneLV_Click(object sender, EventArgs e) // xóa phòng đả chọn muốn thuê trong LV
        {
            for (int i = lvRoom.Items.Count - 1; i >= 0; i--)
            {
                if (lvRoom.Items[i].Selected)
                {
                    lvRoom.Items[i].Remove();
                    ListRoomGB.RemoveAt(i); // xóa luôn trong listroomGB
                }
            }
            CalSumMoney();
        }

        private void adfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit the program?", "Message", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
