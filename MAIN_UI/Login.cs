using Microsoft.Extensions.Configuration;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;

namespace MAIN_UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;
            //MessageBox.Show(GetConnectionString());
            TaiKhoanService service = new TaiKhoanService();
            TaiKhoan acc = service.CheckLogin(username, password);
            if (acc == null)
            {
                MessageBox.Show("login failed. Check your username and password", "huhu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (acc.Quyen == 3)
            {
                MessageBox.Show("You are not allowed to access this function", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            //KhoaHoc khoaHoc = new KhoaHoc();
            //khoaHoc.Show();
            //NganhHoc nganhHoc = new NganhHoc();
            //nganhHoc.Show();
            //this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.taiKhoan = acc;
            mainForm.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void tbpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
