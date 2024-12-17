namespace MAIN_UI
{
    partial class KhoaHoc
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
            txttenkhoa = new TextBox();
            btnthemtnkhoa = new Button();
            btnsuatenkhoa = new Button();
            btnxoatenkhoa = new Button();
            dgvKhoaHocList = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhoaHocList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(359, 95);
            label1.Name = "label1";
            label1.Size = new Size(225, 60);
            label1.TabIndex = 0;
            label1.Text = "Khoa Hoc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(182, 232);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 1;
            label2.Text = "Ten Khoa";
            // 
            // txttenkhoa
            // 
            txttenkhoa.Location = new Point(334, 229);
            txttenkhoa.Margin = new Padding(3, 4, 3, 4);
            txttenkhoa.Name = "txttenkhoa";
            txttenkhoa.Size = new Size(286, 27);
            txttenkhoa.TabIndex = 2;
            // 
            // btnthemtnkhoa
            // 
            btnthemtnkhoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnthemtnkhoa.Location = new Point(771, 171);
            btnthemtnkhoa.Margin = new Padding(3, 4, 3, 4);
            btnthemtnkhoa.Name = "btnthemtnkhoa";
            btnthemtnkhoa.Size = new Size(86, 61);
            btnthemtnkhoa.TabIndex = 3;
            btnthemtnkhoa.Text = "Them";
            btnthemtnkhoa.UseVisualStyleBackColor = true;
            // 
            // btnsuatenkhoa
            // 
            btnsuatenkhoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnsuatenkhoa.Location = new Point(771, 251);
            btnsuatenkhoa.Margin = new Padding(3, 4, 3, 4);
            btnsuatenkhoa.Name = "btnsuatenkhoa";
            btnsuatenkhoa.Size = new Size(86, 61);
            btnsuatenkhoa.TabIndex = 4;
            btnsuatenkhoa.Text = "Sua";
            btnsuatenkhoa.UseVisualStyleBackColor = true;
            // 
            // btnxoatenkhoa
            // 
            btnxoatenkhoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnxoatenkhoa.Location = new Point(771, 328);
            btnxoatenkhoa.Margin = new Padding(3, 4, 3, 4);
            btnxoatenkhoa.Name = "btnxoatenkhoa";
            btnxoatenkhoa.Size = new Size(86, 61);
            btnxoatenkhoa.TabIndex = 5;
            btnxoatenkhoa.Text = "Xoa";
            btnxoatenkhoa.UseVisualStyleBackColor = true;
            btnxoatenkhoa.Click += btnxoatenkhoa_Click;
            // 
            // dgvKhoaHocList
            // 
            dgvKhoaHocList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoaHocList.Location = new Point(50, 328);
            dgvKhoaHocList.Margin = new Padding(3, 4, 3, 4);
            dgvKhoaHocList.Name = "dgvKhoaHocList";
            dgvKhoaHocList.RowHeadersWidth = 51;
            dgvKhoaHocList.Size = new Size(689, 256);
            dgvKhoaHocList.TabIndex = 6;
            dgvKhoaHocList.SelectionChanged += dgvKhoaHocLis_SelectionChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.Location = new Point(771, 417);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 59);
            button1.TabIndex = 7;
            button1.Text = "Thoat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // KhoaHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button1);
            Controls.Add(dgvKhoaHocList);
            Controls.Add(btnxoatenkhoa);
            Controls.Add(btnsuatenkhoa);
            Controls.Add(btnthemtnkhoa);
            Controls.Add(txttenkhoa);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "KhoaHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KhoaHoc";
            FormClosing += KhoaHoc_FormClosing;
            Load += KhoaHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhoaHocList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txttenkhoa;
        private Button btnthemtnkhoa;
        private Button btnsuatenkhoa;
        private Button btnxoatenkhoa;
        private DataGridView dgvKhoaHocList;
        private Button button1;
    }
}