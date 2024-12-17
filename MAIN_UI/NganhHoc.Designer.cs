namespace MAIN_UI
{
    partial class NganhHoc
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
            txtnganhhoc = new TextBox();
            btnthem = new Button();
            btnsua = new Button();
            btnxoa = new Button();
            btnthoat = new Button();
            cbbkhoa = new ComboBox();
            dgvnganhhoclist = new DataGridView();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtIdNganhHoc = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvnganhhoclist).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(283, 12);
            label1.Name = "label1";
            label1.Size = new Size(352, 81);
            label1.TabIndex = 0;
            label1.Text = "Nganh Hoc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(102, 163);
            label2.Name = "label2";
            label2.Size = new Size(137, 32);
            label2.TabIndex = 1;
            label2.Text = "Nganh Hoc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(162, 231);
            label3.Name = "label3";
            label3.Size = new Size(70, 32);
            label3.TabIndex = 2;
            label3.Text = "Khoa";
            // 
            // txtnganhhoc
            // 
            txtnganhhoc.Location = new Point(283, 163);
            txtnganhhoc.Margin = new Padding(3, 4, 3, 4);
            txtnganhhoc.Name = "txtnganhhoc";
            txtnganhhoc.Size = new Size(303, 27);
            txtnganhhoc.TabIndex = 3;
            // 
            // btnthem
            // 
            btnthem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnthem.Location = new Point(626, 400);
            btnthem.Margin = new Padding(3, 4, 3, 4);
            btnthem.Name = "btnthem";
            btnthem.Size = new Size(86, 51);
            btnthem.TabIndex = 4;
            btnthem.Text = "Them";
            btnthem.UseVisualStyleBackColor = true;
            btnthem.Click += btnthem_Click;
            // 
            // btnsua
            // 
            btnsua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnsua.Location = new Point(778, 400);
            btnsua.Margin = new Padding(3, 4, 3, 4);
            btnsua.Name = "btnsua";
            btnsua.Size = new Size(86, 51);
            btnsua.TabIndex = 5;
            btnsua.Text = "Sua";
            btnsua.UseVisualStyleBackColor = true;
            btnsua.Click += btnsua_Click;
            // 
            // btnxoa
            // 
            btnxoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnxoa.Location = new Point(626, 504);
            btnxoa.Margin = new Padding(3, 4, 3, 4);
            btnxoa.Name = "btnxoa";
            btnxoa.Size = new Size(86, 51);
            btnxoa.TabIndex = 6;
            btnxoa.Text = "Xoa";
            btnxoa.UseVisualStyleBackColor = true;
            btnxoa.Click += btnxoa_Click;
            // 
            // btnthoat
            // 
            btnthoat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnthoat.Location = new Point(778, 504);
            btnthoat.Margin = new Padding(3, 4, 3, 4);
            btnthoat.Name = "btnthoat";
            btnthoat.Size = new Size(86, 51);
            btnthoat.TabIndex = 7;
            btnthoat.Text = "Thoat";
            btnthoat.UseVisualStyleBackColor = true;
            btnthoat.Click += btnthoat_Click;
            // 
            // cbbkhoa
            // 
            cbbkhoa.FormattingEnabled = true;
            cbbkhoa.Location = new Point(283, 233);
            cbbkhoa.Margin = new Padding(3, 4, 3, 4);
            cbbkhoa.Name = "cbbkhoa";
            cbbkhoa.Size = new Size(303, 28);
            cbbkhoa.TabIndex = 8;
            // 
            // dgvnganhhoclist
            // 
            dgvnganhhoclist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvnganhhoclist.Location = new Point(102, 360);
            dgvnganhhoclist.Margin = new Padding(3, 4, 3, 4);
            dgvnganhhoclist.Name = "dgvnganhhoclist";
            dgvnganhhoclist.RowHeadersWidth = 51;
            dgvnganhhoclist.Size = new Size(486, 225);
            dgvnganhhoclist.TabIndex = 9;
            dgvnganhhoclist.SelectionChanged += dgvnganhhoclist_SelectionChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnTimKiem.Location = new Point(626, 281);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(86, 51);
            btnTimKiem.TabIndex = 10;
            btnTimKiem.Text = "Search";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(283, 291);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(303, 27);
            txtTimKiem.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.Location = new Point(137, 293);
            label4.Name = "label4";
            label4.Size = new Size(98, 28);
            label4.TabIndex = 12;
            label4.Text = "Tim Kiem";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.Location = new Point(98, 120);
            label5.Name = "label5";
            label5.Size = new Size(141, 28);
            label5.TabIndex = 13;
            label5.Text = "ID Nganh Hoc";
            // 
            // txtIdNganhHoc
            // 
            txtIdNganhHoc.Location = new Point(288, 117);
            txtIdNganhHoc.Margin = new Padding(3, 4, 3, 4);
            txtIdNganhHoc.Name = "txtIdNganhHoc";
            txtIdNganhHoc.Size = new Size(299, 27);
            txtIdNganhHoc.TabIndex = 14;
            // 
            // NganhHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(txtIdNganhHoc);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvnganhhoclist);
            Controls.Add(cbbkhoa);
            Controls.Add(btnthoat);
            Controls.Add(btnxoa);
            Controls.Add(btnsua);
            Controls.Add(btnthem);
            Controls.Add(txtnganhhoc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NganhHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NganhHoc";
            FormClosing += NganhHoc_FormClosing;
            Load += NganhHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvnganhhoclist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtnganhhoc;
        private Button btnthem;
        private Button btnsua;
        private Button btnxoa;
        private Button btnthoat;
        private ComboBox cbbkhoa;
        private DataGridView dgvnganhhoclist;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label label4;
        private Label label5;
        private TextBox txtIdNganhHoc;
    }
}