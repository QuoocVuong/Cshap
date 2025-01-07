using QLDKhoa_CNTT.BLL.Services;
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
        public User taiKhoan { get; set; }
        private readonly UserService _userService; // Thêm UserService

        public MainForm(UserService userService) // Sửa đổi constructor để nhận UserService
        {
            InitializeComponent();
            _userService = userService; // Lưu trữ UserService instance
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
            lbhello.Text = "Xin chào, " + taiKhoan.Username + "!";
            //check role
            //if (t == 2)
            //{
            //    btnhocky.Enabled = false;
            //    btnkhoahoc.Enabled = false;
            //    btnnganhhoc.Enabled = false;
            //}
        }

        private void LopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LopHocForm lopHocForm = new LopHocForm();
            lopHocForm.ShowDialog();
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVienForm sinhVienForm = new SinhVienForm();
            sinhVienForm.ShowDialog();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonHocForm monHocForm = new MonHocForm();
            monHocForm.ShowDialog();
        }

        private void lầnThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanThiForm lanThiForm = new LanThiForm();
            lanThiForm.ShowDialog();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiemForm diemForm = new DiemForm(_userService.GetCurrentUserId(), _userService);
            diemForm.ShowDialog();
        }
    }
}
