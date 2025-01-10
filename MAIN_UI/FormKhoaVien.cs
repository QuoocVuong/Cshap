// FormKhoaVien.cs - Code Behind
using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDKhoa_CNTT.GUI
{
    public partial class FormKhoaVien : Form
    {
        private readonly KhoaVienService _khoaVienService;

        public FormKhoaVien()
        {
            InitializeComponent();
            // Khởi tạo context và service (trong thực tế nên dùng Dependency Injection)
            var context = new QuanLyDiemKhoaCnttContext();
            _khoaVienService = new KhoaVienService(new DAL.Repositories.KhoaVienRepository(context));
            LoadKhoaVien();
        }

        private void LoadKhoaVien()
        {
            dgvKhoaVien.DataSource = _khoaVienService.GetAllKhoaVien().ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhoaVien.Text) || string.IsNullOrEmpty(txtTenKhoaVien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhoaVien newKhoaVien = new KhoaVien()
            {
                MaKhoaVien = txtMaKhoaVien.Text,
                TenKhoaVien = txtTenKhoaVien.Text
            };

            _khoaVienService.CreateAKhoaVien(newKhoaVien);
            LoadKhoaVien();
            ClearForm();
            MessageBox.Show("Thêm khoa viện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhoaVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khoa viện cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMaKhoaVien.Text) || string.IsNullOrEmpty(txtTenKhoaVien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvKhoaVien.SelectedRows[0].Cells["ID"].Value;
            KhoaVien existingKhoaVien = _khoaVienService.GetAKhoaVien(id);

            if (existingKhoaVien != null)
            {
                existingKhoaVien.MaKhoaVien = txtMaKhoaVien.Text;
                existingKhoaVien.TenKhoaVien = txtTenKhoaVien.Text;

                _khoaVienService.UpdateAKhoaVien(existingKhoaVien);
                LoadKhoaVien();
                MessageBox.Show("Cập nhật khoa viện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoa viện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhoaVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khoa viện cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvKhoaVien.SelectedRows[0].Cells["ID"].Value;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khoa viện này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _khoaVienService.DeleteAKhoaVien(id);
                LoadKhoaVien();
                ClearForm();
                MessageBox.Show("Xóa khoa viện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvKhoaVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKhoaVien.Rows[e.RowIndex].DataBoundItem != null)
            {
                KhoaVien selectedKhoaVien = (KhoaVien)dgvKhoaVien.Rows[e.RowIndex].DataBoundItem;
                txtMaKhoaVien.Text = selectedKhoaVien.MaKhoaVien;
                txtTenKhoaVien.Text = selectedKhoaVien.TenKhoaVien;
            }
        }

        private void ClearForm()
        {
            txtMaKhoaVien.Text = "";
            txtTenKhoaVien.Text = "";
            dgvKhoaVien.ClearSelection();
        }
    }
}