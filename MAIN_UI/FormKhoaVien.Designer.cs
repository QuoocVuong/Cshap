// FormKhoaVien.Designer.cs - Code Design (Form của bạn)
namespace QLDKhoa_CNTT.GUI
{
    partial class FormKhoaVien
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
            this.dgvKhoaVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKhoaVien = new System.Windows.Forms.TextBox();
            this.txtTenKhoaVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaVien)).BeginInit();
            this.SuspendLayout();
            //
            // dgvKhoaVien
            //
            this.dgvKhoaVien.AllowUserToAddRows = false;
            this.dgvKhoaVien.AllowUserToDeleteRows = false;
            this.dgvKhoaVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoaVien.Location = new System.Drawing.Point(12, 12);
            this.dgvKhoaVien.Name = "dgvKhoaVien";
            this.dgvKhoaVien.ReadOnly = true;
            this.dgvKhoaVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoaVien.Size = new System.Drawing.Size(504, 237);
            this.dgvKhoaVien.TabIndex = 0;
            //this.dgvKhoaVien.CellClick += new System.EventHandler(this.dgvKhoaVien_CellClick);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Khoa Viên";
            //
            // txtMaKhoaVien
            //
            this.txtMaKhoaVien.Location = new System.Drawing.Point(91, 264);
            this.txtMaKhoaVien.Name = "txtMaKhoaVien";
            this.txtMaKhoaVien.Size = new System.Drawing.Size(225, 20);
            this.txtMaKhoaVien.TabIndex = 2;
            //
            // txtTenKhoaVien
            //
            this.txtTenKhoaVien.Location = new System.Drawing.Point(91, 290);
            this.txtTenKhoaVien.Name = "txtTenKhoaVien";
            this.txtTenKhoaVien.Size = new System.Drawing.Size(225, 20);
            this.txtTenKhoaVien.TabIndex = 4;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Khoa Viên";
            //
            // btnThem
            //
            this.btnThem.Location = new System.Drawing.Point(341, 262);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnSua
            //
            this.btnSua.Location = new System.Drawing.Point(422, 262);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            //
            // btnXoa
            //
            this.btnXoa.Location = new System.Drawing.Point(341, 290);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // FormKhoaVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 322);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenKhoaVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaKhoaVien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvKhoaVien);
            this.Name = "FormKhoaVien";
            this.Text = "Quản lý Khoa Viện";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhoaVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaKhoaVien;
        private System.Windows.Forms.TextBox txtTenKhoaVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
    }
}