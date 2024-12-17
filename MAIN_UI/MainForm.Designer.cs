namespace MAIN_UI
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            btnhethong = new ToolStripMenuItem();
            btnkhoahoc = new ToolStripMenuItem();
            btnnganhhoc = new ToolStripMenuItem();
            btnhocky = new ToolStripMenuItem();
            hìnhThứcToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            lbhello = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
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
            // btnhethong
            // 
            btnhethong.DropDownItems.AddRange(new ToolStripItem[] { btnkhoahoc, btnnganhhoc, btnhocky, hìnhThứcToolStripMenuItem });
            btnhethong.Name = "btnhethong";
            btnhethong.Size = new Size(72, 20);
            btnhethong.Text = "Hệ Thống";
            // 
            // btnkhoahoc
            // 
            btnkhoahoc.Name = "btnkhoahoc";
            btnkhoahoc.Size = new Size(135, 22);
            btnkhoahoc.Text = "Khoa Học";
            btnkhoahoc.Click += khoaHọcToolStripMenuItem_Click;
            // 
            // btnnganhhoc
            // 
            btnnganhhoc.Name = "btnnganhhoc";
            btnnganhhoc.Size = new Size(135, 22);
            btnnganhhoc.Text = "Ngành Học";
            btnnganhhoc.Click += ngànhHọcToolStripMenuItem_Click;
            // 
            // btnhocky
            // 
            btnhocky.Name = "btnhocky";
            btnhocky.Size = new Size(135, 22);
            btnhocky.Text = "Học Kỳ";
            btnhocky.Click += họcKỳToolStripMenuItem_Click;
            // 
            // hìnhThứcToolStripMenuItem
            // 
            hìnhThứcToolStripMenuItem.Name = "hìnhThứcToolStripMenuItem";
            hìnhThứcToolStripMenuItem.Size = new Size(135, 22);
            hìnhThứcToolStripMenuItem.Text = "Hình Thức";
            hìnhThứcToolStripMenuItem.Click += hìnhThứcToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(74, 20);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // lbhello
            // 
            lbhello.AutoSize = true;
            lbhello.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbhello.Location = new Point(434, 24);
            lbhello.Name = "lbhello";
            lbhello.Size = new Size(0, 30);
            lbhello.TabIndex = 1;
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

        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnhethong;
        private ToolStripMenuItem btnkhoahoc;
        private ToolStripMenuItem btnnganhhoc;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem btnhocky;
        private ToolStripMenuItem hìnhThứcToolStripMenuItem;
        private Label lbhello;
    }
}