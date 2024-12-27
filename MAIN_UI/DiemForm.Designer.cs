namespace MAIN_UI
{
    partial class DiemForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtInputId = new TextBox();
            txtInputDiem = new TextBox();
            txtOutputId = new TextBox();
            txtOutputDiem = new TextBox();
            txtOutputSinhVien = new TextBox();
            txtOutputLanThi = new TextBox();
            cbbInputSinhVien = new ComboBox();
            cbbInputLanThi = new ComboBox();
            cbbFilterByLanThi = new ComboBox();
            cbbFilterBySinhVien = new ComboBox();
            dgvDiem = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            btnRefresh = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(391, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "Điểm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 100);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Điểm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 144);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Sinh Viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 190);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 4;
            label5.Text = "Lần Thi";
            // 
            // txtInputId
            // 
            txtInputId.Location = new Point(99, 67);
            txtInputId.Name = "txtInputId";
            txtInputId.Size = new Size(125, 27);
            txtInputId.TabIndex = 5;
            // 
            // txtInputDiem
            // 
            txtInputDiem.Location = new Point(99, 107);
            txtInputDiem.Name = "txtInputDiem";
            txtInputDiem.Size = new Size(125, 27);
            txtInputDiem.TabIndex = 6;
            // 
            // txtOutputId
            // 
            txtOutputId.Location = new Point(748, 58);
            txtOutputId.Name = "txtOutputId";
            txtOutputId.Size = new Size(125, 27);
            txtOutputId.TabIndex = 7;
            // 
            // txtOutputDiem
            // 
            txtOutputDiem.Location = new Point(748, 97);
            txtOutputDiem.Name = "txtOutputDiem";
            txtOutputDiem.Size = new Size(125, 27);
            txtOutputDiem.TabIndex = 8;
            // 
            // txtOutputSinhVien
            // 
            txtOutputSinhVien.Location = new Point(748, 141);
            txtOutputSinhVien.Name = "txtOutputSinhVien";
            txtOutputSinhVien.Size = new Size(125, 27);
            txtOutputSinhVien.TabIndex = 9;
            // 
            // txtOutputLanThi
            // 
            txtOutputLanThi.Location = new Point(748, 190);
            txtOutputLanThi.Name = "txtOutputLanThi";
            txtOutputLanThi.Size = new Size(125, 27);
            txtOutputLanThi.TabIndex = 10;
            // 
            // cbbInputSinhVien
            // 
            cbbInputSinhVien.FormattingEnabled = true;
            cbbInputSinhVien.Location = new Point(99, 144);
            cbbInputSinhVien.Name = "cbbInputSinhVien";
            cbbInputSinhVien.Size = new Size(151, 28);
            cbbInputSinhVien.TabIndex = 11;
            // 
            // cbbInputLanThi
            // 
            cbbInputLanThi.FormattingEnabled = true;
            cbbInputLanThi.Location = new Point(99, 187);
            cbbInputLanThi.Name = "cbbInputLanThi";
            cbbInputLanThi.Size = new Size(151, 28);
            cbbInputLanThi.TabIndex = 12;
            // 
            // cbbFilterByLanThi
            // 
            cbbFilterByLanThi.FormattingEnabled = true;
            cbbFilterByLanThi.Location = new Point(505, 57);
            cbbFilterByLanThi.Name = "cbbFilterByLanThi";
            cbbFilterByLanThi.Size = new Size(151, 28);
            cbbFilterByLanThi.TabIndex = 13;
            // 
            // cbbFilterBySinhVien
            // 
            cbbFilterBySinhVien.FormattingEnabled = true;
            cbbFilterBySinhVien.Location = new Point(410, 102);
            cbbFilterBySinhVien.Name = "cbbFilterBySinhVien";
            cbbFilterBySinhVien.Size = new Size(151, 28);
            cbbFilterBySinhVien.TabIndex = 14;
            // 
            // dgvDiem
            // 
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location = new Point(12, 250);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.RowHeadersWidth = 51;
            dgvDiem.Size = new Size(881, 188);
            dgvDiem.TabIndex = 15;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(269, 157);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(269, 215);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(391, 215);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(505, 215);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 19;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(505, 171);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 20;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(696, 65);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 21;
            label6.Text = "ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(675, 107);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 22;
            label7.Text = "Điểm";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(661, 147);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 23;
            label8.Text = "Sinh Viên";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(675, 197);
            label9.Name = "label9";
            label9.Size = new Size(56, 20);
            label9.TabIndex = 24;
            label9.Text = "Lần Thi";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(379, 61);
            label10.Name = "label10";
            label10.Size = new Size(120, 20);
            label10.TabIndex = 25;
            label10.Text = "Lọc Theo Lần Thi";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(243, 110);
            label11.Name = "label11";
            label11.Size = new Size(161, 20);
            label11.TabIndex = 26;
            label11.Text = "Lọc Theo Lần Sinh Viên";
            // 
            // DiemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 450);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnRefresh);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvDiem);
            Controls.Add(cbbFilterBySinhVien);
            Controls.Add(cbbFilterByLanThi);
            Controls.Add(cbbInputLanThi);
            Controls.Add(cbbInputSinhVien);
            Controls.Add(txtOutputLanThi);
            Controls.Add(txtOutputSinhVien);
            Controls.Add(txtOutputDiem);
            Controls.Add(txtOutputId);
            Controls.Add(txtInputDiem);
            Controls.Add(txtInputId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DiemForm";
            Text = "DiemForm";
            Load += DiemForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtInputId;
        private TextBox txtInputDiem;
        private TextBox txtOutputId;
        private TextBox txtOutputDiem;
        private TextBox txtOutputSinhVien;
        private TextBox txtOutputLanThi;
        private ComboBox cbbInputSinhVien;
        private ComboBox cbbInputLanThi;
        private ComboBox cbbFilterByLanThi;
        private ComboBox cbbFilterBySinhVien;
        private DataGridView dgvDiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private Button btnRefresh;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}