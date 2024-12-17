namespace MAIN_UI
{
    partial class ThemSuaNganhHoc
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
            btnthem = new Button();
            btnthoat = new Button();
            txtid = new TextBox();
            txttennganh = new TextBox();
            cbbkhoa = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(308, 49);
            label1.Name = "label1";
            label1.Size = new Size(282, 45);
            label1.TabIndex = 0;
            label1.Text = "Them Nganh Hoc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label2.Location = new Point(131, 135);
            label2.Name = "label2";
            label2.Size = new Size(32, 25);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label3.Location = new Point(141, 199);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 2;
            label3.Text = "Ten Nganh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label4.Location = new Point(148, 276);
            label4.Name = "label4";
            label4.Size = new Size(57, 25);
            label4.TabIndex = 3;
            label4.Text = "Khoa";
            // 
            // btnthem
            // 
            btnthem.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnthem.Location = new Point(432, 361);
            btnthem.Name = "btnthem";
            btnthem.Size = new Size(113, 39);
            btnthem.TabIndex = 4;
            btnthem.Text = "Luu";
            btnthem.UseVisualStyleBackColor = true;
            btnthem.Click += btnthem_Click;
            // 
            // btnthoat
            // 
            btnthoat.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnthoat.Location = new Point(604, 361);
            btnthoat.Name = "btnthoat";
            btnthoat.Size = new Size(75, 39);
            btnthoat.TabIndex = 5;
            btnthoat.Text = "Thoat";
            btnthoat.UseVisualStyleBackColor = true;
            btnthoat.Click += btnthoat_Click;
            // 
            // txtid
            // 
            txtid.Location = new Point(314, 132);
            txtid.Name = "txtid";
            txtid.Size = new Size(242, 23);
            txtid.TabIndex = 6;
            // 
            // txttennganh
            // 
            txttennganh.Location = new Point(314, 196);
            txttennganh.Name = "txttennganh";
            txttennganh.Size = new Size(242, 23);
            txttennganh.TabIndex = 7;
            // 
            // cbbkhoa
            // 
            cbbkhoa.FormattingEnabled = true;
            cbbkhoa.Location = new Point(314, 273);
            cbbkhoa.Name = "cbbkhoa";
            cbbkhoa.Size = new Size(263, 23);
            cbbkhoa.TabIndex = 8;
            // 
            // ThemSuaNganhHoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 450);
            Controls.Add(cbbkhoa);
            Controls.Add(txttennganh);
            Controls.Add(txtid);
            Controls.Add(btnthoat);
            Controls.Add(btnthem);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ThemSuaNganhHoc";
            Text = "ThemSuaNganhHoc";
            Load += ThemSuaNganhHoc_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnthem;
        private Button btnthoat;
        private TextBox txtid;
        private TextBox txttennganh;
        private ComboBox cbbkhoa;
    }
}