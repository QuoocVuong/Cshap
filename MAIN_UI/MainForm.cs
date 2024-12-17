using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN_UI
{
    public partial class MainForm : Form
    {
        public TaiKhoan taiKhoan { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void khoaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhoaHoc khoaHoc = new KhoaHoc();
            khoaHoc.ShowDialog();
        }

        private void ngànhHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NganhHoc nganhHoc = new NganhHoc();
            nganhHoc.ShowDialog();
        }

        private void họcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HocKyForm hocKyForm = new HocKyForm();
            hocKyForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //loi chao nguoi dung
            lbhello.Text = "Xin chào, " + taiKhoan.TenDangNhap + "!";
            //check role
            if (taiKhoan.Quyen == 2)
            {
                btnhocky.Enabled = false;
                btnkhoahoc.Enabled = false;
                btnnganhhoc.Enabled = false;
            }
        }

        private void hìnhThứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HinhThucForm hinhThucForm = new HinhThucForm();
            hinhThucForm.ShowDialog();
        }
    }
}
