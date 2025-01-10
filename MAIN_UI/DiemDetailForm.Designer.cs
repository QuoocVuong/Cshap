namespace MAIN_UI
{
    partial class DiemDetailForm
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
            txtInputId = new TextBox();
            label2 = new Label();
            cbbInputLopHoc = new ComboBox();
            label3 = new Label();
            cbbInputSinhVien = new ComboBox();
            label4 = new Label();
            cbbInputMonHoc = new ComboBox();
            label5 = new Label();
            cbbInputHinhThucThi = new ComboBox();
            label6 = new Label();
            cbbInputLanThi = new ComboBox();
            label7 = new Label();
            txtInputDiem = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtInputId
            // 
            txtInputId.Enabled = false;
            txtInputId.Location = new Point(120, 12);
            txtInputId.Margin = new Padding(4, 3, 4, 3);
            txtInputId.Name = "txtInputId";
            txtInputId.Size = new Size(325, 23);
            txtInputId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 46);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Lớp Học";
            // 
            // cbbInputLopHoc
            // 
            cbbInputLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbInputLopHoc.FormattingEnabled = true;
            cbbInputLopHoc.Location = new Point(120, 43);
            cbbInputLopHoc.Margin = new Padding(4, 3, 4, 3);
            cbbInputLopHoc.Name = "cbbInputLopHoc";
            cbbInputLopHoc.Size = new Size(325, 23);
            cbbInputLopHoc.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 77);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 4;
            label3.Text = "Sinh Viên:";
            // 
            // cbbInputSinhVien
            // 
            cbbInputSinhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbInputSinhVien.FormattingEnabled = true;
            cbbInputSinhVien.Location = new Point(120, 74);
            cbbInputSinhVien.Margin = new Padding(4, 3, 4, 3);
            cbbInputSinhVien.Name = "cbbInputSinhVien";
            cbbInputSinhVien.Size = new Size(325, 23);
            cbbInputSinhVien.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 108);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 6;
            label4.Text = "Môn Học";
            // 
            // cbbInputMonHoc
            // 
            cbbInputMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbInputMonHoc.FormattingEnabled = true;
            cbbInputMonHoc.Location = new Point(120, 105);
            cbbInputMonHoc.Margin = new Padding(4, 3, 4, 3);
            cbbInputMonHoc.Name = "cbbInputMonHoc";
            cbbInputMonHoc.Size = new Size(325, 23);
            cbbInputMonHoc.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 140);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 8;
            label5.Text = "Hình Thức Thi:";
            // 
            // cbbInputHinhThucThi
            // 
            cbbInputHinhThucThi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbInputHinhThucThi.FormattingEnabled = true;
            cbbInputHinhThucThi.Location = new Point(120, 136);
            cbbInputHinhThucThi.Margin = new Padding(4, 3, 4, 3);
            cbbInputHinhThucThi.Name = "cbbInputHinhThucThi";
            cbbInputHinhThucThi.Size = new Size(325, 23);
            cbbInputHinhThucThi.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 171);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 10;
            label6.Text = "Lần Thi:";
            // 
            // cbbInputLanThi
            // 
            cbbInputLanThi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbInputLanThi.FormattingEnabled = true;
            cbbInputLanThi.Location = new Point(120, 167);
            cbbInputLanThi.Margin = new Padding(4, 3, 4, 3);
            cbbInputLanThi.Name = "cbbInputLanThi";
            cbbInputLanThi.Size = new Size(325, 23);
            cbbInputLanThi.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 202);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 12;
            label7.Text = "Điểm:";
            // 
            // txtInputDiem
            // 
            txtInputDiem.Location = new Point(120, 198);
            txtInputDiem.Margin = new Padding(4, 3, 4, 3);
            txtInputDiem.Name = "txtInputDiem";
            txtInputDiem.Size = new Size(325, 23);
            txtInputDiem.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(264, 248);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 27);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(358, 248);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 27);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // DiemDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 288);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtInputDiem);
            Controls.Add(label7);
            Controls.Add(cbbInputLanThi);
            Controls.Add(label6);
            Controls.Add(cbbInputHinhThucThi);
            Controls.Add(label5);
            Controls.Add(cbbInputMonHoc);
            Controls.Add(label4);
            Controls.Add(cbbInputSinhVien);
            Controls.Add(label3);
            Controls.Add(cbbInputLopHoc);
            Controls.Add(label2);
            Controls.Add(txtInputId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiemDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi Tiết Điểm";
            Load += DiemDetailForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbInputLopHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbInputSinhVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbInputMonHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbInputHinhThucThi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbInputLanThi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInputDiem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}