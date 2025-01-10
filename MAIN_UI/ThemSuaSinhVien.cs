using QLDKhoa_CNTT.BLL;
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
using static MAIN_UI.ThemSuaLopHoc;

namespace MAIN_UI
{
    public partial class ThemSuaSinhVien : Form
    {
        public ThemSuaSinhVien()
        {
            InitializeComponent();
        }
        private SinhVienService _sinhVienService = new SinhVienService();
        private LopHocService _lopHocService = new LopHocService();
        private UserService _userService = new UserService(); // Thêm UserService
        private UserRoleService _userRolesService = new UserRoleService(); // Thêm UserRolesService
        private RolesService _rolesService = new RolesService(); // Thêm RolesService
        public event EventHandler<DataSavedEventArgs> DataSaved;
        public int? id { get; set; }
        public int? SelecedValueLops { get; set; }
        public bool IsNew { get; internal set; }

        public class DataSavedEventArgs : EventArgs
        {
            public int? SelecedValueLops { get; set; }
        }

        private void ThemSuaSinhVien_Load(object sender, EventArgs e)
        {
            LoadDataCombobox();
            LoadFormData();
        }
        // Hàm load data lên combobox
        private void LoadDataCombobox()
        {
            // Lấy danh sách tất cả các ngành học và gán vào combobox
            cbbLop.DataSource = _lopHocService.GetAllLopHocs();
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "Id";
        }
        // Hàm load data lên form
        private void LoadFormData()
        {
            if (id.HasValue) // Nếu ở chế độ chỉnh sửa
            {
                // Lấy thông tin lớp học dựa trên ID
                var sinhVien = _sinhVienService.GetAnSinhVien(id.Value);
                if (sinhVien != null)
                {
                    // Hiển thị thông tin lớp học lên form
                    txtIdSinhVien.Text = sinhVien.Id.ToString();
                    txtMaSinhVien.Text = sinhVien.MaSinhVien;
                    txtTenSinhVien.Text = sinhVien.TenSinhVien;
                    txtIdSinhVien.Enabled = false; // Không cho phép sửa ID
                    txtMaSinhVien.Enabled = false; // Không cho phép sửa Mã Sinh Viên khi sửa
                    if (sinhVien.NgaySinh is DateOnly ngaySinh)
                    {
                        dtpNgaySinh.Value = ngaySinh.ToDateTime(TimeOnly.MinValue); // Chuyển DateOnly thành DateTime
                    }
                    cbbLop.SelectedValue = sinhVien.IdLop; // Chọn lop học tương ứng
                    label1.Text = "Chỉnh Sửa Sinh Viên";
                }
            }
            else // Nếu ở chế độ thêm mới
            {
                // Đặt giá trị mặc định khi thêm mới
                cbbLop.SelectedIndex = -1; // Bỏ chọn item trong combobox
                label1.Text = "Thêm Sinh Viên Mới";
                txtIdSinhVien.Enabled = false;  // Không cho phép sửa ID
                txtMaSinhVien.Enabled = true; // Cho phép sửa Mã Sinh Viên khi thêm mới
            }

            if (SelecedValueLops.HasValue && SelecedValueLops != -1)
            {
                cbbLop.SelectedValue = SelecedValueLops; // Nếu có Id ngành học được truyền vào thì chọn
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false) return;
            SaveSinhVien();
        }
        public bool ValidateInput()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaSinhVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (string.IsNullOrWhiteSpace(txtTenSinhVien.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Sinh Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }

            // Lấy giá trị ngày
            DateTime dateTimeValue = dtpNgaySinh.Value;
            DateOnly dateOnlyValue = DateOnly.FromDateTime(dateTimeValue);
            //Kiểm tra ngày không lớn hơn ngày hiện tại
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            if (dateOnlyValue > currentDate)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (cbbLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Lớp học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLop.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (!int.TryParse(cbbLop.SelectedValue.ToString(), out int _))
            {
                MessageBox.Show("Lớp học không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLop.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            return true;
        }
        // Hàm save SinhVien
        private async void SaveSinhVien()
        {
            // lấy id lớp học
            int idLop = int.Parse(cbbLop.SelectedValue.ToString());
            // Lấy giá trị ngày từ DateTimePicker và chuyển thành DateOnly
            DateTime dateTimeValue = dtpNgaySinh.Value;
            DateOnly dateOnlyValue = DateOnly.FromDateTime(dateTimeValue);

            try
            {
                if (!id.HasValue) // Nếu ở chế độ thêm mới
                {
                    // Tạo đối tượng User mới
                    var newUser = new User()
                    {
                        Username = txtTenSinhVien.Text.Trim(),
                        Password = txtMaSinhVien.Text.Trim(), // Sử dụng Mã Sinh Viên làm mật khẩu (lưu ý bảo mật)
                        CreatedAt = DateTime.Now
                    };
                    _userService.AddAnUser(newUser);

                    // Lấy UserID vừa tạo
                    var addedUser = _userService.GetAllUsers().OrderByDescending(u => u.UserId).FirstOrDefault();

                    if (addedUser != null)
                    {
                        // Tạo đối tượng SinhVien mới
                        SinhVien sinhVien = new()
                        {
                            MaSinhVien = txtMaSinhVien.Text.Trim(),
                            TenSinhVien = txtTenSinhVien.Text.Trim(),
                            NgaySinh = dateOnlyValue,
                            IdLop = idLop,
                            UserId = addedUser.UserId // Gán UserID
                        };

                        // Thêm sinh viên mới vào cơ sở dữ liệu
                        _sinhVienService.CreateAnSinhvien(sinhVien);

                        // Gán Role "Sinh viên"
                        // Lấy RoleID của role "sinhvien" (mã 3)
                        int roleSinhVienId = 3;

                        // Tạo một bản ghi UserRoles
                        var newUserRole = new UserRole()
                        {
                            UserId = addedUser.UserId,
                            RoleId = roleSinhVienId,
                            CreatedAt = DateTime.Now
                        };
                        _userRolesService.AddAnUserRole(newUserRole);

                        MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi tạo User.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu không tạo được User
                    }
                }
                else // Nếu ở chế độ chỉnh sửa
                {
                    // Lấy đối tượng sinh viên từ cơ sở dữ liệu dựa trên Id
                    SinhVien sinhVien = _sinhVienService.GetAnSinhVien(id.Value);

                    if (sinhVien != null)
                    {
                        // Cập nhật thông tin sinh viên
                        sinhVien.MaSinhVien = txtMaSinhVien.Text.Trim();
                        sinhVien.TenSinhVien = txtTenSinhVien.Text.Trim();
                        sinhVien.NgaySinh = dateOnlyValue;
                        sinhVien.IdLop = idLop;

                        // Cập nhật thông tin sinh viên vào cơ sở dữ liệu
                        _sinhVienService.UpdateAnSinhVien(sinhVien);
                        MessageBox.Show("Cập nhật sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataSaved?.Invoke(this, new DataSavedEventArgs { SelecedValueLops = idLop }); // Kích hoạt event
                Close(); // Đóng form
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close(); // Đóng form
        }
    }
}