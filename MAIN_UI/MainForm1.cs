using QLDKhoa_CNTT.BLL;
using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.GUI;
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
    public partial class MainForm1 : Form
    {
        public User taiKhoan { get; set; }
        private readonly UserService _userService; // Thêm UserService

        public MainForm1(UserService userService) // Sửa đổi constructor để nhận UserService
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
            //DiemForm1 diemForm = new DiemForm1((int currentUserId, UserService userService, DiemService diemService, LanThiService lanThiService, SinhVienService sinhVienService, MonHocService monHocService, LopHocService lopHocService, NganhHocService nganhHocService, HocKyService hockyService, NamHocService namHocService, UserRoleService userRoleService, RolePermissionService rolePermissionService);
            //diemForm.ShowDialog();
        }

        private void khoaViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaVien formKhoaVien = new FormKhoaVien();
            formKhoaVien.ShowDialog();
        }

        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVienForm giangVienForm = new GiangVienForm();
            giangVienForm.ShowDialog();
        }
        //private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    using (var dbContext = new QuanLyDiemKhoaCNTTContext())
        //    {
        //        // Tạo các Services, truyền dbContext trực tiếp vào
        //        //var userService = new UserService();
        //        var diemService = new DiemService();
        //        var lanThiService = new LanThiService();
        //        var sinhVienService = new SinhVienService();
        //        var monHocService = new MonHocService();
        //        var lopHocService = new LopHocService();
        //        var nganhHocService = new NganhHocService();
        //        var hocKyService = new HocKyService();
        //        var namHocService = new NamHocService();
        //        var userRoleService = new UserRoleService();
        //        var rolePermissionService = new RolePermissionService();


        //        // Lấy ID người dùng hiện tại - THAY ĐOẠN NÀY BẰNG LOGIC THỰC TẾ!
        //        int currentUserId = _userService.GetCurrentUserId(); // RẤT QUAN TRỌNG - Đừng gán cứng!


        //        // Tạo và hiển thị DiemForm1, cung cấp tất cả các dependency
        //        var diemForm = new DiemForm1(
        //            dbContext,                 // DbContext
        //            currentUserId,            // ID người dùng hiện tại
        //            _userService,             // Instance của UserService
        //            diemService,              // Instance của DiemService
        //            lanThiService,           // Instance của LanThiService
        //            sinhVienService,         // Instance của SinhVienService
        //            monHocService,           // Instance của MonHocService
        //            lopHocService,           // Instance của LopHocService
        //            nganhHocService,         // Instance của NganhHocService
        //            hocKyService,            // Instance của HocKyService
        //            namHocService,           // Instance của NamHocService
        //            userRoleService,         // Instance của UserRoleService
        //            rolePermissionService     // Instance của RolePermissionService
        //        );


        //        diemForm.ShowDialog(); // Hiển thị form
        //    }
        //}
    }
}
