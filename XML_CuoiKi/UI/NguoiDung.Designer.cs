namespace XML_CuoiKi
{
    partial class NguoiDung
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
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tb_diaChi = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_ngaySinh = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_email = new System.Windows.Forms.TextBox();
			this.tb_matKhau = new System.Windows.Forms.TextBox();
			this.tb_tenDangNhap = new System.Windows.Forms.TextBox();
			this.tb_sdt = new System.Windows.Forms.TextBox();
			this.tb_hoTen = new System.Windows.Forms.TextBox();
			this.bt_them = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.bt_xoa = new System.Windows.Forms.Button();
			this.bt_sua = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tb_phanQuyen = new System.Windows.Forms.ComboBox();
			this.tb_maND = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(584, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(181, 36);
			this.label1.TabIndex = 1;
			this.label1.Text = "Người dùng";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(47, 302);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(1205, 423);
			this.dataGridView1.TabIndex = 24;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
			// 
			// groupBox1
			// 
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.groupBox1.Location = new System.Drawing.Point(25, 278);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1247, 459);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Danh sách người dùng";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(806, 132);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "Phân quyền";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(434, 90);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Địa chỉ";
			// 
			// tb_diaChi
			// 
			this.tb_diaChi.Location = new System.Drawing.Point(540, 81);
			this.tb_diaChi.Margin = new System.Windows.Forms.Padding(4);
			this.tb_diaChi.Name = "tb_diaChi";
			this.tb_diaChi.Size = new System.Drawing.Size(180, 22);
			this.tb_diaChi.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 49);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Họ tên";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(434, 49);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Ngày sinh";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 90);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Số điện thoại";
			// 
			// tb_ngaySinh
			// 
			this.tb_ngaySinh.Location = new System.Drawing.Point(540, 41);
			this.tb_ngaySinh.Margin = new System.Windows.Forms.Padding(4);
			this.tb_ngaySinh.Name = "tb_ngaySinh";
			this.tb_ngaySinh.Size = new System.Drawing.Size(180, 22);
			this.tb_ngaySinh.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(37, 133);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Mật khẩu";
			// 
			// tb_email
			// 
			this.tb_email.Location = new System.Drawing.Point(995, 41);
			this.tb_email.Margin = new System.Windows.Forms.Padding(4);
			this.tb_email.Name = "tb_email";
			this.tb_email.Size = new System.Drawing.Size(180, 22);
			this.tb_email.TabIndex = 13;
			// 
			// tb_matKhau
			// 
			this.tb_matKhau.Location = new System.Drawing.Point(155, 129);
			this.tb_matKhau.Margin = new System.Windows.Forms.Padding(4);
			this.tb_matKhau.Name = "tb_matKhau";
			this.tb_matKhau.Size = new System.Drawing.Size(180, 22);
			this.tb_matKhau.TabIndex = 17;
			// 
			// tb_tenDangNhap
			// 
			this.tb_tenDangNhap.Location = new System.Drawing.Point(995, 81);
			this.tb_tenDangNhap.Margin = new System.Windows.Forms.Padding(4);
			this.tb_tenDangNhap.Name = "tb_tenDangNhap";
			this.tb_tenDangNhap.Size = new System.Drawing.Size(180, 22);
			this.tb_tenDangNhap.TabIndex = 12;
			// 
			// tb_sdt
			// 
			this.tb_sdt.Location = new System.Drawing.Point(155, 81);
			this.tb_sdt.Margin = new System.Windows.Forms.Padding(4);
			this.tb_sdt.Name = "tb_sdt";
			this.tb_sdt.Size = new System.Drawing.Size(180, 22);
			this.tb_sdt.TabIndex = 18;
			// 
			// tb_hoTen
			// 
			this.tb_hoTen.Location = new System.Drawing.Point(155, 41);
			this.tb_hoTen.Margin = new System.Windows.Forms.Padding(4);
			this.tb_hoTen.Name = "tb_hoTen";
			this.tb_hoTen.Size = new System.Drawing.Size(180, 22);
			this.tb_hoTen.TabIndex = 19;
			// 
			// bt_them
			// 
			this.bt_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.bt_them.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.bt_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bt_them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.bt_them.Location = new System.Drawing.Point(235, 172);
			this.bt_them.Margin = new System.Windows.Forms.Padding(4);
			this.bt_them.Name = "bt_them";
			this.bt_them.Size = new System.Drawing.Size(171, 46);
			this.bt_them.TabIndex = 20;
			this.bt_them.Text = "Thêm";
			this.bt_them.UseVisualStyleBackColor = false;
			this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(808, 91);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(98, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "Tên đăng nhập";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(808, 50);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 16);
			this.label8.TabIndex = 8;
			this.label8.Text = "Email";
			// 
			// bt_xoa
			// 
			this.bt_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.bt_xoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.bt_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bt_xoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.bt_xoa.Location = new System.Drawing.Point(811, 172);
			this.bt_xoa.Margin = new System.Windows.Forms.Padding(4);
			this.bt_xoa.Name = "bt_xoa";
			this.bt_xoa.Size = new System.Drawing.Size(171, 46);
			this.bt_xoa.TabIndex = 22;
			this.bt_xoa.Text = "Xoá";
			this.bt_xoa.UseVisualStyleBackColor = false;
			this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
			// 
			// bt_sua
			// 
			this.bt_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.bt_sua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.bt_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bt_sua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.bt_sua.Location = new System.Drawing.Point(523, 172);
			this.bt_sua.Margin = new System.Windows.Forms.Padding(4);
			this.bt_sua.Name = "bt_sua";
			this.bt_sua.Size = new System.Drawing.Size(171, 46);
			this.bt_sua.TabIndex = 21;
			this.bt_sua.Text = "Sửa";
			this.bt_sua.UseVisualStyleBackColor = false;
			this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.tb_phanQuyen);
			this.panel1.Controls.Add(this.tb_maND);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.bt_sua);
			this.panel1.Controls.Add(this.bt_xoa);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.bt_them);
			this.panel1.Controls.Add(this.tb_hoTen);
			this.panel1.Controls.Add(this.tb_sdt);
			this.panel1.Controls.Add(this.tb_tenDangNhap);
			this.panel1.Controls.Add(this.tb_matKhau);
			this.panel1.Controls.Add(this.tb_email);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tb_ngaySinh);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.tb_diaChi);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Location = new System.Drawing.Point(47, 45);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1205, 226);
			this.panel1.TabIndex = 23;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// tb_phanQuyen
			// 
			this.tb_phanQuyen.FormattingEnabled = true;
			this.tb_phanQuyen.Items.AddRange(new object[] {
            "nhan_vien",
            "admin",
            "khach_hang"});
			this.tb_phanQuyen.Location = new System.Drawing.Point(995, 125);
			this.tb_phanQuyen.Name = "tb_phanQuyen";
			this.tb_phanQuyen.Size = new System.Drawing.Size(180, 24);
			this.tb_phanQuyen.TabIndex = 25;
			// 
			// tb_maND
			// 
			this.tb_maND.Enabled = false;
			this.tb_maND.Location = new System.Drawing.Point(470, 10);
			this.tb_maND.Margin = new System.Windows.Forms.Padding(4);
			this.tb_maND.Name = "tb_maND";
			this.tb_maND.Size = new System.Drawing.Size(350, 22);
			this.tb_maND.TabIndex = 24;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(325, 15);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(108, 16);
			this.label11.TabIndex = 23;
			this.label11.Text = "Mã người dùng";
			// 
			// NguoiDung
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "NguoiDung";
			this.Size = new System.Drawing.Size(1305, 752);
			this.Load += new System.EventHandler(this.NguoiDung_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_diaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ngaySinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.TextBox tb_matKhau;
        private System.Windows.Forms.TextBox tb_tenDangNhap;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.TextBox tb_hoTen;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_maND;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox tb_phanQuyen;
    }
}