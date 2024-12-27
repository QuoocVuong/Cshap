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
    public partial class SinhVienForm : Form
    {
        private SinhVienService _sinhVienservice;
        private LopHocService _lopHocService = new();
        private int? _selectedLops = null;
        public SinhVienForm()
        {
            InitializeComponent();
        }

        private void SinhVienForm_Load(object sender, EventArgs e)
        {

            // Load dữ liệu cho ComboBox trước
            List<LopHoc> lopHocs = _lopHocService.GetAllLopHocs().ToList();

            lopHocs.Insert(0, new LopHoc { Id = -1, TenLop = "Tất Cả" });

            cbbLocTheoLop.DataSource = lopHocs;
            cbbLocTheoLop.DisplayMember = "TenLop";
            cbbLocTheoLop.ValueMember = "Id";
            cbbLocTheoLop.SelectedIndexChanged += CbbLocTheoLop_SelectedIndexChanged;
            cbbLocTheoLop.SelectedIndex = 0;

            // Sau khi ComboBox đã có dữ liệu, mới load dữ liệu vào DataGridView
            dgvSinhVien.CurrentCell = null; // Đặt CurrentCell = null TRƯỚC khi load dữ liệu
            LoadDataInToDataGripViewLopHoc();
            txtId.Enabled = false;
            txtTenSinhVien.Enabled = false;
            txtMaSinhVien.Enabled = false;
            txtLop.Enabled = false;
            dtpNgaySinh.Enabled = false;

        }

        private void CbbLocTheoLop_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FillterDataGripByLops();
        }

        private void LoadDataInToDataGripViewLopHoc()
        {
            // huy chon de lay du lieu vao textbox truoc khi load du lieu
            dgvSinhVien.SelectionChanged -= dgvSinhVien_SelectionChanged;
            // tien hanh load
            _sinhVienservice = new();
            var result = _sinhVienservice.GetAllSinhVien();
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = result;
            //da load xong
            //doi ten va an cot
            ReNameAndHideCollumn();
            //dang ky su kien hien thi ten lop o idlop
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
            // tien hanh bo chon mac dinh cua datagrip
            dgvSinhVien.CurrentCell = null;

            //co the su dong dong duoi cung duoc
            //dgvSinhVien_SelectionChanged(null, null);

            //dang ky chon de lay du lieu vao textbox
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;

        }
        private void ReNameAndHideCollumn()
        {
            dgvSinhVien.Columns["Id"].HeaderText = "ID";
            dgvSinhVien.Columns["MaSinhVien"].HeaderText = "Mã Sinh Viên";
            dgvSinhVien.Columns["TenSinhVien"].HeaderText = "Tên Sinh Viên";
            dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvSinhVien.Columns["IdLop"].HeaderText = "Lớp";
            dgvSinhVien.Columns["IdLopNavigation"].Visible = false;
            dgvSinhVien.Columns["Diems"].Visible = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Lấp đầy toàn bộ DataGridView
            //Bỏ chọn sau khi load data
            dgvSinhVien.CurrentCell = null;
        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvSinhVien.Columns["IdLop"].Index && e.Value is int idLop)
            {
                // Tìm tên ngành học từ Id
                _lopHocService = new();
                string tenLop = _lopHocService.GetAllLopHocs().FirstOrDefault(lh => lh.Id == idLop)?.TenLop;

                e.Value = tenLop ?? ""; // Hiển thị tên ngành hoặc chuỗi rỗng nếu không tìm thấy
                e.FormattingApplied = true; // Đánh dấu đã format
            }
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow != null && dgvSinhVien.CurrentRow.DataBoundItem is SinhVien sinhVien)
            {
                txtId.Text = sinhVien.Id.ToString();
                txtMaSinhVien.Text = sinhVien.MaSinhVien;
                txtTenSinhVien.Text = sinhVien.TenSinhVien;
                if (sinhVien.NgaySinh is DateOnly ngaySinh)
                {
                    DateTime dateTimeValue = ngaySinh.ToDateTime(TimeOnly.MinValue); // Chuyển về DateTime
                    if (dateTimeValue >= dtpNgaySinh.MinDate && dateTimeValue <= dtpNgaySinh.MaxDate)
                    {
                        dtpNgaySinh.Value = dateTimeValue; // Gán nếu ngày hợp lệ
                    }
                    else
                    {
                        dtpNgaySinh.Value = dtpNgaySinh.MinDate; //Gán giá trị min nếu không hợp lệ
                    }

                }
                else
                {
                    // Đảm bảo rằng DateTime.Now là hợp lệ
                    if (DateTime.Now >= dtpNgaySinh.MinDate && DateTime.Now <= dtpNgaySinh.MaxDate)
                    {
                        dtpNgaySinh.Value = DateTime.Now; // Gán nếu ngày hợp lệ
                    }
                    else
                    {
                        dtpNgaySinh.Value = dtpNgaySinh.MinDate; //Gán min nếu không hợp lệ
                    }

                }





                // Lấy đối tượng NganhHoc

                var lopHoc = _lopHocService.GetALopHoc(sinhVien.IdLop);
                if (lopHoc != null)
                {
                    txtLop.Text = lopHoc.TenLop; // Hiển thị tên ngành
                }
                else
                {
                    txtLop.Text = string.Empty;
                }
            }
            else
            {
                MakeBlankOfTextBox();
            }
        }
        private void FillterDataGripByLops()
        {
            if (cbbLocTheoLop.SelectedIndex == 0 && cbbLocTheoLop.SelectedValue is int && (int)cbbLocTheoLop.SelectedValue == -1)
            {
                LoadDataInToDataGripViewLopHoc();
                return;
            }
            if (int.TryParse(cbbLocTheoLop.SelectedValue?.ToString(), out int idLop))
            {
                //var result = _sinhVienservice.GetAllSinhVien().Where(sv => sv.IdLop == idLop).ToList();
                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = _sinhVienservice.GetAllSinhVien().Where(sv => sv.IdLop == idLop).ToList();
                ReNameAndHideCollumn();
                dgvSinhVien.CurrentCell = null;
                //MakeBlankOfTextBox();
                dgvSinhVien_SelectionChanged(null, null);
            }
            else if (cbbLocTheoLop.SelectedValue is LopHoc lopHoc)
            {
                var result = _sinhVienservice.GetAllSinhVien().Where(sv => sv.IdLop == lopHoc.Id).ToList();
                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = result;
                ReNameAndHideCollumn();
                _selectedLops = lopHoc.Id;
                dgvSinhVien.CurrentCell = null;
                //MakeBlankOfTextBox();
                dgvSinhVien_SelectionChanged(null, null);
            }
            dgvSinhVien.Columns["IdLopNavigation"].Visible = false;
            dgvSinhVien.Columns["Diems"].Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void MakeBlankOfTextBox()
        {
            txtId.Clear();
            txtLop.Clear();
            txtMaSinhVien.Clear();
            txtTenSinhVien.Clear();
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataInToDataGripViewLopHoc();
            cbbLocTheoLop.SelectedValue = -1;
            MakeBlankOfTextBox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Sinh Vien Để Xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var sinhVien = _sinhVienservice.GetAnSinhVien(id);
                if (sinhVien == null)
                {
                    MessageBox.Show("Không tìm thấy Sinh Vien.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // co id roi bat dau xoa
                DialogResult result = MessageBox.Show($"Ban Co Chac Muon Xoa Sinh Vien: {sinhVien.TenSinhVien}.", "Xac Nhan Xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    object selectedValuedLops = cbbLocTheoLop.SelectedValue;
                    _sinhVienservice.DeleteAnSinhVien(id);
                    MessageBox.Show("Xoa Sinh Vien Thanh Cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillterDataGripByLops();
                    if (cbbLocTheoLop.Items.Count > 0 && selectedValuedLops != null)
                    {
                        cbbLocTheoLop.SelectedValue = selectedValuedLops;
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
            ThemSuaSinhVien themSuaSinhVien = new();
            themSuaSinhVien.DataSaved += ThemSuaSinhVien_DataSaved;
            themSuaSinhVien.id = null;
            if (_selectedLops.HasValue && _selectedLops != -1)
            {
                themSuaSinhVien.SelecedValueLops = _selectedLops;
            }
            themSuaSinhVien.ShowDialog();
        }

        private void ThemSuaSinhVien_DataSaved(object? sender, ThemSuaSinhVien.DataSavedEventArgs e)
        {
            object selectedValue = e.SelecedValueLops;
            FillterDataGripByLops();
            if (cbbLocTheoLop.Items.Count > 0 && selectedValue != null)
            {
                cbbLocTheoLop.SelectedValue = selectedValue;
            }
            MakeBlankOfTextBox();

        }

        private void Sua_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtMaSinhVien.Text) || !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Lop Hoc is invalid", "Chon dong de sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ThemSuaSinhVien themSuaSinhVien = new();
            themSuaSinhVien.id = int.Parse(txtId.Text);
            themSuaSinhVien.DataSaved += ThemSuaSinhVien_DataSaved;
           
            if (_selectedLops.HasValue && _selectedLops != -1)
            {
                themSuaSinhVien.SelecedValueLops = _selectedLops;
            }
            themSuaSinhVien.ShowDialog();
        }
    }

}
