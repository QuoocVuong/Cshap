namespace MAIN_UI
{
    partial class MainForm1
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
            lbhello = new Label();
            btnhethong = new ToolStripMenuItem();
            btnkhoahoc = new ToolStripMenuItem();
            btnnganhhoc = new ToolStripMenuItem();
            btnhocky = new ToolStripMenuItem();
            LopHocToolStripMenuItem = new ToolStripMenuItem();
            sinhVienToolStripMenuItem = new ToolStripMenuItem();
            mônHọcToolStripMenuItem = new ToolStripMenuItem();
            lầnThiToolStripMenuItem = new ToolStripMenuItem();
            điểmToolStripMenuItem = new ToolStripMenuItem();
            khoaViệnToolStripMenuItem = new ToolStripMenuItem();
            giảngViênToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lbhello
            // 
            lbhello.AutoSize = true;
            lbhello.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbhello.Location = new Point(317, 64);
            lbhello.Name = "lbhello";
            lbhello.Size = new Size(58, 30);
            lbhello.TabIndex = 1;
            lbhello.Text = "hjgh";
            // 
            // btnhethong
            // 
            btnhethong.DropDownItems.AddRange(new ToolStripItem[] { btnkhoahoc, btnnganhhoc, btnhocky, LopHocToolStripMenuItem, sinhVienToolStripMenuItem, mônHọcToolStripMenuItem, lầnThiToolStripMenuItem, điểmToolStripMenuItem, khoaViệnToolStripMenuItem, giảngViênToolStripMenuItem });
            btnhethong.Name = "btnhethong";
            btnhethong.Size = new Size(72, 20);
            btnhethong.Text = "Hệ Thống";
            // 
            // btnkhoahoc
            // 
            btnkhoahoc.Name = "btnkhoahoc";
            btnkhoahoc.Size = new Size(131, 22);
            btnkhoahoc.Text = "Khóa ";
            btnkhoahoc.Click += khoaHọcToolStripMenuItem_Click;
            // 
            // btnnganhhoc
            // 
            btnnganhhoc.Name = "btnnganhhoc";
            btnnganhhoc.Size = new Size(131, 22);
            btnnganhhoc.Text = "Ngành ";
            btnnganhhoc.Click += ngànhHọcToolStripMenuItem_Click;
            // 
            // btnhocky
            // 
            btnhocky.Name = "btnhocky";
            btnhocky.Size = new Size(131, 22);
            btnhocky.Text = "Học Kỳ";
            btnhocky.Click += họcKỳToolStripMenuItem_Click;
            // 
            // LopHocToolStripMenuItem
            // 
            LopHocToolStripMenuItem.Name = "LopHocToolStripMenuItem";
            LopHocToolStripMenuItem.Size = new Size(131, 22);
            LopHocToolStripMenuItem.Text = "Lớp ";
            LopHocToolStripMenuItem.Click += LopHocToolStripMenuItem_Click;
            // 
            // sinhVienToolStripMenuItem
            // 
            sinhVienToolStripMenuItem.Name = "sinhVienToolStripMenuItem";
            sinhVienToolStripMenuItem.Size = new Size(131, 22);
            sinhVienToolStripMenuItem.Text = "Sinh Viên";
            sinhVienToolStripMenuItem.Click += sinhVienToolStripMenuItem_Click;
            // 
            // mônHọcToolStripMenuItem
            // 
            mônHọcToolStripMenuItem.Name = "mônHọcToolStripMenuItem";
            mônHọcToolStripMenuItem.Size = new Size(131, 22);
            mônHọcToolStripMenuItem.Text = "Môn ";
            mônHọcToolStripMenuItem.Click += mônHọcToolStripMenuItem_Click;
            // 
            // lầnThiToolStripMenuItem
            // 
            lầnThiToolStripMenuItem.Name = "lầnThiToolStripMenuItem";
            lầnThiToolStripMenuItem.Size = new Size(131, 22);
            lầnThiToolStripMenuItem.Text = "Lần Thi";
            lầnThiToolStripMenuItem.Click += lầnThiToolStripMenuItem_Click;
            // 
            // điểmToolStripMenuItem
            // 
            điểmToolStripMenuItem.Name = "điểmToolStripMenuItem";
            điểmToolStripMenuItem.Size = new Size(131, 22);
            điểmToolStripMenuItem.Text = "Điểm";
            điểmToolStripMenuItem.Click += điểmToolStripMenuItem_Click;
            // 
            // khoaViệnToolStripMenuItem
            // 
            khoaViệnToolStripMenuItem.Name = "khoaViệnToolStripMenuItem";
            khoaViệnToolStripMenuItem.Size = new Size(131, 22);
            khoaViệnToolStripMenuItem.Text = "Khoa Viện";
            khoaViệnToolStripMenuItem.Click += khoaViệnToolStripMenuItem_Click;
            // 
            // giảngViênToolStripMenuItem
            // 
            giảngViênToolStripMenuItem.Name = "giảngViênToolStripMenuItem";
            giảngViênToolStripMenuItem.Size = new Size(131, 22);
            giảngViênToolStripMenuItem.Text = "Giảng Viên";
            giảngViênToolStripMenuItem.Click += giảngViênToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(74, 20);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnhethong, đăngXuấtToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lbhello);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbhello;
        private ToolStripMenuItem btnhethong;
        private ToolStripMenuItem btnkhoahoc;
        private ToolStripMenuItem btnnganhhoc;
        private ToolStripMenuItem btnhocky;
        private ToolStripMenuItem LopHocToolStripMenuItem;
        private ToolStripMenuItem sinhVienToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mônHọcToolStripMenuItem;
        private ToolStripMenuItem lầnThiToolStripMenuItem;
        private ToolStripMenuItem điểmToolStripMenuItem;
        private ToolStripMenuItem khoaViệnToolStripMenuItem;
        private ToolStripMenuItem giảngViênToolStripMenuItem;
    }
}