namespace MAIN_UI
{
    partial class Login
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
            tbusername = new TextBox();
            tbpassword = new TextBox();
            btnlogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(360, 63);
            label1.Name = "label1";
            label1.Size = new Size(127, 54);
            label1.TabIndex = 0;
            label1.Text = "Login";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(198, 179);
            label2.Name = "label2";
            label2.Size = new Size(92, 28);
            label2.TabIndex = 1;
            label2.Text = "Usename";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(198, 261);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 2;
            label3.Text = "Password";
            label3.Click += label3_Click;
            // 
            // tbusername
            // 
            tbusername.Location = new Point(327, 168);
            tbusername.Margin = new Padding(3, 4, 3, 4);
            tbusername.Name = "tbusername";
            tbusername.Size = new Size(315, 27);
            tbusername.TabIndex = 3;
            tbusername.TabIndexChanged += tbpassword_TextChanged;
            // 
            // tbpassword
            // 
            tbpassword.Location = new Point(327, 251);
            tbpassword.Margin = new Padding(3, 4, 3, 4);
            tbpassword.Name = "tbpassword";
            tbpassword.PasswordChar = '*';
            tbpassword.Size = new Size(315, 27);
            tbpassword.TabIndex = 4;
            tbpassword.TabIndexChanged += tbpassword_TextChanged;
            tbpassword.TextChanged += tbpassword_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnlogin.Location = new Point(557, 349);
            btnlogin.Margin = new Padding(3, 4, 3, 4);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(86, 55);
            btnlogin.TabIndex = 5;
            btnlogin.TabStop = false;
            btnlogin.Text = "Sign in";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // Login
            // 
            AcceptButton = btnlogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnlogin);
            Controls.Add(tbpassword);
            Controls.Add(tbusername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbusername;
        private TextBox tbpassword;
        private Button btnlogin;
    }
}