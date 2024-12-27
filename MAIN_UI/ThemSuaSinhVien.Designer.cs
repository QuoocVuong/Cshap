namespace MAIN_UI
{
    partial class ThemSuaSinhVien
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
            btnLuu = new Button();
            btnThoat = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtIdSinhVien = new TextBox();
            txtMaSinhVien = new TextBox();
            txtTenSinhVien = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cbbLop = new ComboBox();
            SuspendLayout();
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(183, 339);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 0;
            btnLuu.Text = "Luu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(463, 346);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 23);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 28);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 86);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 3;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 130);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 4;
            label3.Text = "Ma Sinh Vien";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 182);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 5;
            label4.Text = "Ten Sinh Vien";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(140, 225);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 6;
            label5.Text = "Ngay Sinh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(174, 273);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 7;
            label6.Text = "Lop";
            // 
            // txtIdSinhVien
            // 
            txtIdSinhVien.Location = new Point(220, 78);
            txtIdSinhVien.Name = "txtIdSinhVien";
            txtIdSinhVien.Size = new Size(215, 23);
            txtIdSinhVien.TabIndex = 8;
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(220, 122);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(215, 23);
            txtMaSinhVien.TabIndex = 9;
            // 
            // txtTenSinhVien
            // 
            txtTenSinhVien.Location = new Point(220, 174);
            txtTenSinhVien.Name = "txtTenSinhVien";
            txtTenSinhVien.Size = new Size(215, 23);
            txtTenSinhVien.TabIndex = 10;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(220, 217);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(215, 23);
            dtpNgaySinh.TabIndex = 11;
            // 
            // cbbLop
            // 
            cbbLop.FormattingEnabled = true;
            cbbLop.Location = new Point(220, 265);
            cbbLop.Name = "cbbLop";
            cbbLop.Size = new Size(215, 23);
            cbbLop.TabIndex = 12;
            // 
            // ThemSuaSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbbLop);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtTenSinhVien);
            Controls.Add(txtMaSinhVien);
            Controls.Add(txtIdSinhVien);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Name = "ThemSuaSinhVien";
            Text = "ThemSuaSinhVien";
            Load += ThemSuaSinhVien_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLuu;
        private Button btnThoat;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtIdSinhVien;
        private TextBox txtMaSinhVien;
        private TextBox txtTenSinhVien;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cbbLop;
    }
}