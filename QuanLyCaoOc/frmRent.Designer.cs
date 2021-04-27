
namespace QuanLyCaoOc
{
    partial class frmRent
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDRent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvBill = new System.Windows.Forms.DataGridView();
            this.dtpValidityConTract = new System.Windows.Forms.DateTimePicker();
            this.txtPriceRent = new System.Windows.Forms.TextBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nudRentalPeriod = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBookRoom = new System.Windows.Forms.Button();
            this.dtpFirstPay = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDCusRent = new System.Windows.Forms.TextBox();
            this.txtNameCusRent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDContractRent = new System.Windows.Forms.TextBox();
            this.btnSearchCusRent = new System.Windows.Forms.Button();
            this.dtgvListCusRent = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRentalPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListCusRent)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "List of room codes for rent:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total price of the rooms:";
            // 
            // txtIDRent
            // 
            this.txtIDRent.Location = new System.Drawing.Point(145, 9);
            this.txtIDRent.Name = "txtIDRent";
            this.txtIDRent.ReadOnly = true;
            this.txtIDRent.Size = new System.Drawing.Size(100, 20);
            this.txtIDRent.TabIndex = 5;
            this.txtIDRent.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(322, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "Room rental agreement";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuanLyCaoOc.Properties.Resources.op65;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.dtgvBill);
            this.panel1.Controls.Add(this.dtpValidityConTract);
            this.panel1.Controls.Add(this.txtPriceRent);
            this.panel1.Controls.Add(this.txtMoney);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.nudRentalPeriod);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnBookRoom);
            this.panel1.Controls.Add(this.dtpFirstPay);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtIDCusRent);
            this.panel1.Controls.Add(this.txtNameCusRent);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIDRent);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtIDContractRent);
            this.panel1.Controls.Add(this.btnSearchCusRent);
            this.panel1.Controls.Add(this.dtgvListCusRent);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 503);
            this.panel1.TabIndex = 7;
            // 
            // dtgvBill
            // 
            this.dtgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBill.Location = new System.Drawing.Point(337, 12);
            this.dtgvBill.Name = "dtgvBill";
            this.dtgvBill.Size = new System.Drawing.Size(142, 48);
            this.dtgvBill.TabIndex = 33;
            // 
            // dtpValidityConTract
            // 
            this.dtpValidityConTract.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValidityConTract.Location = new System.Drawing.Point(713, 41);
            this.dtpValidityConTract.Name = "dtpValidityConTract";
            this.dtpValidityConTract.Size = new System.Drawing.Size(100, 20);
            this.dtpValidityConTract.TabIndex = 32;
            this.dtpValidityConTract.ValueChanged += new System.EventHandler(this.dtpValidityConTract_ValueChanged);
            // 
            // txtPriceRent
            // 
            this.txtPriceRent.Location = new System.Drawing.Point(145, 44);
            this.txtPriceRent.Name = "txtPriceRent";
            this.txtPriceRent.ReadOnly = true;
            this.txtPriceRent.Size = new System.Drawing.Size(100, 20);
            this.txtPriceRent.TabIndex = 31;
            this.txtPriceRent.TabStop = false;
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.Location = new System.Drawing.Point(400, 191);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(191, 26);
            this.txtMoney.TabIndex = 30;
            this.txtMoney.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(295, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Total Price";
            // 
            // nudRentalPeriod
            // 
            this.nudRentalPeriod.Location = new System.Drawing.Point(713, 111);
            this.nudRentalPeriod.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRentalPeriod.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudRentalPeriod.Name = "nudRentalPeriod";
            this.nudRentalPeriod.Size = new System.Drawing.Size(56, 20);
            this.nudRentalPeriod.TabIndex = 28;
            this.nudRentalPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRentalPeriod.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudRentalPeriod.ValueChanged += new System.EventHandler(this.nudRentalPeriod_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(777, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(586, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Time you want to rent:";
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.Location = new System.Drawing.Point(783, 185);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(98, 40);
            this.btnBookRoom.TabIndex = 4;
            this.btnBookRoom.Text = "Contracting";
            this.btnBookRoom.UseVisualStyleBackColor = true;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click);
            // 
            // dtpFirstPay
            // 
            this.dtpFirstPay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFirstPay.Location = new System.Drawing.Point(713, 77);
            this.dtpFirstPay.Name = "dtpFirstPay";
            this.dtpFirstPay.Size = new System.Drawing.Size(100, 20);
            this.dtpFirstPay.TabIndex = 3;
            this.dtpFirstPay.ValueChanged += new System.EventHandler(this.dtpFirstPay_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(588, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "First payment date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Effective date of contract:";
            // 
            // txtIDCusRent
            // 
            this.txtIDCusRent.Location = new System.Drawing.Point(145, 81);
            this.txtIDCusRent.Name = "txtIDCusRent";
            this.txtIDCusRent.ReadOnly = true;
            this.txtIDCusRent.Size = new System.Drawing.Size(100, 20);
            this.txtIDCusRent.TabIndex = 15;
            this.txtIDCusRent.TabStop = false;
            // 
            // txtNameCusRent
            // 
            this.txtNameCusRent.Location = new System.Drawing.Point(145, 114);
            this.txtNameCusRent.Name = "txtNameCusRent";
            this.txtNameCusRent.Size = new System.Drawing.Size(100, 20);
            this.txtNameCusRent.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Customer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Customer\'s code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Contract room code:";
            // 
            // txtIDContractRent
            // 
            this.txtIDContractRent.Location = new System.Drawing.Point(713, 9);
            this.txtIDContractRent.Name = "txtIDContractRent";
            this.txtIDContractRent.ReadOnly = true;
            this.txtIDContractRent.Size = new System.Drawing.Size(100, 20);
            this.txtIDContractRent.TabIndex = 19;
            this.txtIDContractRent.TabStop = false;
            // 
            // btnSearchCusRent
            // 
            this.btnSearchCusRent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCusRent.Location = new System.Drawing.Point(261, 113);
            this.btnSearchCusRent.Name = "btnSearchCusRent";
            this.btnSearchCusRent.Size = new System.Drawing.Size(89, 23);
            this.btnSearchCusRent.TabIndex = 1;
            this.btnSearchCusRent.Text = "Search";
            this.btnSearchCusRent.UseVisualStyleBackColor = true;
            this.btnSearchCusRent.Click += new System.EventHandler(this.btnSearchCusRent_Click);
            // 
            // dtgvListCusRent
            // 
            this.dtgvListCusRent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListCusRent.Location = new System.Drawing.Point(3, 231);
            this.dtgvListCusRent.Name = "dtgvListCusRent";
            this.dtgvListCusRent.ReadOnly = true;
            this.dtgvListCusRent.Size = new System.Drawing.Size(878, 269);
            this.dtgvListCusRent.TabIndex = 14;
            this.dtgvListCusRent.TabStop = false;
            this.dtgvListCusRent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListCusRent_CellContentClick);
            // 
            // frmRent
            // 
            this.AcceptButton = this.btnSearchCusRent;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmRent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room rental agreement";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRentalPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListCusRent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDRent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameCusRent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgvListCusRent;
        private System.Windows.Forms.TextBox txtIDCusRent;
        private System.Windows.Forms.Button btnSearchCusRent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDContractRent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFirstPay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnBookRoom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudRentalPeriod;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPriceRent;
        private System.Windows.Forms.DateTimePicker dtpValidityConTract;
        private System.Windows.Forms.DataGridView dtgvBill;
    }
}