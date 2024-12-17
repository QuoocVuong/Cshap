namespace MAIN_UI
{
    partial class HinhThucForm
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
            txtIdHocKy = new TextBox();
            txtTenHinhThuc = new TextBox();
            cbbHocKy = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dgvHinhThuc = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHinhThuc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 54);
            label1.TabIndex = 0;
            label1.Text = "Hinh Thuc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 119);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 178);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 2;
            label3.Text = "Ten Hinh Thuc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 238);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 3;
            label4.Text = "Hoc Ky";
            // 
            // txtIdHocKy
            // 
            txtIdHocKy.Location = new Point(155, 112);
            txtIdHocKy.Name = "txtIdHocKy";
            txtIdHocKy.Size = new Size(237, 27);
            txtIdHocKy.TabIndex = 4;
            // 
            // txtTenHinhThuc
            // 
            txtTenHinhThuc.Location = new Point(155, 171);
            txtTenHinhThuc.Name = "txtTenHinhThuc";
            txtTenHinhThuc.Size = new Size(237, 27);
            txtTenHinhThuc.TabIndex = 5;
            // 
            // cbbHocKy
            // 
            cbbHocKy.FormattingEnabled = true;
            cbbHocKy.Location = new Point(153, 230);
            cbbHocKy.Name = "cbbHocKy";
            cbbHocKy.Size = new Size(239, 28);
            cbbHocKy.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(52, 309);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 45);
            btnThem.TabIndex = 7;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(213, 309);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 45);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sua";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(52, 393);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 45);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += button3_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(213, 393);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 45);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // dgvHinhThuc
            // 
            dgvHinhThuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHinhThuc.Location = new Point(438, 83);
            dgvHinhThuc.Name = "dgvHinhThuc";
            dgvHinhThuc.RowHeadersWidth = 51;
            dgvHinhThuc.Size = new Size(452, 335);
            dgvHinhThuc.TabIndex = 11;
            // 
            // HinhThucForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 450);
            Controls.Add(dgvHinhThuc);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cbbHocKy);
            Controls.Add(txtTenHinhThuc);
            Controls.Add(txtIdHocKy);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HinhThucForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HinhThucForm";
            ((System.ComponentModel.ISupportInitialize)dgvHinhThuc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtIdHocKy;
        private TextBox txtTenHinhThuc;
        private ComboBox cbbHocKy;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private DataGridView dgvHinhThuc;
    }
}