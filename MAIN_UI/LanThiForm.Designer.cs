namespace MAIN_UI
{
    partial class LanThiForm
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
            txtInputLanThi = new TextBox();
            txtOutputId = new TextBox();
            txtOutputLanThi = new TextBox();
            dgvLanThi = new DataGridView();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            cbbInputMonHoc = new ComboBox();
            cbbFilterByMonHoc = new ComboBox();
            label10 = new Label();
            txtOutputMonHoc = new TextBox();
            btnThem = new Button();
            btnRefresh = new Button();
            dtpInputNgayThi = new DateTimePicker();
            dtpOutputNgayThi = new DateTimePicker();
            label11 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLanThi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(392, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "Lần Thi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 57);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 99);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 2;
            label3.Text = "Lần Thi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 139);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày Thi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 183);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 4;
            label5.Text = "Môn Học";
            // 
            // txtInputId
            // 
            txtInputId.Location = new Point(108, 56);
            txtInputId.Name = "txtInputId";
            txtInputId.Size = new Size(125, 27);
            txtInputId.TabIndex = 9;
            // 
            // txtInputLanThi
            // 
            txtInputLanThi.Location = new Point(111, 104);
            txtInputLanThi.Name = "txtInputLanThi";
            txtInputLanThi.Size = new Size(125, 27);
            txtInputLanThi.TabIndex = 10;
            // 
            // txtOutputId
            // 
            txtOutputId.Location = new Point(775, 54);
            txtOutputId.Name = "txtOutputId";
            txtOutputId.Size = new Size(125, 27);
            txtOutputId.TabIndex = 12;
            // 
            // txtOutputLanThi
            // 
            txtOutputLanThi.Location = new Point(775, 99);
            txtOutputLanThi.Name = "txtOutputLanThi";
            txtOutputLanThi.Size = new Size(125, 27);
            txtOutputLanThi.TabIndex = 13;
            // 
            // dgvLanThi
            // 
            dgvLanThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLanThi.Location = new Point(12, 261);
            dgvLanThi.Name = "dgvLanThi";
            dgvLanThi.RowHeadersWidth = 51;
            dgvLanThi.Size = new Size(902, 188);
            dgvLanThi.TabIndex = 15;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(371, 225);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(481, 225);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(581, 225);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 18;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // cbbInputMonHoc
            // 
            cbbInputMonHoc.FormattingEnabled = true;
            cbbInputMonHoc.Location = new Point(102, 183);
            cbbInputMonHoc.Name = "cbbInputMonHoc";
            cbbInputMonHoc.Size = new Size(151, 28);
            cbbInputMonHoc.TabIndex = 19;
            // 
            // cbbFilterByMonHoc
            // 
            cbbFilterByMonHoc.FormattingEnabled = true;
            cbbFilterByMonHoc.Location = new Point(374, 79);
            cbbFilterByMonHoc.Name = "cbbFilterByMonHoc";
            cbbFilterByMonHoc.Size = new Size(151, 28);
            cbbFilterByMonHoc.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(239, 82);
            label10.Name = "label10";
            label10.Size = new Size(134, 20);
            label10.TabIndex = 21;
            label10.Text = "Lọc Theo Môn Học";
            // 
            // txtOutputMonHoc
            // 
            txtOutputMonHoc.Location = new Point(782, 201);
            txtOutputMonHoc.Name = "txtOutputMonHoc";
            txtOutputMonHoc.Size = new Size(125, 27);
            txtOutputMonHoc.TabIndex = 22;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(253, 226);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 23;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(547, 82);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 24;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dtpInputNgayThi
            // 
            dtpInputNgayThi.Location = new Point(102, 148);
            dtpInputNgayThi.Name = "dtpInputNgayThi";
            dtpInputNgayThi.Size = new Size(250, 27);
            dtpInputNgayThi.TabIndex = 25;
            // 
            // dtpOutputNgayThi
            // 
            dtpOutputNgayThi.Location = new Point(650, 152);
            dtpOutputNgayThi.Name = "dtpOutputNgayThi";
            dtpOutputNgayThi.Size = new Size(250, 27);
            dtpOutputNgayThi.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(693, 204);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 27;
            label11.Text = "Môn Học";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(557, 157);
            label9.Name = "label9";
            label9.Size = new Size(68, 20);
            label9.TabIndex = 28;
            label9.Text = "Ngày Thi";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(693, 104);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 29;
            label8.Text = "Lần Thi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(725, 57);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 30;
            label7.Text = "ID";
            // 
            // LanThiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 450);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(dtpOutputNgayThi);
            Controls.Add(dtpInputNgayThi);
            Controls.Add(btnRefresh);
            Controls.Add(btnThem);
            Controls.Add(txtOutputMonHoc);
            Controls.Add(label10);
            Controls.Add(cbbFilterByMonHoc);
            Controls.Add(cbbInputMonHoc);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(dgvLanThi);
            Controls.Add(txtOutputLanThi);
            Controls.Add(txtOutputId);
            Controls.Add(txtInputLanThi);
            Controls.Add(txtInputId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LanThiForm";
            Text = "LanThiForm";
            Load += LanThiForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLanThi).EndInit();
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
        private TextBox txtInputLanThi;
        private TextBox txtOutputId;
        private TextBox txtOutputLanThi;
        private DataGridView dgvLanThi;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private ComboBox cbbInputMonHoc;
        private ComboBox cbbFilterByMonHoc;
        private Label label10;
        private TextBox txtOutputMonHoc;
        private Button btnThem;
        private Button btnRefresh;
        private DateTimePicker dtpInputNgayThi;
        private DateTimePicker dtpOutputNgayThi;
        private Label label11;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}