namespace MAIN_UI
{
    partial class DiemForm1
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
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnXemDanhSachDiem = new System.Windows.Forms.Button();
            this.cbbFilterByNamHoc = new System.Windows.Forms.ComboBox();
            this.cbbFilterByHocKy = new System.Windows.Forms.ComboBox();
            this.cbbFilterByNganh = new System.Windows.Forms.ComboBox();
            this.cbbFilterByLop = new System.Windows.Forms.ComboBox();
            this.cbbFilterByMonHoc = new System.Windows.Forms.ComboBox();
            this.cbbFilterByHinhThucThi = new System.Windows.Forms.ComboBox();
            this.cbbFilterByLanThi = new System.Windows.Forms.ComboBox();
            this.cbbFilterBySinhVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutputLanThi = new System.Windows.Forms.TextBox();
            this.txtOutputSinhVien = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOutputDiem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOutputId = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDiem
            // 
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Location = new System.Drawing.Point(12, 198);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.Size = new System.Drawing.Size(788, 240);
            this.dgvDiem.TabIndex = 0;
            //this.dgvDiem.SelectionChanged += new System.EventHandler(this.dgvDiem_SelectionChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(825, 220);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 33);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(825, 259);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 33);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(825, 298);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 33);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(825, 401);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 33);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(825, 181);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 33);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnXemDanhSachDiem
            // 
            this.btnXemDanhSachDiem.Location = new System.Drawing.Point(825, 337);
            this.btnXemDanhSachDiem.Name = "btnXemDanhSachDiem";
            this.btnXemDanhSachDiem.Size = new System.Drawing.Size(112, 58);
            this.btnXemDanhSachDiem.TabIndex = 6;
            this.btnXemDanhSachDiem.Text = "Xem Danh Sách Điểm";
            this.btnXemDanhSachDiem.UseVisualStyleBackColor = true;
            this.btnXemDanhSachDiem.Click += new System.EventHandler(this.btnXemDanhSachDiem_Click);
            // 
            // cbbFilterByNamHoc
            // 
            this.cbbFilterByNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByNamHoc.FormattingEnabled = true;
            this.cbbFilterByNamHoc.Location = new System.Drawing.Point(71, 27);
            this.cbbFilterByNamHoc.Name = "cbbFilterByNamHoc";
            this.cbbFilterByNamHoc.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByNamHoc.TabIndex = 7;
            this.cbbFilterByNamHoc.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByNamHoc_SelectedIndexChanged);
            // 
            // cbbFilterByHocKy
            // 
            this.cbbFilterByHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByHocKy.FormattingEnabled = true;
            this.cbbFilterByHocKy.Location = new System.Drawing.Point(261, 27);
            this.cbbFilterByHocKy.Name = "cbbFilterByHocKy";
            this.cbbFilterByHocKy.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByHocKy.TabIndex = 8;
            this.cbbFilterByHocKy.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByHocKy_SelectedIndexChanged);
            // 
            // cbbFilterByNganh
            // 
            this.cbbFilterByNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByNganh.FormattingEnabled = true;
            this.cbbFilterByNganh.Location = new System.Drawing.Point(446, 27);
            this.cbbFilterByNganh.Name = "cbbFilterByNganh";
            this.cbbFilterByNganh.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByNganh.TabIndex = 9;
            this.cbbFilterByNganh.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByNganh_SelectedIndexChanged);

            // 
            // cbbFilterByLop
            // 
            this.cbbFilterByLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByLop.FormattingEnabled = true;
            this.cbbFilterByLop.Location = new System.Drawing.Point(629, 27);
            this.cbbFilterByLop.Name = "cbbFilterByLop";
            this.cbbFilterByLop.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByLop.TabIndex = 10;
            this.cbbFilterByLop.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByLop_SelectedIndexChanged);
            // 
            // cbbFilterByMonHoc
            // 
            this.cbbFilterByMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByMonHoc.FormattingEnabled = true;
            this.cbbFilterByMonHoc.Location = new System.Drawing.Point(71, 66);
            this.cbbFilterByMonHoc.Name = "cbbFilterByMonHoc";
            this.cbbFilterByMonHoc.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByMonHoc.TabIndex = 11;
            this.cbbFilterByMonHoc.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByMonHoc_SelectedIndexChanged);
            // 
            // cbbFilterByHinhThucThi
            // 
            this.cbbFilterByHinhThucThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByHinhThucThi.FormattingEnabled = true;
            this.cbbFilterByHinhThucThi.Location = new System.Drawing.Point(261, 66);
            this.cbbFilterByHinhThucThi.Name = "cbbFilterByHinhThucThi";
            this.cbbFilterByHinhThucThi.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByHinhThucThi.TabIndex = 12;
            this.cbbFilterByHinhThucThi.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByHinhThucThi_SelectedIndexChanged);
            // 
            // cbbFilterByLanThi
            // 
            this.cbbFilterByLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterByLanThi.FormattingEnabled = true;
            this.cbbFilterByLanThi.Location = new System.Drawing.Point(446, 66);
            this.cbbFilterByLanThi.Name = "cbbFilterByLanThi";
            this.cbbFilterByLanThi.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterByLanThi.TabIndex = 13;
            this.cbbFilterByLanThi.SelectedIndexChanged += new System.EventHandler(this.CbbFilterByLanThi_SelectedIndexChanged);
            // 
            // cbbFilterBySinhVien
            // 
            this.cbbFilterBySinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterBySinhVien.FormattingEnabled = true;
            this.cbbFilterBySinhVien.Location = new System.Drawing.Point(629, 66);
            this.cbbFilterBySinhVien.Name = "cbbFilterBySinhVien";
            this.cbbFilterBySinhVien.Size = new System.Drawing.Size(121, 21);
            this.cbbFilterBySinhVien.TabIndex = 14;
            this.cbbFilterBySinhVien.SelectedIndexChanged += new System.EventHandler(this.CbbFilterBySinhVien_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Năm Học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Học Kỳ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngành:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(582, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Lớp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Môn Học";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Hình thức";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Lần Thi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Sinh Viên:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbFilterBySinhVien);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbbFilterByNamHoc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbbFilterByHocKy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbbFilterByNganh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbbFilterByLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbFilterByMonHoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbFilterByHinhThucThi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbFilterByLanThi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 100);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc dữ liệu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutputLanThi);
            this.groupBox2.Controls.Add(this.txtOutputSinhVien);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtOutputDiem);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOutputId);
            this.groupBox2.Controls.Add(this.Id);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 74);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // txtOutputLanThi
            // 
            this.txtOutputLanThi.Enabled = false;
            this.txtOutputLanThi.Location = new System.Drawing.Point(678, 30);
            this.txtOutputLanThi.Name = "txtOutputLanThi";
            this.txtOutputLanThi.Size = new System.Drawing.Size(100, 20);
            this.txtOutputLanThi.TabIndex = 7;
            // 
            // txtOutputSinhVien
            // 
            this.txtOutputSinhVien.Enabled = false;
            this.txtOutputSinhVien.Location = new System.Drawing.Point(461, 30);
            this.txtOutputSinhVien.Name = "txtOutputSinhVien";
            this.txtOutputSinhVien.Size = new System.Drawing.Size(144, 20);
            this.txtOutputSinhVien.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(621, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Lần Thi:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(397, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Sinh Viên:";
            // 
            // txtOutputDiem
            // 
            this.txtOutputDiem.Enabled = false;
            this.txtOutputDiem.Location = new System.Drawing.Point(261, 30);
            this.txtOutputDiem.Name = "txtOutputDiem";
            this.txtOutputDiem.Size = new System.Drawing.Size(100, 20);
            this.txtOutputDiem.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Điểm:";
            // 
            // txtOutputId
            // 
            this.txtOutputId.Enabled = false;
            this.txtOutputId.Location = new System.Drawing.Point(71, 30);
            this.txtOutputId.Name = "txtOutputId";
            this.txtOutputId.Size = new System.Drawing.Size(100, 20);
            this.txtOutputId.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(18, 33);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(19, 13);
            this.Id.TabIndex = 0;
            this.Id.Text = "Id:";
            // 
            // DiemForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXemDanhSachDiem);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvDiem);
            this.Name = "DiemForm1";
            this.Text = "Quản Lý Điểm";
            this.Load += new System.EventHandler(this.DiemForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private Button btnRefresh;
        private Button btnXemDanhSachDiem;
        private ComboBox cbbFilterByNamHoc;
        private ComboBox cbbFilterByHocKy;
        private ComboBox cbbFilterByNganh;
        private ComboBox cbbFilterByLop;
        private ComboBox cbbFilterByMonHoc;
        private ComboBox cbbFilterByHinhThucThi;
        private ComboBox cbbFilterByLanThi;
        private ComboBox cbbFilterBySinhVien;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtOutputLanThi;
        private TextBox txtOutputSinhVien;
        private Label label11;
        private Label label10;
        private TextBox txtOutputDiem;
        private Label label9;
        private TextBox txtOutputId;
        private Label Id;
    }
}