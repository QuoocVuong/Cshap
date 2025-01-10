// ThemSuaGiangVien.cs (Code Behind)
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
    public partial class ThemSuaGiangVien : Form
    {
        private GiangVienService _giangVienService;
        private KhoaVienService _khoaVienService;
        private UserService _userService = new UserService();
        private UserRoleService _userRolesService = new UserRoleService();
        private RolesService _rolesService = new RolesService();

        public event EventHandler<DataSavedEventArgs> DataSaved;
        public int? id { get; set; }
        public int? SelectedValueKhoaVien { get; set; }
        public bool IsNew { get; set; }

        public ThemSuaGiangVien()
        {
            InitializeComponent();
            var context = new QuanLyDiemKhoaCnttContext();
            _khoaVienService = new(new KhoaVienRepository(context));
            _giangVienService = new(new GiangVienRepository(context));
        }

        
        public class DataSavedEventArgs : EventArgs
        {
            public int? SelectedValueKhoaVien { get; set; }
        }

        private void ThemSuaGiangVien_Load(object sender, EventArgs e)
        {
            LoadDataCombobox();
            LoadFormData();
        }

        private void LoadDataCombobox()
        {
            cbbKhoa.DataSource = _khoaVienService.GetAllKhoaVien();
            cbbKhoa.DisplayMember = "TenKhoaVien";
            cbbKhoa.ValueMember = "Id";
        }

        private void LoadFormData()
        {
            if (id.HasValue)
            {
                var giangVien = _giangVienService.GetAGiangVien(id.Value);
                if (giangVien != null)
                {
                    txtIdGiangVien.Text = giangVien.Id.ToString();
                    txtMaGiangVien.Text = giangVien.MaGiangVien;
                    txtTenGiangVien.Text = giangVien.TenGiangVien;
                    txtIdGiangVien.Enabled = false;
                    txtMaGiangVien.Enabled = false; // Không cho sửa mã GV
                    cbbKhoa.SelectedValue = giangVien.IdKhoaVien;
                    label1.Text = "Chỉnh Sửa Giảng Viên";
                    
                }
            }
            else
            {
                cbbKhoa.SelectedIndex = -1;
                label1.Text = "Thêm Giảng Viên Mới";
                txtIdGiangVien.Enabled = false;
                txtMaGiangVien.Enabled = true; // Cho phép sửa mã GV khi thêm mới
            }

            if (SelectedValueKhoaVien.HasValue && SelectedValueKhoaVien != -1)
            {
                cbbKhoa.SelectedValue = SelectedValueKhoaVien;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false) return;
            SaveGiangVien();
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaGiangVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Giảng Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGiangVien.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenGiangVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Giảng Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenGiangVien.Focus();
                return false;
            }
            if (cbbKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbKhoa.Focus();
                return false;
            }
            if (!int.TryParse(cbbKhoa.SelectedValue.ToString(), out int _))
            {
                MessageBox.Show("Khoa Viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbKhoa.Focus();
                return false;
            }
            return true;
        }

        private async void SaveGiangVien()
        {
            string maGiangVien = txtMaGiangVien.Text.Trim();
            string tenGiangVien = txtTenGiangVien.Text.Trim();
            int idKhoaVien = int.Parse(cbbKhoa.SelectedValue.ToString());

            try
            {
                if (!id.HasValue) // Thêm mới
                {
                    // Tạo User mới
                    var newUser = new User()
                    {
                        Username = tenGiangVien,
                        Password = maGiangVien, // Sử dụng Mã Giảng Viên làm mật khẩu
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    _userService.AddAnUser(newUser);

                    // Lấy UserID vừa tạo
                    var addedUser = _userService.GetAllUsers().OrderByDescending(u => u.UserId).FirstOrDefault();

                    if (addedUser != null)
                    {
                        // Tạo Giảng Viên mới
                        GiangVien giangVien = new()
                        {
                            MaGiangVien = maGiangVien,
                            TenGiangVien = tenGiangVien,
                            UserId = addedUser.UserId,
                            IdKhoaVien = idKhoaVien
                        };
                        _giangVienService.CreateAGiangVien(giangVien);

                        // Gán Role "Giảng viên"
                        int roleGiangVienId = 2; // Giả sử RoleID của "Giảng viên" là 2
                        var newUserRole = new UserRole()
                        {
                            UserId = addedUser.UserId,
                            RoleId = roleGiangVienId,
                            CreatedAt = DateTime.Now
                        };
                        _userRolesService.AddAnUserRole(newUserRole);

                        MessageBox.Show("Thêm giảng viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi tạo User.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else // Chỉnh sửa
                {
                    var giangVien = _giangVienService.GetAGiangVien(id.Value);
                    if (giangVien != null)
                    {
                        // Cập nhật thông tin Giảng viên (không cập nhật Mã GV)
                        giangVien.TenGiangVien = tenGiangVien;
                        giangVien.IdKhoaVien = idKhoaVien;

                        // Lấy User liên quan và cập nhật thông tin
                        var user = _userService.GetAUser(giangVien.UserId.Value);
                        if (user != null)
                        {
                            user.Username = tenGiangVien;
                            //user.IdKhoa = null; // No relation to Khoa table anymore
                            _userService.UpdateAnUser(user);
                        }

                        _giangVienService.UpdateAGiangVien(giangVien);
                        MessageBox.Show("Cập nhật giảng viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy giảng viên để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataSaved?.Invoke(this, new DataSavedEventArgs { SelectedValueKhoaVien = idKhoaVien });
                Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
