namespace MAIN_UI
{
    partial class SinhVienForm
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
            btnThem = new Button();
            Sua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            txtId = new TextBox();
            txtMaSinhVien = new TextBox();
            dgvSinhVien = new DataGridView();
            cbbLocTheoLop = new ComboBox();
            btnRefresh = new Button();
            label6 = new Label();
            txtTenSinhVien = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            label7 = new Label();
            txtLop = new TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(286, 25);
            label1.Name = "label1";
            label1.Size = new Size(107, 30);
            label1.TabIndex = 0;
            label1.Text = "Sinh Vien";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 84);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 2;
            label3.Text = "Ma Sinh Vien ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "Ngay Sinh";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 4;
            label5.Text = "Loc Theo Lop";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(31, 333);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 5;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // Sua
            // 
            Sua.Location = new Point(268, 333);
            Sua.Name = "Sua";
            Sua.Size = new Size(75, 23);
            Sua.TabIndex = 6;
            Sua.Text = "Sua";
            Sua.UseVisualStyleBackColor = true;
            Sua.Click += Sua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(31, 403);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(268, 403);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 23);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(104, 76);
            txtId.Name = "txtId";
            txtId.Size = new Size(155, 23);
            txtId.TabIndex = 9;
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(104, 118);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(155, 23);
            txtMaSinhVien.TabIndex = 10;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(358, 76);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(431, 350);
            dgvSinhVien.TabIndex = 12;
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;
            // 
            // cbbLocTheoLop
            // 
            cbbLocTheoLop.FormattingEnabled = true;
            cbbLocTheoLop.Location = new Point(104, 261);
            cbbLocTheoLop.Name = "cbbLocTheoLop";
            cbbLocTheoLop.Size = new Size(155, 23);
            cbbLocTheoLop.TabIndex = 13;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(277, 260);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 169);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 15;
            label6.Text = "Ten Sinh Vien";
            // 
            // txtTenSinhVien
            // 
            txtTenSinhVien.Location = new Point(104, 161);
            txtTenSinhVien.Name = "txtTenSinhVien";
            txtTenSinhVien.Size = new Size(155, 23);
            txtTenSinhVien.TabIndex = 16;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(104, 195);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(223, 23);
            dtpNgaySinh.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 232);
            label7.Name = "label7";
            label7.Size = new Size(27, 15);
            label7.TabIndex = 18;
            label7.Text = "Lop";
            // 
            // txtLop
            // 
            txtLop.Location = new Point(102, 230);
            txtLop.Margin = new Padding(3, 2, 3, 2);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(158, 23);
            txtLop.TabIndex = 19;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // SinhVienForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtLop);
            Controls.Add(label7);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtTenSinhVien);
            Controls.Add(label6);
            Controls.Add(btnRefresh);
            Controls.Add(cbbLocTheoLop);
            Controls.Add(dgvSinhVien);
            Controls.Add(txtMaSinhVien);
            Controls.Add(txtId);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(Sua);
            Controls.Add(btnThem);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SinhVienForm";
            Text = "SinhVienForm";
            Load += SinhVienForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnThem;
        private Button Sua;
        private Button btnXoa;
        private Button btnThoat;
        private TextBox txtId;
        private TextBox txtMaSinhVien;
        private DataGridView dgvSinhVien;
        private ComboBox cbbLocTheoLop;
        private Button btnRefresh;
        private Label label6;
        private TextBox txtTenSinhVien;
        private DateTimePicker dtpNgaySinh;
        private Label label7;
        private TextBox txtLop;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}