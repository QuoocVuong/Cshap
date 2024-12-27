namespace MAIN_UI
{
    partial class MonHocForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dgvMonHoc = new DataGridView();
            label12 = new Label();
            txtOutputMaMonHoc = new TextBox();
            txtOutputTenMonHoc = new TextBox();
            txtOutputSoGio = new TextBox();
            txtOutputHocKy = new TextBox();
            txtOutputId = new TextBox();
            txtInputId = new TextBox();
            txtInputMaMonHoc = new TextBox();
            txtInputTenMonHoc = new TextBox();
            txtInputSoGio = new TextBox();
            cbbInputHocKy = new ComboBox();
            cbbFilterByHocKy = new ComboBox();
            txtSearch = new TextBox();
            btnTimKiem = new Button();
            btnRefresh = new Button();
            btnthem = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            label14 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            btnSua = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(465, 11);
            label1.Name = "label1";
            label1.Size = new Size(138, 37);
            label1.TabIndex = 0;
            label1.Text = "Môn Học";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(912, 115);
            label2.Name = "label2";
            label2.Size = new Size(28, 23);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(842, 165);
            label3.Name = "label3";
            label3.Size = new Size(117, 23);
            label3.TabIndex = 2;
            label3.Text = "Mã Môn Học ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(842, 225);
            label4.Name = "label4";
            label4.Size = new Size(114, 23);
            label4.TabIndex = 3;
            label4.Text = "Tên Môn Học";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.Location = new Point(893, 283);
            label5.Name = "label5";
            label5.Size = new Size(63, 23);
            label5.TabIndex = 4;
            label5.Text = "Sô Giờ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.Location = new Point(891, 333);
            label6.Name = "label6";
            label6.Size = new Size(65, 23);
            label6.TabIndex = 5;
            label6.Text = "Học Kỳ";
            // 
            // dgvMonHoc
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMonHoc.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMonHoc.Location = new Point(41, 388);
            dgvMonHoc.Margin = new Padding(3, 4, 3, 4);
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.RowHeadersWidth = 51;
            dgvMonHoc.Size = new Size(1055, 276);
            dgvMonHoc.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(448, 176);
            label12.Name = "label12";
            label12.Size = new Size(72, 20);
            label12.TabIndex = 12;
            label12.Text = "Tìm Kiếm";
            // 
            // txtOutputMaMonHoc
            // 
            txtOutputMaMonHoc.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txtOutputMaMonHoc.Location = new Point(965, 159);
            txtOutputMaMonHoc.Margin = new Padding(3, 4, 3, 4);
            txtOutputMaMonHoc.Name = "txtOutputMaMonHoc";
            txtOutputMaMonHoc.Size = new Size(143, 29);
            txtOutputMaMonHoc.TabIndex = 14;
            // 
            // txtOutputTenMonHoc
            // 
            txtOutputTenMonHoc.Location = new Point(965, 221);
            txtOutputTenMonHoc.Margin = new Padding(3, 4, 3, 4);
            txtOutputTenMonHoc.Name = "txtOutputTenMonHoc";
            txtOutputTenMonHoc.Size = new Size(143, 27);
            txtOutputTenMonHoc.TabIndex = 15;
            // 
            // txtOutputSoGio
            // 
            txtOutputSoGio.Location = new Point(965, 279);
            txtOutputSoGio.Margin = new Padding(3, 4, 3, 4);
            txtOutputSoGio.Name = "txtOutputSoGio";
            txtOutputSoGio.Size = new Size(143, 27);
            txtOutputSoGio.TabIndex = 16;
            // 
            // txtOutputHocKy
            // 
            txtOutputHocKy.Location = new Point(963, 329);
            txtOutputHocKy.Margin = new Padding(3, 4, 3, 4);
            txtOutputHocKy.Name = "txtOutputHocKy";
            txtOutputHocKy.Size = new Size(145, 27);
            txtOutputHocKy.TabIndex = 17;
            // 
            // txtOutputId
            // 
            txtOutputId.Location = new Point(965, 105);
            txtOutputId.Margin = new Padding(3, 4, 3, 4);
            txtOutputId.Name = "txtOutputId";
            txtOutputId.Size = new Size(143, 27);
            txtOutputId.TabIndex = 18;
            // 
            // txtInputId
            // 
            txtInputId.Location = new Point(134, 109);
            txtInputId.Margin = new Padding(3, 4, 3, 4);
            txtInputId.Name = "txtInputId";
            txtInputId.Size = new Size(132, 27);
            txtInputId.TabIndex = 19;
            // 
            // txtInputMaMonHoc
            // 
            txtInputMaMonHoc.Location = new Point(134, 163);
            txtInputMaMonHoc.Margin = new Padding(3, 4, 3, 4);
            txtInputMaMonHoc.Name = "txtInputMaMonHoc";
            txtInputMaMonHoc.Size = new Size(132, 27);
            txtInputMaMonHoc.TabIndex = 20;
            // 
            // txtInputTenMonHoc
            // 
            txtInputTenMonHoc.Location = new Point(131, 226);
            txtInputTenMonHoc.Margin = new Padding(3, 4, 3, 4);
            txtInputTenMonHoc.Name = "txtInputTenMonHoc";
            txtInputTenMonHoc.Size = new Size(132, 27);
            txtInputTenMonHoc.TabIndex = 21;
            // 
            // txtInputSoGio
            // 
            txtInputSoGio.Location = new Point(131, 279);
            txtInputSoGio.Margin = new Padding(3, 4, 3, 4);
            txtInputSoGio.Name = "txtInputSoGio";
            txtInputSoGio.Size = new Size(132, 27);
            txtInputSoGio.TabIndex = 22;
            // 
            // cbbInputHocKy
            // 
            cbbInputHocKy.FormattingEnabled = true;
            cbbInputHocKy.Location = new Point(134, 347);
            cbbInputHocKy.Margin = new Padding(3, 4, 3, 4);
            cbbInputHocKy.Name = "cbbInputHocKy";
            cbbInputHocKy.Size = new Size(132, 28);
            cbbInputHocKy.TabIndex = 23;
            // 
            // cbbFilterByHocKy
            // 
            cbbFilterByHocKy.FormattingEnabled = true;
            cbbFilterByHocKy.Location = new Point(448, 225);
            cbbFilterByHocKy.Margin = new Padding(3, 4, 3, 4);
            cbbFilterByHocKy.Name = "cbbFilterByHocKy";
            cbbFilterByHocKy.Size = new Size(138, 28);
            cbbFilterByHocKy.TabIndex = 24;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(526, 168);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(167, 27);
            txtSearch.TabIndex = 25;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 9F);
            btnTimKiem.Location = new Point(712, 155);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(86, 41);
            btnTimKiem.TabIndex = 26;
            btnTimKiem.Text = "Search";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(632, 209);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(86, 44);
            btnRefresh.TabIndex = 27;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnthem
            // 
            btnthem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnthem.Location = new Point(299, 318);
            btnthem.Margin = new Padding(3, 4, 3, 4);
            btnthem.Name = "btnthem";
            btnthem.Size = new Size(117, 62);
            btnthem.TabIndex = 28;
            btnthem.Text = "Them";
            btnthem.UseVisualStyleBackColor = true;
            btnthem.Click += btnthem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXoa.Location = new Point(579, 318);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 61);
            btnXoa.TabIndex = 29;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThoat.Location = new Point(725, 318);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(113, 59);
            btnThoat.TabIndex = 30;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label14.Location = new Point(97, 115);
            label14.Name = "label14";
            label14.Size = new Size(28, 23);
            label14.TabIndex = 31;
            label14.Text = "ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label7.Location = new Point(12, 168);
            label7.Name = "label7";
            label7.Size = new Size(117, 23);
            label7.TabIndex = 32;
            label7.Text = "Mã Môn Học ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label8.Location = new Point(11, 230);
            label8.Name = "label8";
            label8.Size = new Size(114, 23);
            label8.TabIndex = 33;
            label8.Text = "Tên Môn Học";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label9.Location = new Point(62, 283);
            label9.Name = "label9";
            label9.Size = new Size(63, 23);
            label9.TabIndex = 34;
            label9.Text = "Sô Giờ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label10.Location = new Point(60, 352);
            label10.Name = "label10";
            label10.Size = new Size(65, 23);
            label10.TabIndex = 35;
            label10.Text = "Học Kỳ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(323, 233);
            label11.Name = "label11";
            label11.Size = new Size(119, 20);
            label11.TabIndex = 36;
            label11.Text = "Lọc Theo Học Kỳ";
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSua.Location = new Point(435, 318);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(117, 59);
            btnSua.TabIndex = 37;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // MonHocForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 677);
            Controls.Add(btnSua);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label14);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnthem);
            Controls.Add(btnRefresh);
            Controls.Add(btnTimKiem);
            Controls.Add(txtSearch);
            Controls.Add(cbbFilterByHocKy);
            Controls.Add(cbbInputHocKy);
            Controls.Add(txtInputSoGio);
            Controls.Add(txtInputTenMonHoc);
            Controls.Add(txtInputMaMonHoc);
            Controls.Add(txtInputId);
            Controls.Add(txtOutputId);
            Controls.Add(txtOutputHocKy);
            Controls.Add(txtOutputSoGio);
            Controls.Add(txtOutputTenMonHoc);
            Controls.Add(txtOutputMaMonHoc);
            Controls.Add(label12);
            Controls.Add(dgvMonHoc);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MonHocForm";
            Text = "MonHocForm";
            Load += MonHocForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dgvMonHoc;
        private Label label12;
        private TextBox txtOutputMaMonHoc;
        private TextBox txtOutputTenMonHoc;
        private TextBox txtOutputSoGio;
        private TextBox txtOutputHocKy;
        private TextBox txtOutputId;
        private TextBox txtInputId;
        private TextBox txtInputMaMonHoc;
        private TextBox txtInputTenMonHoc;
        private TextBox txtInputSoGio;
        private ComboBox cbbInputHocKy;
        private ComboBox cbbFilterByHocKy;
        private TextBox txtSearch;
        private Button btnTimKiem;
        private Button btnRefresh;
        private Button btnthem;
        private Button btnXoa;
        private Button btnThoat;
        private Label label14;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button btnSua;
    }
}