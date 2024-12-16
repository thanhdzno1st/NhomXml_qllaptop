namespace XML_CuoiKi
{
    partial class HoaDon
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
			this.label2 = new System.Windows.Forms.Label();
			this.tb_search = new System.Windows.Forms.TextBox();
			this.btn_search = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btn_themChiTiet = new System.Windows.Forms.Button();
			this.btn_xuat = new System.Windows.Forms.Button();
			this.tb_maHoaDon = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tb_tenkhachhang = new System.Windows.Forms.TextBox();
			this.btn_them = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(397, 16);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hoá đơn";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(292, 207);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mã hoá đơn:";
			// 
			// tb_search
			// 
			this.tb_search.Location = new System.Drawing.Point(379, 199);
			this.tb_search.Margin = new System.Windows.Forms.Padding(4);
			this.tb_search.Multiline = true;
			this.tb_search.Name = "tb_search";
			this.tb_search.Size = new System.Drawing.Size(172, 26);
			this.tb_search.TabIndex = 2;
			// 
			// btn_search
			// 
			this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_search.Location = new System.Drawing.Point(571, 191);
			this.btn_search.Margin = new System.Windows.Forms.Padding(4);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(112, 44);
			this.btn_search.TabIndex = 3;
			this.btn_search.Text = "Tìm kiếm";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(1338, 12);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 44);
			this.button2.TabIndex = 4;
			this.button2.Text = "Làm mới";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 19);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(891, 304);
			this.dataGridView1.TabIndex = 5;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// btn_themChiTiet
			// 
			this.btn_themChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btn_themChiTiet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_themChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_themChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_themChiTiet.ForeColor = System.Drawing.Color.White;
			this.btn_themChiTiet.Location = new System.Drawing.Point(26, 181);
			this.btn_themChiTiet.Margin = new System.Windows.Forms.Padding(4);
			this.btn_themChiTiet.Name = "btn_themChiTiet";
			this.btn_themChiTiet.Size = new System.Drawing.Size(234, 60);
			this.btn_themChiTiet.TabIndex = 8;
			this.btn_themChiTiet.Text = "Thêm chi tiết hoá đơn";
			this.btn_themChiTiet.UseVisualStyleBackColor = false;
			this.btn_themChiTiet.Click += new System.EventHandler(this.button3_Click);
			// 
			// btn_xuat
			// 
			this.btn_xuat.BackColor = System.Drawing.Color.Lime;
			this.btn_xuat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_xuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_xuat.ForeColor = System.Drawing.Color.White;
			this.btn_xuat.Location = new System.Drawing.Point(698, 183);
			this.btn_xuat.Margin = new System.Windows.Forms.Padding(4);
			this.btn_xuat.Name = "btn_xuat";
			this.btn_xuat.Size = new System.Drawing.Size(234, 60);
			this.btn_xuat.TabIndex = 15;
			this.btn_xuat.Text = "Xuất hoá đơn";
			this.btn_xuat.UseVisualStyleBackColor = false;
			this.btn_xuat.Click += new System.EventHandler(this.btn_xuat_Click);
			// 
			// tb_maHoaDon
			// 
			this.tb_maHoaDon.Enabled = false;
			this.tb_maHoaDon.Location = new System.Drawing.Point(112, 36);
			this.tb_maHoaDon.Margin = new System.Windows.Forms.Padding(4);
			this.tb_maHoaDon.Multiline = true;
			this.tb_maHoaDon.Name = "tb_maHoaDon";
			this.tb_maHoaDon.Size = new System.Drawing.Size(95, 26);
			this.tb_maHoaDon.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(265, 41);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Tên khách hàng";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(29, 41);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Mã hoá đơn";
			// 
			// tb_tenkhachhang
			// 
			this.tb_tenkhachhang.Location = new System.Drawing.Point(373, 36);
			this.tb_tenkhachhang.Margin = new System.Windows.Forms.Padding(4);
			this.tb_tenkhachhang.Multiline = true;
			this.tb_tenkhachhang.Name = "tb_tenkhachhang";
			this.tb_tenkhachhang.Size = new System.Drawing.Size(151, 26);
			this.tb_tenkhachhang.TabIndex = 13;
			// 
			// btn_them
			// 
			this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btn_them.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_them.ForeColor = System.Drawing.Color.White;
			this.btn_them.Location = new System.Drawing.Point(671, 15);
			this.btn_them.Margin = new System.Windows.Forms.Padding(4);
			this.btn_them.Name = "btn_them";
			this.btn_them.Size = new System.Drawing.Size(234, 60);
			this.btn_them.TabIndex = 9;
			this.btn_them.Text = "Thêm hoá đơn";
			this.btn_them.UseVisualStyleBackColor = false;
			this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btn_them);
			this.panel1.Controls.Add(this.tb_tenkhachhang);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tb_maHoaDon);
			this.panel1.Location = new System.Drawing.Point(26, 49);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(923, 96);
			this.panel1.TabIndex = 14;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.ForeColor = System.Drawing.Color.Blue;
			this.groupBox1.Location = new System.Drawing.Point(26, 261);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(923, 336);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Danh sách hoá đơn";
			// 
			// HoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Controls.Add(this.btn_xuat);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btn_themChiTiet);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.tb_search);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "HoaDon";
			this.Size = new System.Drawing.Size(979, 611);
			this.Load += new System.EventHandler(this.HoaDon_load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_themChiTiet;
        private System.Windows.Forms.Button btn_xuat;
        private System.Windows.Forms.TextBox tb_maHoaDon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_tenkhachhang;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

