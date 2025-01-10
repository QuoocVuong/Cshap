using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MAIN_UI
{
    public partial class MainForm : Form
    {
        public User user { get; set; }
        private readonly UserService _userService;

        public MainForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string roleName = user?.UserRoles?.First().Role?.RoleName;
            string username = user?.Username;

            string displayName = string.IsNullOrEmpty(roleName) ? username : $"{roleName} {username}";

            lbhello.Text = $"Xin chào, {displayName}!";

            // Role-Based Menu visibility Example
            if (user?.UserRoles?.Any() == true && user.UserRoles.First().Role != null)
            {
                SetMenuVisibility(user.UserRoles.First().Role.RoleName);
            }
        }

        private void SetMenuVisibility(string role)
        {
            switch (role)
            {
                case "Administrator":
                    // Admin can see everything
                    quanLyHocVuToolStripMenuItem.Visible = true;
                    báoCáoToolStripMenuItem.Visible = true;
                    break;
                case "Lecturer":
                    // Lecturer has access to some Academic Management and Reports
                    quanLyHocVuToolStripMenuItem.Visible = true;
                    báoCáoToolStripMenuItem.Visible = true;
                    //Disable Menu items
                    quanLyNguoiDungMenuItem.Enabled = false;
                    quanLyVaiTroMenuItem.Enabled = false;
                    quanLyQuyenMenuItem.Enabled = false;
                    phanQuyenNguoiDungMenuItem.Enabled = false;
                    phanQuyenVaiTroMenuItem.Enabled = false;
                    break;
                case "Student":
                    // Student access only to the reports

                    quanLyHocVuToolStripMenuItem.Visible = false;
                    báoCáoToolStripMenuItem.Visible = true;
                    quanLyNguoiDungMenuItem.Enabled = false;
                    quanLyVaiTroMenuItem.Enabled = false;
                    quanLyQuyenMenuItem.Enabled = false;
                    phanQuyenNguoiDungMenuItem.Enabled = false;
                    phanQuyenVaiTroMenuItem.Enabled = false;

                    break;

                default:
                    // Default to minimal visibility
                    quanLyHocVuToolStripMenuItem.Visible = false;
                    báoCáoToolStripMenuItem.Visible = false;
                    break;
            }
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //-----------------------------------He Thong---------------------------------------
        private void quanLyNguoiDungMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Người dùng");
            // Thêm code để mở form/chức năng quản lý người dùng
        }

        private void quanLyVaiTroMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Vai trò");
            // Thêm code để mở form/chức năng quản lý vai trò
        }

        private void quanLyQuyenMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Quyền");
            // Thêm code để mở form/chức năng quản lý quyền
        }

        private void phanQuyenNguoiDungMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Phân quyền Người dùng");
            // Thêm code để mở form/chức năng phân quyền người dùng
        }

        private void phanQuyenVaiTroMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Phân quyền Vai trò");
            // Thêm code để mở form/chức năng phân quyền vai trò
        }
        //---------------------------Quan ly Hoc vu---------------------------------------
        private void quanLyKhoaVienMenuItem_Click(object sender, EventArgs e)
        {

            FormKhoaVien formKhoaVien = new FormKhoaVien();
            formKhoaVien.ShowDialog();
        }
        private void quanLyKhoaMenuItem_Click(object sender, EventArgs e)
        {
            KhoaHoc khoaHoc = new KhoaHoc();
            khoaHoc.ShowDialog();
        }

        private void quanLyNganhHocMenuItem_Click(object sender, EventArgs e)
        {

            NganhHoc nganhHoc = new NganhHoc();
            nganhHoc.ShowDialog();
        }
        private void quanLyNamHocMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Năm học");
        }

        private void quanLyHocKyMenuItem_Click(object sender, EventArgs e)
        {

            HocKyForm hocKyForm = new HocKyForm();
            hocKyForm.ShowDialog();
        }
        private void quanLyMonHocMenuItem_Click(object sender, EventArgs e)
        {

            MonHocForm monHocForm = new MonHocForm();
            monHocForm.ShowDialog();
        }
        private void quanLyMonHocGiangVienMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Môn học - Giảng viên");
            // Thêm code để mở form/chức năng quản lý môn học-giang viên
        }
        private void quanLyLopHocMenuItem_Click(object sender, EventArgs e)
        {

            LopHocForm lopHocForm = new LopHocForm();
            lopHocForm.ShowDialog();
        }
        private void quanLyLopHocSinhVienMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Lớp học - Sinh viên");
            //Thêm code để mở form/chức năng quản lý Lớp học-Sinh viên
        }
        private void quanLyGiangVienMenuItem_Click(object sender, EventArgs e)
        {

            GiangVienForm giangVienForm = new GiangVienForm();
            giangVienForm.ShowDialog();
        }

        private void quanLySinhVienMenuItem_Click(object sender, EventArgs e)
        {

            SinhVienForm sinhVienForm = new SinhVienForm();
            sinhVienForm.ShowDialog();
        }
        private void quanLyLanThiMenuItem_Click(object sender, EventArgs e)
        {

            LanThiForm lanThiForm = new LanThiForm();
            lanThiForm.ShowDialog();
        }

        private void quanLyDiemMenuItem_Click(object sender, EventArgs e)
        {

            DiemForm diemForm = new DiemForm(_userService.GetCurrentUserId(), _userService);
            diemForm.ShowDialog();
        }
        //---------------------------------------Bao cao------------------------------------
        // Sự kiện click cho các mục menu trong "Báo cáo"
        private void baoCaoKetQuaHocTapMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiển thị Báo cáo Kết quả Học tập tổng quan");
            // Thêm code để tạo và hiển thị báo cáo kết quả học tập tổng quan
        }

        private void baoCaoThongKeSinhVienMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiển thị Báo cáo Thống kê Sinh viên");
            // Thêm code để tạo và hiển thị báo cáo thống kê sinh viên
        }

        private void baoCaoThongKeGiangVienMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiển thị Báo cáo Thống kê Giảng viên");
            // Thêm code để tạo và hiển thị báo cáo thống kê giảng viên
        }

        private void baoCaoDanhSachLopHocMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiển thị Báo cáo Danh sách Lớp học");
            // Thêm code để tạo và hiển thị báo cáo danh sách lớp học
        }

        private void baoCaoDanhSachDiemTheoLopMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiển thị Báo cáo Danh sách Điểm theo Lớp");
            // Thêm code để tạo và hiển thị báo cáo danh sách điểm theo lớp
            // Có thể cần một hộp thoại để người dùng chọn lớp
        }

        private void baoCaoKetQuaHocTapSinhVienMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiển thị Báo cáo Kết quả Học tập của từng Sinh viên");
            // Thêm code để tạo và hiển thị báo cáo kết quả học tập của từng sinh viên
            // Có thể cần một hộp thoại để người dùng chọn sinh viên
        }
        // Sự kiện cho TextBox (nếu có)
        private void timKiemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Tìm kiếm với từ khóa: " + timKiemTextBox.Text);
                // Thêm code để thực hiện tìm kiếm
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}