namespace XML_CuoiKi
{
    partial class ThemChiTietHoaDon
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cb_laptop = new System.Windows.Forms.ComboBox();
			this.btn_them = new System.Windows.Forms.Button();
			this.tb_soLuong = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.lb_maHoaDon = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(315, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(265, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "Thêm chi tiết hoá đơn";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.cb_laptop);
			this.panel1.Controls.Add(this.btn_them);
			this.panel1.Controls.Add(this.tb_soLuong);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(56, 74);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(716, 106);
			this.panel1.TabIndex = 3;
			// 
			// cb_laptop
			// 
			this.cb_laptop.FormattingEnabled = true;
			this.cb_laptop.Items.AddRange(new object[] {
            "Dell",
            "HP",
            "Lenovo",
            "Apple",
            "Asus",
            "Acer",
            "Microsoft",
            "Razer",
            "MSI",
            "Samsung"});
			this.cb_laptop.Location = new System.Drawing.Point(144, 25);
			this.cb_laptop.Margin = new System.Windows.Forms.Padding(2);
			this.cb_laptop.Name = "cb_laptop";
			this.cb_laptop.Size = new System.Drawing.Size(142, 21);
			this.cb_laptop.TabIndex = 99;
			// 
			// btn_them
			// 
			this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_them.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btn_them.Location = new System.Drawing.Point(262, 66);
			this.btn_them.Name = "btn_them";
			this.btn_them.Size = new System.Drawing.Size(209, 28);
			this.btn_them.TabIndex = 6;
			this.btn_them.Text = "Thêm";
			this.btn_them.UseVisualStyleBackColor = false;
			this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
			// 
			// tb_soLuong
			// 
			this.tb_soLuong.Location = new System.Drawing.Point(488, 26);
			this.tb_soLuong.Name = "tb_soLuong";
			this.tb_soLuong.Size = new System.Drawing.Size(172, 20);
			this.tb_soLuong.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(415, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "Số lượng";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(51, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Chọn Laptop";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(56, 199);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(716, 252);
			this.dataGridView1.TabIndex = 4;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(359, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Mã hoá đơn: ";
			// 
			// lb_maHoaDon
			// 
			this.lb_maHoaDon.AutoSize = true;
			this.lb_maHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb_maHoaDon.Location = new System.Drawing.Point(470, 47);
			this.lb_maHoaDon.Name = "lb_maHoaDon";
			this.lb_maHoaDon.Size = new System.Drawing.Size(122, 24);
			this.lb_maHoaDon.TabIndex = 6;
			this.lb_maHoaDon.Text = "Mã hoá đơn: ";
			// 
			// ThemChiTietHoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(811, 481);
			this.Controls.Add(this.lb_maHoaDon);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Name = "ThemChiTietHoaDon";
			this.Text = "ThemHoaDon";
			this.Load += new System.EventHandler(this.ThemChiTietHoaDon_load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_soLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_maHoaDon;
		private System.Windows.Forms.ComboBox cb_laptop;
	}
}