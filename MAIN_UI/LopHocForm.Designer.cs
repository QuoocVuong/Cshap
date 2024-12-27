namespace MAIN_UI
{
    partial class LopHocForm
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
            txtIdLop = new TextBox();
            txtTenLop = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dgvLopHoc = new DataGridView();
            cbbLocNganhHoc = new ComboBox();
            label5 = new Label();
            txtTenNganhHoc = new TextBox();
            btnrefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(350, 48);
            label1.Name = "label1";
            label1.Size = new Size(133, 41);
            label1.TabIndex = 0;
            label1.Text = "Lop Hoc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 157);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 211);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 2;
            label3.Text = "Ten Lop";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 265);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 3;
            label4.Text = "Nganh Hoc";
            // 
            // txtIdLop
            // 
            txtIdLop.Location = new Point(166, 147);
            txtIdLop.Margin = new Padding(3, 4, 3, 4);
            txtIdLop.Name = "txtIdLop";
            txtIdLop.Size = new Size(137, 27);
            txtIdLop.TabIndex = 4;
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(165, 204);
            txtTenLop.Margin = new Padding(3, 4, 3, 4);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(138, 27);
            txtTenLop.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(120, 393);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(86, 31);
            btnThem.TabIndex = 7;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(249, 393);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(86, 31);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sua";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(120, 493);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(86, 31);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(250, 493);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(86, 31);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Location = new Point(438, 147);
            dgvLopHoc.Margin = new Padding(3, 4, 3, 4);
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.RowHeadersWidth = 51;
            dgvLopHoc.Size = new Size(463, 403);
            dgvLopHoc.TabIndex = 11;
            dgvLopHoc.SelectionChanged += dgvLopHoc_SelectionChanged;
            // 
            // cbbLocNganhHoc
            // 
            cbbLocNganhHoc.FormattingEnabled = true;
            cbbLocNganhHoc.Location = new Point(165, 317);
            cbbLocNganhHoc.Margin = new Padding(3, 4, 3, 4);
            cbbLocNganhHoc.Name = "cbbLocNganhHoc";
            cbbLocNganhHoc.Size = new Size(138, 28);
            cbbLocNganhHoc.TabIndex = 13;
            cbbLocNganhHoc.SelectedIndexChanged += cbbLocNganhHoc_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 328);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 14;
            label5.Text = "Loc Theo Nganh Hoc";
            // 
            // txtTenNganhHoc
            // 
            txtTenNganhHoc.Location = new Point(165, 265);
            txtTenNganhHoc.Margin = new Padding(3, 4, 3, 4);
            txtTenNganhHoc.Name = "txtTenNganhHoc";
            txtTenNganhHoc.Size = new Size(138, 27);
            txtTenNganhHoc.TabIndex = 15;
            // 
            // btnrefresh
            // 
            btnrefresh.Location = new Point(327, 317);
            btnrefresh.Margin = new Padding(3, 4, 3, 4);
            btnrefresh.Name = "btnrefresh";
            btnrefresh.Size = new Size(86, 31);
            btnrefresh.TabIndex = 16;
            btnrefresh.Text = "Refresh";
            btnrefresh.UseVisualStyleBackColor = true;
            btnrefresh.Click += btnrefresh_Click;
            // 
            // LopHocForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnrefresh);
            Controls.Add(txtTenNganhHoc);
            Controls.Add(label5);
            Controls.Add(cbbLocNganhHoc);
            Controls.Add(dgvLopHoc);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTenLop);
            Controls.Add(txtIdLop);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LopHocForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LopHocForm";
            Load += LopHocForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtIdLop;
        private TextBox txtTenLop;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private DataGridView dgvLopHoc;
        private ComboBox cbbLocNganhHoc;
        private Label label5;
        private TextBox txtTenNganhHoc;
        private Button btnrefresh;
    }
}