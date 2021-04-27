
namespace QuanLyCaoOc
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpRoom = new System.Windows.Forms.FlowLayoutPanel();
            this.cbbFloor = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvRoom = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBookRoom = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteOneLV = new System.Windows.Forms.Button();
            this.btnResetLV = new System.Windows.Forms.Button();
            this.btnAddListRoomRent = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNOW = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAera = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDRoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpRoom
            // 
            this.flpRoom.AutoScroll = true;
            this.flpRoom.BackgroundImage = global::QuanLyCaoOc.Properties.Resources.op65;
            this.flpRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpRoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpRoom.Location = new System.Drawing.Point(12, 35);
            this.flpRoom.Name = "flpRoom";
            this.flpRoom.Size = new System.Drawing.Size(789, 611);
            this.flpRoom.TabIndex = 0;
            // 
            // cbbFloor
            // 
            this.cbbFloor.DropDownHeight = 100;
            this.cbbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFloor.FormattingEnabled = true;
            this.cbbFloor.IntegralHeight = false;
            this.cbbFloor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbbFloor.Location = new System.Drawing.Point(149, 35);
            this.cbbFloor.Name = "cbbFloor";
            this.cbbFloor.Size = new System.Drawing.Size(57, 21);
            this.cbbFloor.TabIndex = 1;
            this.cbbFloor.SelectedIndexChanged += new System.EventHandler(this.cbbFloor_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(807, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 611);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lvRoom);
            this.panel3.Controls.Add(this.btnBookRoom);
            this.panel3.Location = new System.Drawing.Point(4, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 378);
            this.panel3.TabIndex = 2;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPrice.Location = new System.Drawing.Point(97, 294);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(139, 22);
            this.txtTotalPrice.TabIndex = 12;
            this.txtTotalPrice.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Total: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(148, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "List of rooms to rent";
            // 
            // lvRoom
            // 
            this.lvRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvRoom.FullRowSelect = true;
            this.lvRoom.GridLines = true;
            this.lvRoom.HideSelection = false;
            this.lvRoom.Location = new System.Drawing.Point(6, 30);
            this.lvRoom.Name = "lvRoom";
            this.lvRoom.Size = new System.Drawing.Size(444, 247);
            this.lvRoom.TabIndex = 2;
            this.lvRoom.TabStop = false;
            this.lvRoom.UseCompatibleStateImageBehavior = false;
            this.lvRoom.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Room Code";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Floor";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Area of use";
            this.columnHeader3.Width = 123;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Number of working places";
            this.columnHeader4.Width = 94;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price (VND)";
            this.columnHeader5.Width = 85;
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.Location = new System.Drawing.Point(349, 283);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(98, 40);
            this.btnBookRoom.TabIndex = 0;
            this.btnBookRoom.Text = "Booking";
            this.btnBookRoom.UseVisualStyleBackColor = true;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteOneLV);
            this.panel2.Controls.Add(this.btnResetLV);
            this.panel2.Controls.Add(this.btnAddListRoomRent);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNOW);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtAera);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtIDRoom);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbbFloor);
            this.panel2.Location = new System.Drawing.Point(4, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 202);
            this.panel2.TabIndex = 1;
            // 
            // btnDeleteOneLV
            // 
            this.btnDeleteOneLV.Location = new System.Drawing.Point(216, 159);
            this.btnDeleteOneLV.Name = "btnDeleteOneLV";
            this.btnDeleteOneLV.Size = new System.Drawing.Size(106, 40);
            this.btnDeleteOneLV.TabIndex = 1;
            this.btnDeleteOneLV.Text = "Delete selected rooms";
            this.btnDeleteOneLV.UseVisualStyleBackColor = true;
            this.btnDeleteOneLV.Click += new System.EventHandler(this.btnDeleteOneLV_Click);
            // 
            // btnResetLV
            // 
            this.btnResetLV.Location = new System.Drawing.Point(328, 159);
            this.btnResetLV.Name = "btnResetLV";
            this.btnResetLV.Size = new System.Drawing.Size(119, 40);
            this.btnResetLV.TabIndex = 2;
            this.btnResetLV.Text = "Delete the list of rooms you want to rent";
            this.btnResetLV.UseVisualStyleBackColor = true;
            this.btnResetLV.Click += new System.EventHandler(this.btnResetLV_Click);
            // 
            // btnAddListRoomRent
            // 
            this.btnAddListRoomRent.Location = new System.Drawing.Point(100, 159);
            this.btnAddListRoomRent.Name = "btnAddListRoomRent";
            this.btnAddListRoomRent.Size = new System.Drawing.Size(106, 40);
            this.btnAddListRoomRent.TabIndex = 0;
            this.btnAddListRoomRent.Text = "Add to the wish list to rent";
            this.btnAddListRoomRent.UseVisualStyleBackColor = true;
            this.btnAddListRoomRent.Click += new System.EventHandler(this.btnAddListRoomRent_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(100, 133);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(347, 20);
            this.txtAddress.TabIndex = 9;
            this.txtAddress.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Building address:";
            // 
            // txtNOW
            // 
            this.txtNOW.Location = new System.Drawing.Point(149, 97);
            this.txtNOW.Name = "txtNOW";
            this.txtNOW.ReadOnly = true;
            this.txtNOW.Size = new System.Drawing.Size(57, 20);
            this.txtNOW.TabIndex = 7;
            this.txtNOW.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Number of working places:";
            // 
            // txtAera
            // 
            this.txtAera.Location = new System.Drawing.Point(149, 65);
            this.txtAera.Name = "txtAera";
            this.txtAera.ReadOnly = true;
            this.txtAera.Size = new System.Drawing.Size(57, 20);
            this.txtAera.TabIndex = 5;
            this.txtAera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Area of use:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Floor:";
            // 
            // txtIDRoom
            // 
            this.txtIDRoom.Location = new System.Drawing.Point(149, 6);
            this.txtIDRoom.Name = "txtIDRoom";
            this.txtIDRoom.ReadOnly = true;
            this.txtIDRoom.Size = new System.Drawing.Size(57, 20);
            this.txtIDRoom.TabIndex = 1;
            this.txtIDRoom.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Room Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Room Information";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // TaiKhoanToolStripMenuItem
            // 
            this.TaiKhoanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.TaiKhoanToolStripMenuItem.Name = "TaiKhoanToolStripMenuItem";
            this.TaiKhoanToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.TaiKhoanToolStripMenuItem.Text = "Account";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Change the password";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Log Out";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // giớiThiệuToolStripMenuItem
            // 
            this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
            this.giớiThiệuToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.giớiThiệuToolStripMenuItem.Text = "Introduce";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.TaiKhoanToolStripMenuItem,
            this.giớiThiệuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1276, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnAddListRoomRent;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpRoom);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Building management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpRoom;
        private System.Windows.Forms.ComboBox cbbFloor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNOW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBookRoom;
        private System.Windows.Forms.ListView lvRoom;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnAddListRoomRent;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giớiThiệuToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnResetLV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteOneLV;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label8;
    }
}