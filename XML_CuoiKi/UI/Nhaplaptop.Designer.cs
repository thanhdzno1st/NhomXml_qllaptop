namespace XML_CuoiKi.UI
{
    partial class Nhaplaptop
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_maNhaCungCap = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_maNhanVien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_maNhapHang = new System.Windows.Forms.TextBox();
            this.btn_themChiTiet = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(584, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 35);
            this.label7.TabIndex = 100;
            this.label7.Text = "Nhập Laptop";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 401);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1273, 339);
            this.dataGridView1.TabIndex = 96;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_maNhaCungCap);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tb_maNhanVien);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb_maNhapHang);
            this.panel1.Location = new System.Drawing.Point(16, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 187);
            this.panel1.TabIndex = 103;
            // 
            // tb_maNhaCungCap
            // 
            this.tb_maNhaCungCap.Location = new System.Drawing.Point(1048, 37);
            this.tb_maNhaCungCap.Margin = new System.Windows.Forms.Padding(4);
            this.tb_maNhaCungCap.Multiline = true;
            this.tb_maNhaCungCap.Name = "tb_maNhaCungCap";
            this.tb_maNhaCungCap.Size = new System.Drawing.Size(189, 26);
            this.tb_maNhaCungCap.TabIndex = 15;
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_them.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Location = new System.Drawing.Point(544, 115);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(186, 39);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm phiếu nhập";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(883, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mã nhà cung cấp";
            // 
            // tb_maNhanVien
            // 
            this.tb_maNhanVien.Location = new System.Drawing.Point(567, 37);
            this.tb_maNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.tb_maNhanVien.Multiline = true;
            this.tb_maNhanVien.Name = "tb_maNhanVien";
            this.tb_maNhanVien.Size = new System.Drawing.Size(189, 26);
            this.tb_maNhanVien.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mã nhập hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã nhân viên";
            // 
            // tb_maNhapHang
            // 
            this.tb_maNhapHang.Location = new System.Drawing.Point(173, 35);
            this.tb_maNhapHang.Margin = new System.Windows.Forms.Padding(4);
            this.tb_maNhapHang.Multiline = true;
            this.tb_maNhapHang.Name = "tb_maNhapHang";
            this.tb_maNhapHang.Size = new System.Drawing.Size(193, 26);
            this.tb_maNhapHang.TabIndex = 11;
            // 
            // btn_themChiTiet
            // 
            this.btn_themChiTiet.BackColor = System.Drawing.Color.Khaki;
            this.btn_themChiTiet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_themChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_themChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themChiTiet.Location = new System.Drawing.Point(196, 295);
            this.btn_themChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.btn_themChiTiet.Name = "btn_themChiTiet";
            this.btn_themChiTiet.Size = new System.Drawing.Size(208, 60);
            this.btn_themChiTiet.TabIndex = 107;
            this.btn_themChiTiet.Text = "Thêm chi tiết nhập";
            this.btn_themChiTiet.UseVisualStyleBackColor = false;
            this.btn_themChiTiet.Click += new System.EventHandler(this.btn_themChiTiet_Click);
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Location = new System.Drawing.Point(1014, 303);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 44);
            this.btn_search.TabIndex = 106;
            this.btn_search.Text = "Tìm kiếm";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(639, 303);
            this.tb_search.Margin = new System.Windows.Forms.Padding(4);
            this.tb_search.Multiline = true;
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(336, 40);
            this.tb_search.TabIndex = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 317);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 104;
            this.label2.Text = "Mã nhập hàng: ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1189, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 44);
            this.button2.TabIndex = 109;
            this.button2.Text = "Làm mới";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Nhaplaptop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_themChiTiet);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Nhaplaptop";
            this.Size = new System.Drawing.Size(1305, 752);
            this.Load += new System.EventHandler(this.Nhaplaptop_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_maNhaCungCap;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_maNhanVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_maNhapHang;
        private System.Windows.Forms.Button btn_themChiTiet;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}
