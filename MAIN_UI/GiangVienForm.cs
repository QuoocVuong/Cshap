// GiangVienForm.cs (Code Behind)
using QLDKhoa_CNTT.BLL;
using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
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
    public partial class GiangVienForm : Form
    {
        private GiangVienService _giangVienService;
        private KhoaVienService _khoaVienService;
        private UserService _userService = new();
        private UserRoleService _userRolesService = new();
        private RolesService _rolesService = new();
        private int? _selectedKhoaVien = null;

        public GiangVienForm()
        {
            InitializeComponent();
            var context = new QuanLyDiemKhoaCnttContext();
            _khoaVienService = new(new KhoaVienRepository(context));
            _giangVienService = new (new GiangVienRepository(context));

        }

        private void GiangVienForm_Load(object sender, EventArgs e)
        {
            // Load dữ liệu cho ComboBox KhoaVien
            List<KhoaVien> khoaVienList = _khoaVienService.GetAllKhoaVien().ToList();
            khoaVienList.Insert(0, new KhoaVien { Id = -1, TenKhoaVien = "Tất Cả" });
            cbbLocTheoKhoa.DataSource = khoaVienList;
            cbbLocTheoKhoa.DisplayMember = "TenKhoaVien";
            cbbLocTheoKhoa.ValueMember = "Id";
            cbbLocTheoKhoa.SelectedIndexChanged += CbbLocTheoKhoa_SelectedIndexChanged;
            cbbLocTheoKhoa.SelectedIndex = 0;

            // Load dữ liệu vào DataGridView
            dgvGiangVien.CurrentCell = null;
            LoadDataInToDataGridView();
            txtId.Enabled = false;
            txtTenGiangVien.Enabled = false;
            txtMaGiangVien.Enabled = false;
            txtKhoa.Enabled = false;
        }

        private void CbbLocTheoKhoa_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FilterDataGridViewByKhoaVien();
        }

        private void LoadDataInToDataGridView()
        {
            dgvGiangVien.SelectionChanged -= dgvGiangVien_SelectionChanged;

            
            var result = _giangVienService.GetAllGiangVien();
            dgvGiangVien.DataSource = null;
            dgvGiangVien.DataSource = result;

            ReNameAndHideCollumn();

            dgvGiangVien.CellFormatting += dgvGiangVien_CellFormatting;

            dgvGiangVien.CurrentCell = null;

            dgvGiangVien.SelectionChanged += dgvGiangVien_SelectionChanged;
        }

        private void ReNameAndHideCollumn()
        {
            dgvGiangVien.Columns["Id"].HeaderText = "ID";
            dgvGiangVien.Columns["MaGiangVien"].HeaderText = "Mã Giảng Viên";
            dgvGiangVien.Columns["TenGiangVien"].HeaderText = "Tên Giảng Viên";
            dgvGiangVien.Columns["UserId"].Visible = false;
            dgvGiangVien.Columns["User"].Visible = false;
            dgvGiangVien.Columns["IdKhoaVien"].Visible = false;
            dgvGiangVien.Columns["IdKhoaVienNavigation"].Visible = false;
            dgvGiangVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiangVien.CurrentCell = null;
        }

        private void dgvGiangVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvGiangVien.Columns["UserId"].Index && e.Value is int userId)
            {
                var user = _userService.GetAUser(userId);
                e.Value = user?.Username ?? "";
                e.FormattingApplied = true;
            }
        }

        private void dgvGiangVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGiangVien.CurrentRow != null && dgvGiangVien.CurrentRow.DataBoundItem is GiangVien giangVien)
            {
                txtId.Text = giangVien.Id.ToString();
                txtMaGiangVien.Text = giangVien.MaGiangVien;
                txtTenGiangVien.Text = giangVien.TenGiangVien;

                // Lấy thông tin KhoaVien
                var khoaVien = _khoaVienService.GetAKhoaVien(giangVien.IdKhoaVien.GetValueOrDefault());
                if (khoaVien != null)
                {
                    txtKhoa.Text = khoaVien.TenKhoaVien;
                }
                else
                {
                    txtKhoa.Text = string.Empty;
                }
            }
            else
            {
                MakeBlankOfTextBox();
            }
        }

        private void FilterDataGridViewByKhoaVien()
        {
            //if (_giangVienService == null)
            //{
            //    _giangVienService;
            //}

            if (cbbLocTheoKhoa.SelectedIndex == 0 && cbbLocTheoKhoa.SelectedValue is int && (int)cbbLocTheoKhoa.SelectedValue == -1)
            {
                LoadDataInToDataGridView();
                return;
            }

            if (int.TryParse(cbbLocTheoKhoa.SelectedValue?.ToString(), out int idKhoaVien))
            {
                dgvGiangVien.DataSource = null;
                dgvGiangVien.DataSource = _giangVienService.GetAllGiangVien().Where(gv => gv.IdKhoaVien == idKhoaVien).ToList();
                ReNameAndHideCollumn();
                dgvGiangVien.CurrentCell = null;
                dgvGiangVien_SelectionChanged(null, null);
            }
            else if (cbbLocTheoKhoa.SelectedValue != null)
            {
                KhoaVien khoaVien = cbbLocTheoKhoa.SelectedValue as KhoaVien;
                if (khoaVien != null)
                {
                    var result = _giangVienService.GetAllGiangVien().Where(gv => gv.IdKhoaVien == khoaVien.Id).ToList();
                    dgvGiangVien.DataSource = null;
                    dgvGiangVien.DataSource = result;
                    ReNameAndHideCollumn();
                    _selectedKhoaVien = khoaVien.Id;
                    dgvGiangVien.CurrentCell = null;
                    dgvGiangVien_SelectionChanged(null, null);
                }
            }

            dgvGiangVien.Columns["UserId"].Visible = false;
            dgvGiangVien.Columns["User"].Visible = false;
            dgvGiangVien.Columns["IdKhoaVien"].Visible = false;
            dgvGiangVien.Columns["IdKhoaVienNavigation"].Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MakeBlankOfTextBox()
        {
            txtId.Clear();
            txtKhoa.Clear();
            txtMaGiangVien.Clear();
            txtTenGiangVien.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataInToDataGridView();
            cbbLocTheoKhoa.SelectedValue = -1;
            MakeBlankOfTextBox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn giảng viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var giangVien = _giangVienService.GetAGiangVien(id);
                if (giangVien == null)
                {
                    MessageBox.Show("Không tìm thấy giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy UserId của giảng viên để xóa User tương ứng
                if (giangVien.UserId.HasValue)
                {
                    var userToDelete = _userService.GetAUser(giangVien.UserId.Value);
                    if (userToDelete != null)
                    {
                        // Xóa UserRoles trước
                        _userRolesService.DeleteUserRolesByUserId(userToDelete.UserId);
                        // Sau đó xóa User
                        _userService.DeleteAnUser(userToDelete.UserId);
                    }
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa giảng viên: {giangVien.TenGiangVien}.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    object selectedValueKhoa = cbbLocTheoKhoa.SelectedValue;
                    _giangVienService.DeleteAGiangVien(id);
                    MessageBox.Show("Xóa giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FilterDataGridViewByKhoaVien();
                    if (cbbLocTheoKhoa.Items.Count > 0 && selectedValueKhoa != null)
                    {
                        cbbLocTheoKhoa.SelectedValue = selectedValueKhoa;
                    }
                    MakeBlankOfTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaGiangVien themSuaGiangVien = new();
            themSuaGiangVien.DataSaved += ThemSuaGiangVien_DataSaved;
            themSuaGiangVien.id = null;
            if (_selectedKhoaVien.HasValue && _selectedKhoaVien != -1)
            {
                themSuaGiangVien.SelectedValueKhoaVien = _selectedKhoaVien;
            }
            themSuaGiangVien.IsNew = true;
            themSuaGiangVien.ShowDialog();
        }

        private async void ThemSuaGiangVien_DataSaved(object? sender, ThemSuaGiangVien.DataSavedEventArgs e)
        {
            object selectedValue = e.SelectedValueKhoaVien;
            FilterDataGridViewByKhoaVien();
            if (cbbLocTheoKhoa.Items.Count > 0 && selectedValue != null)
            {
                cbbLocTheoKhoa.SelectedValue = selectedValue;
            }
            MakeBlankOfTextBox();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtMaGiangVien.Text) || !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Vui lòng chọn giảng viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ThemSuaGiangVien themSuaGiangVien = new();
            themSuaGiangVien.id = int.Parse(txtId.Text);
            themSuaGiangVien.DataSaved += ThemSuaGiangVien_DataSaved;
            if (_selectedKhoaVien.HasValue && _selectedKhoaVien != -1)
            {
                themSuaGiangVien.SelectedValueKhoaVien = _selectedKhoaVien;
            }
            themSuaGiangVien.IsNew = false;
            themSuaGiangVien.ShowDialog();
        }
    }
}