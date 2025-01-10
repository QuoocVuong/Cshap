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

namespace MAIN_UI
{
    public partial class DiemDetailForm : Form
    {
        private readonly DiemService _diemService;
        private readonly LanThiService _lanThiService;
        private readonly SinhVienService _sinhVienService;
        private readonly MonHocService _monHocService;
        private readonly LopHocService _lopHocService;
        private bool _isAddingNew = false;
        private int? _currentEditId = null;

        public event EventHandler DataSaved;

        public DiemDetailForm(DiemService diemService, LanThiService lanThiService, SinhVienService sinhVienService, MonHocService monHocService, LopHocService lopHocService)
        {
            InitializeComponent();
            _diemService = diemService;
            _lanThiService = lanThiService;
            _sinhVienService = sinhVienService;
            _monHocService = monHocService;
            _lopHocService = lopHocService;
        }

        private void DiemDetailForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            LoadComboBoxInputLop();
            LoadComboBoxInputMonHoc();
        }

        private void LoadComboBoxInputLop()
        {
            cbbInputLopHoc.DataSource = _lopHocService.GetAllLopHocs().ToList();
            cbbInputLopHoc.DisplayMember = "TenLop";
            cbbInputLopHoc.ValueMember = "Id";
            cbbInputLopHoc.SelectedIndex = -1;
        }

        private void LoadComboBoxInputSinhVien(int? idLop)
        {
            cbbInputSinhVien.DataSource = null;
            if (idLop.HasValue)
            {
                cbbInputSinhVien.DataSource = _sinhVienService.GetAllSinhVien().Where(sv => sv.IdLop == idLop).ToList();
            }
            else
            {
                cbbInputSinhVien.DataSource = _sinhVienService.GetAllSinhVien().ToList();
            }
            cbbInputSinhVien.DisplayMember = "TenSinhVien";
            cbbInputSinhVien.ValueMember = "Id";
            cbbInputSinhVien.SelectedIndex = -1;
        }

        private void LoadComboBoxInputMonHoc()
        {
            cbbInputMonHoc.DataSource = _monHocService.GetAllMonHocs().ToList();
            cbbInputMonHoc.DisplayMember = "TenMonHoc";
            cbbInputMonHoc.ValueMember = "Id";
            cbbInputMonHoc.SelectedIndex = -1;
        }

        private void LoadComboBoxInputHinhThucThi(int? idMonHoc)
        {
            cbbInputHinhThucThi.DataSource = null;
            if (idMonHoc.HasValue)
            {
                cbbInputHinhThucThi.DataSource = _lanThiService.GetAllLanThis()
                                              .Where(lt => lt.IdMonHoc == idMonHoc)
                                              .Select(lt => lt.HinhThucThi)
                                              .Distinct()
                                              .ToList();
            }
            cbbInputHinhThucThi.SelectedIndex = -1;
        }

        private void LoadComboBoxInputLanThi(int? idMonHoc = null, string hinhThucThi = null)
        {
            cbbInputLanThi.DataSource = null;
            if (idMonHoc.HasValue && !string.IsNullOrEmpty(hinhThucThi))
            {
                cbbInputLanThi.DataSource = _lanThiService.GetAllLanThis()
                                      .Where(lt => lt.IdMonHoc == idMonHoc.Value && lt.HinhThucThi == hinhThucThi)
                                      .ToList();
            }
            cbbInputLanThi.DisplayMember = "LanThi1";
            cbbInputLanThi.ValueMember = "Id";
            cbbInputLanThi.SelectedIndex = -1;
        }

        private void CbbInputLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbInputLopHoc.SelectedValue is int idLop)
            {
                LoadComboBoxInputSinhVien(idLop);
            }
            else
            {
                LoadComboBoxInputSinhVien(null);
            }
        }

        private void CbbInputMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbInputMonHoc.SelectedValue is int idMonHoc)
            {
                LoadComboBoxInputHinhThucThi(idMonHoc);
                LoadComboBoxInputLanThi(idMonHoc);
            }
            else
            {
                cbbInputHinhThucThi.DataSource = null;
                LoadComboBoxInputLanThi();
            }
            cbbInputLanThi.SelectedIndex = -1;
        }

        private void CbbInputHinhThucThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbInputMonHoc.SelectedValue is int idMonHoc && cbbInputHinhThucThi.SelectedItem is string hinhThucThi)
            {
                LoadComboBoxInputLanThi(idMonHoc, hinhThucThi);
            }
            else
            {
                LoadComboBoxInputLanThi(cbbInputMonHoc.SelectedValue as int?);
            }
        }

        private bool ValidateInput()
        {
            if (cbbInputLopHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Lớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false;
            }

            if (cbbInputSinhVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Sinh Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false;
            }

            if (cbbInputMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputMonHoc.Focus();
                return false;
            }
            if (cbbInputHinhThucThi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Hình thức thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputHinhThucThi.Focus();
                return false;
            }

            if (cbbInputLanThi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Lần thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputLanThi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInputDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputDiem.Focus();
                return false;
            }

            if (!double.TryParse(txtInputDiem.Text, out _))
            {
                MessageBox.Show("Điểm phải là một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputDiem.Focus();
                return false;
            }
            return true;
        }

        private bool IsDuplicateDiem(int idSinhVien, int idLanThi, int? currentDiemId = null)
        {
            return _diemService.GetAllDiems().Any(d =>
                d.IdSinhVien == idSinhVien &&
                d.IdLanThi == idLanThi &&
                (!currentDiemId.HasValue || d.Id != currentDiemId.Value)
            );
        }

        private void ClearForm()
        {
            txtInputId.Clear();
            txtInputDiem.Clear();
            cbbInputSinhVien.SelectedIndex = -1;
            cbbInputMonHoc.SelectedIndex = -1;
            cbbInputHinhThucThi.DataSource = null;
            cbbInputHinhThucThi.SelectedIndex = -1;
            cbbInputLanThi.DataSource = null;
            cbbInputLanThi.SelectedIndex = -1;
            cbbInputLopHoc.SelectedIndex = -1;
        }

        public void SetForAdd()
        {
            _isAddingNew = true;
            _currentEditId = null;
            ClearForm();
            this.Text = "Thêm Điểm";
            btnSave.Text = "Thêm";
        }

        public void SetForEdit(int diemId)
        {
            _isAddingNew = false;
            _currentEditId = diemId;
            this.Text = "Sửa Điểm";
            btnSave.Text = "Cập nhật";
            LoadDiemData(diemId);
        }

        private async void LoadDiemData(int diemId)
        {
            var diem = _diemService.GetADiem(diemId);
            if (diem != null)
            {
                txtInputId.Text = diem.Id.ToString();
                txtInputDiem.Text = diem.Diem1.ToString();

                var sinhVien = _sinhVienService.GetAnSinhVien(diem.IdSinhVien);
                if (sinhVien != null)
                {
                    cbbInputLopHoc.SelectedValue = sinhVien.IdLop;
                    cbbInputSinhVien.SelectedValue = diem.IdSinhVien;
                }

                var lanThi = _lanThiService.GetALanThi(diem.IdLanThi);
                if (lanThi != null)
                {
                    cbbInputMonHoc.SelectedValue = lanThi.IdMonHoc;
                    LoadComboBoxInputHinhThucThi(lanThi.IdMonHoc);
                    cbbInputHinhThucThi.SelectedItem = lanThi.HinhThucThi;
                    LoadComboBoxInputLanThi(lanThi.IdMonHoc, lanThi.HinhThucThi);
                    cbbInputLanThi.SelectedValue = diem.IdLanThi;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            int idLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
            int idSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());

            if (IsDuplicateDiem(idSinhVien, idLanThi, _currentEditId))
            {
                MessageBox.Show("Điểm cho sinh viên này trong môn học và lần thi này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_isAddingNew)
            {
                try
                {
                    Diem diem = new()
                    {
                        IdLanThi = idLanThi,
                        IdSinhVien = idSinhVien,
                        Diem1 = double.Parse(txtInputDiem.Text),
                    };
                    _diemService.CreateADiem(diem);
                    MessageBox.Show("Thêm điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSaved?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (_currentEditId.HasValue)
                    {
                        Diem diem = _diemService.GetADiem(_currentEditId.Value);
                        if (diem != null)
                        {
                            diem.Diem1 = double.Parse(txtInputDiem.Text);
                            diem.IdLanThi = idLanThi;
                            diem.IdSinhVien = idSinhVien;
                            _diemService.UpdataADiem(diem);
                            MessageBox.Show("Sửa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataSaved?.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy điểm để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiemDetailForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}