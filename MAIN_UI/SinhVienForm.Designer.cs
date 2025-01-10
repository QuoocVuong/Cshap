using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
            label6 = new Label();
            label7 = new Label();
            txtId = new TextBox();
            txtMaSinhVien = new TextBox();
            txtTenSinhVien = new TextBox();
            txtLop = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dgvSinhVien = new DataGridView();
            sqlCommand1 = new SqlCommand();
            cbbLocTheoLop = new ComboBox();
            label5 = new Label();
            btnRefresh = new Button();
            ((ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(245, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Sinh Viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 101);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 152);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 2;
            label3.Text = "Mã Sinh Viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 253);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày Sinh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 203);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 15;
            label6.Text = "Tên Sinh Viên";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 304);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 18;
            label7.Text = "Lớp";
            // 
            // txtId
            // 
            txtId.Location = new Point(147, 97);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(228, 27);
            txtId.TabIndex = 9;
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(147, 148);
            txtMaSinhVien.Margin = new Padding(3, 4, 3, 4);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(228, 27);
            txtMaSinhVien.TabIndex = 10;
            // 
            // txtTenSinhVien
            // 
            txtTenSinhVien.Location = new Point(147, 199);
            txtTenSinhVien.Margin = new Padding(3, 4, 3, 4);
            txtTenSinhVien.Name = "txtTenSinhVien";
            txtTenSinhVien.Size = new Size(228, 27);
            txtTenSinhVien.TabIndex = 16;
            // 
            // txtLop
            // 
            txtLop.Location = new Point(147, 300);
            txtLop.Margin = new Padding(3, 4, 3, 4);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(228, 27);
            txtLop.TabIndex = 19;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(147, 248);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(228, 27);
            dtpNgaySinh.TabIndex = 17;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(32, 401);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(175, 401);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(114, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += Sua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(32, 471);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(175, 471);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(114, 40);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(409, 97);
            dgvSinhVien.Margin = new Padding(3, 4, 3, 4);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.RowTemplate.Height = 25;
            dgvSinhVien.Size = new Size(473, 431);
            dgvSinhVien.TabIndex = 12;
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // cbbLocTheoLop
            // 
            cbbLocTheoLop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbbLocTheoLop.FormattingEnabled = true;
            cbbLocTheoLop.Location = new Point(545, 55);
            cbbLocTheoLop.Margin = new Padding(3, 4, 3, 4);
            cbbLocTheoLop.Name = "cbbLocTheoLop";
            cbbLocTheoLop.Size = new Size(228, 28);
            cbbLocTheoLop.TabIndex = 13;
            cbbLocTheoLop.SelectedIndexChanged += CbbLocTheoLop_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(441, 59);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 4;
            label5.Text = "Lọc Theo Lớp";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(798, 53);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(86, 31);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // SinhVienForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 560);
            Controls.Add(btnRefresh);
            Controls.Add(cbbLocTheoLop);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtId);
            Controls.Add(txtMaSinhVien);
            Controls.Add(txtTenSinhVien);
            Controls.Add(txtLop);
            Controls.Add(dtpNgaySinh);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SinhVienForm";
            Text = "SinhVienForm";
            Load += SinhVienForm_Load;
            ((ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtMaSinhVien;
        private System.Windows.Forms.TextBox txtTenSinhVien;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.ComboBox cbbLocTheoLop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
    }
}