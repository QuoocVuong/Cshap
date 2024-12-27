namespace MAIN_UI
{
    partial class HocKyForm
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
            txtidhocky = new TextBox();
            txtTenHocKy = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            cbbNganhHoc = new ComboBox();
            dgvHocKy = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(299, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 46);
            label1.TabIndex = 0;
            label1.Text = "Hoc Ky";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 152);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 2;
            label3.Text = "Ten Hoc Ky";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 223);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Nam Hoc";
            // 
            // txtidhocky
            // 
            txtidhocky.Location = new Point(134, 73);
            txtidhocky.Name = "txtidhocky";
            txtidhocky.Size = new Size(239, 27);
            txtidhocky.TabIndex = 4;
            // 
            // txtTenHocKy
            // 
            txtTenHocKy.Location = new Point(134, 152);
            txtTenHocKy.Name = "txtTenHocKy";
            txtTenHocKy.Size = new Size(239, 27);
            txtTenHocKy.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(49, 325);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 45);
            btnThem.TabIndex = 7;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(185, 328);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 45);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sua";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(49, 393);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 45);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(185, 393);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 45);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // cbbNganhHoc
            // 
            cbbNganhHoc.FormattingEnabled = true;
            cbbNganhHoc.Location = new Point(134, 215);
            cbbNganhHoc.Name = "cbbNganhHoc";
            cbbNganhHoc.Size = new Size(239, 28);
            cbbNganhHoc.TabIndex = 11;
            // 
            // dgvHocKy
            // 
            dgvHocKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocKy.Location = new Point(402, 73);
            dgvHocKy.Name = "dgvHocKy";
            dgvHocKy.RowHeadersWidth = 51;
            dgvHocKy.Size = new Size(376, 365);
            dgvHocKy.TabIndex = 12;
            dgvHocKy.SelectionChanged += dgvHocKy_SelectionChanged;
            // 
            // HocKyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(dgvHocKy);
            Controls.Add(cbbNganhHoc);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTenHocKy);
            Controls.Add(txtidhocky);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HocKyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HocKyForm";
            FormClosing += HocKyForm_FormClosing;
            Load += HocKyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtidhocky;
        private TextBox txtTenHocKy;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private ComboBox cbbNganhHoc;
        private DataGridView dgvHocKy;
    }
}