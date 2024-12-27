namespace MAIN_UI
{
    partial class ThemSuaXoaHocKy
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
            txtid = new TextBox();
            txtTenHocKy = new TextBox();
            cbbNamHoc = new ComboBox();
            btnLuu = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(369, 40);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 139);
            label2.Name = "label2";
            label2.Size = new Size(22, 20);
            label2.TabIndex = 1;
            label2.Text = "id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(194, 233);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Hoc Ky";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(194, 320);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Nam Hoc";
            // 
            // txtid
            // 
            txtid.Location = new Point(275, 128);
            txtid.Margin = new Padding(3, 4, 3, 4);
            txtid.Name = "txtid";
            txtid.Size = new Size(194, 27);
            txtid.TabIndex = 4;
            // 
            // txtTenHocKy
            // 
            txtTenHocKy.Location = new Point(275, 223);
            txtTenHocKy.Margin = new Padding(3, 4, 3, 4);
            txtTenHocKy.Name = "txtTenHocKy";
            txtTenHocKy.Size = new Size(194, 27);
            txtTenHocKy.TabIndex = 5;
            // 
            // cbbNamHoc
            // 
            cbbNamHoc.FormattingEnabled = true;
            cbbNamHoc.Location = new Point(271, 309);
            cbbNamHoc.Margin = new Padding(3, 4, 3, 4);
            cbbNamHoc.Name = "cbbNamHoc";
            cbbNamHoc.Size = new Size(198, 28);
            cbbNamHoc.TabIndex = 6;
            cbbNamHoc.SelectedIndexChanged += cbbNamHoc_SelectedIndexChanged;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(160, 439);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(86, 31);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Luu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(490, 441);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(86, 31);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // ThemSuaXoaHocKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(cbbNamHoc);
            Controls.Add(txtTenHocKy);
            Controls.Add(txtid);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ThemSuaXoaHocKy";
            Text = "ThemSuaXoaHocKy";
            Load += ThemSuaXoaHocKy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtid;
        private TextBox txtTenHocKy;
        private ComboBox cbbNamHoc;
        private Button btnLuu;
        private Button btnThoat;
    }
}