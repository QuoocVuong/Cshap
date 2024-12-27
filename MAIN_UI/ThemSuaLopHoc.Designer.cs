namespace MAIN_UI
{
    partial class ThemSuaLopHoc
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
            txtId = new TextBox();
            txtTenLop = new TextBox();
            btnLuu = new Button();
            btnThoat = new Button();
            cbbNganhHoc = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(374, 35);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(166, 149);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 223);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 2;
            label3.Text = "Ten Lop";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 319);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 3;
            label4.Text = "Nganh Hoc";
            // 
            // txtId
            // 
            txtId.Location = new Point(295, 139);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.Size = new Size(205, 27);
            txtId.TabIndex = 4;
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(299, 212);
            txtTenLop.Margin = new Padding(3, 4, 3, 4);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(201, 27);
            txtTenLop.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(158, 467);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(86, 31);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Luu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(582, 467);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(86, 31);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // cbbNganhHoc
            // 
            cbbNganhHoc.FormattingEnabled = true;
            cbbNganhHoc.Location = new Point(304, 308);
            cbbNganhHoc.Margin = new Padding(3, 4, 3, 4);
            cbbNganhHoc.Name = "cbbNganhHoc";
            cbbNganhHoc.Size = new Size(196, 28);
            cbbNganhHoc.TabIndex = 8;
            cbbNganhHoc.SelectedIndexChanged += cbbNganhHoc_SelectedIndexChanged;
            // 
            // ThemSuaLopHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(cbbNganhHoc);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtTenLop);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ThemSuaLopHoc";
            Text = "ThemSuaLopHoc";
            Load += ThemSuaLopHoc_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtId;
        private TextBox txtTenLop;
        private Button btnLuu;
        private Button btnThoat;
        private ComboBox cbbNganhHoc;
    }
}