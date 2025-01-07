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
    public partial class LopHocForm : Form
    {
        public LopHocForm()
        {
            InitializeComponent();
        }
        private LopHocService lopHocService = new();
        private NganhHocService nganhHocService = new NganhHocService();
        private int? _selectedNganhId = null; // Biến để lưu ID ngành đã chọn
        private void LopHocForm_Load(object sender, EventArgs e)
        {
            // Tạo một danh sách mới để thêm mục "Tất cả"
            List<QLDKhoa_CNTT.DAL.Entities.NganhHoc> nganhHocs = nganhHocService.GetAllNganhHocs().ToList();
            nganhHocs.Insert(0, new QLDKhoa_CNTT.DAL.Entities.NganhHoc { Id = -1, TenNganhHoc = "Tất cả" }); // Giá trị Id = -1 đại diện cho "Tất cả"

            cbbLocNganhHoc.DataSource = nganhHocs; // Gán danh sách mới cho DataSource
            cbbLocNganhHoc.DisplayMember = "TenNganhHoc";
            cbbLocNganhHoc.ValueMember = "Id";
            cbbLocNganhHoc.SelectedIndexChanged += cbbLocNganhHoc_SelectedIndexChanged;
            cbbLocNganhHoc.SelectedIndex = 0; // Chọn "Tất cả" làm mặc định

            //// Khởi tạo cbbNganhHocLop
            //cbbNganhHoc.DataSource = nganhHocService.GetAllNganhHocs();
            //cbbNganhHoc.DisplayMember = "TenNganhHoc";
            //cbbNganhHoc.ValueMember = "Id";
            //cbbNganhHoc.SelectedIndex = -1; // Bỏ chọn combobox khi load form



            dgvLopHoc.CurrentCell = null; // Đặt CurrentCell = null TRƯỚC khi load dữ liệu

            LoadInToDGVLop();






            txtIdLop.Enabled = false;
            txtTenLop.Enabled = false;
            txtTenNganhHoc.Enabled = false;

        }

        private void FilterDataGridView()
        {
            if (cbbLocNganhHoc.SelectedIndex == 0 && cbbLocNganhHoc.SelectedValue is int && (int)cbbLocNganhHoc.SelectedValue == -1) // Kiểm tra "Tất cả" bằng Id
            {
                LoadInToDGVLop(); // Tải tất cả dữ liệu nếu không có gì được chọn
                _selectedNganhId = -1;
                return; // Thoát sớm để tránh các kiểm tra không cần thiết
            }

            // Kiểm tra xem giá trị được chọn có phải là int (Id của NganhHoc) không
            if (int.TryParse(cbbLocNganhHoc.SelectedValue?.ToString(), out int idNganh))
            {
                var result = lopHocService.GetAllLopHocs().Where(lh => lh.IdNganh == idNganh).ToList();
                dgvLopHoc.DataSource = null;
                dgvLopHoc.DataSource = result;
                ChangeNameOfColumn();
                //LoadInToDGVLop();
                dgvLopHoc.CurrentCell = null;
                dgvLopHoc_SelectionChanged(null, null);
            }
            else
            {
                // Xử lý trường hợp SelectedValue không phải là int (ví dụ: một đối tượng NganhHoc đầy đủ)
                if (cbbLocNganhHoc.SelectedValue is QLDKhoa_CNTT.DAL.Entities.NganhHoc nganhHoc)
                {
                    var result = lopHocService.GetAllLopHocs().Where(lh => lh.IdNganh == nganhHoc.Id).ToList();
                    dgvLopHoc.DataSource = null;
                    dgvLopHoc.DataSource = result;
                    ChangeNameOfColumn();
                    _selectedNganhId = nganhHoc.Id;
                    dgvLopHoc.CurrentCell = null;
                    dgvLopHoc_SelectionChanged(null, null);
                }
                else
                {
                    // Xử lý các trường hợp không mong muốn hoặc ghi lại lỗi
                    MessageBox.Show("Kiểu giá trị không mong muốn trong cbbLocNganhHoc");
                    LoadInToDGVLop(); // Hoặc tải lại tất cả dữ liệu
                }
            }

            dgvLopHoc.Columns["IdNganhNavigation"].Visible = false;
            dgvLopHoc.Columns["SinhViens"].Visible = false;
        }

        private void LoadInToDGVLop()
        {
            // Tạm thời bỏ đăng ký sự kiện để tránh việc nó kích hoạt khi gán DataSource
            dgvLopHoc.SelectionChanged -= dgvLopHoc_SelectionChanged;

            var result = lopHocService.GetAllLopHocs();
            dgvLopHoc.DataSource = null;
            dgvLopHoc.DataSource = result;

            dgvLopHoc.CellFormatting += dgvLopHoc_CellFormatting; // Đăng ký sự kiện
            ChangeNameOfColumn();
            //dgvLopHoc.Columns["IdNganhNavigation"].Visible = false;
            //dgvLopHoc.Columns["SinhViens"].Visible = false;
            dgvLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Lấp đầy toàn bộ DataGridView
            //Bỏ chọn sau khi load data
            dgvLopHoc.CurrentCell = null;


            // Đăng ký lại sự kiện SelectionChanged
            dgvLopHoc.SelectionChanged += dgvLopHoc_SelectionChanged;
        }
        private void ChangeNameOfColumn()
        {
            dgvLopHoc.Columns["Id"].HeaderText = "Mã Lớp";
            dgvLopHoc.Columns["TenLop"].HeaderText = "Tên Lớp Học";
            dgvLopHoc.Columns["IdNganh"].HeaderText = "Tên Ngành Học";
            dgvLopHoc.Columns["IdNganhNavigation"].Visible = false;
            dgvLopHoc.Columns["SinhViens"].Visible = false;
        }
        private void dgvLopHoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvLopHoc.Columns["IdNganh"].Index && e.Value is int idNganh)
            {
                // Tìm tên ngành học từ Id
                string tenNganh = nganhHocService.GetAllNganhHocs().FirstOrDefault(n => n.Id == idNganh)?.TenNganhHoc;

                e.Value = tenNganh ?? ""; // Hiển thị tên ngành hoặc chuỗi rỗng nếu không tìm thấy
                e.FormattingApplied = true; // Đánh dấu đã format
            }

        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow != null && dgvLopHoc.CurrentRow.DataBoundItem is LopHoc lopHoc)
            {
                txtIdLop.Text = lopHoc.Id.ToString();
                txtTenLop.Text = lopHoc.TenLop;

                //txtTenNganhHoc.Text = lopHoc.IdNganh.ToString();

                // Lấy đối tượng NganhHoc
                var nganhHoc = nganhHocService.GetANganhHoc(lopHoc.IdNganh);
                if (nganhHoc != null)
                {
                    txtTenNganhHoc.Text = nganhHoc.TenNganhHoc; // Hiển thị tên ngành
                }
                else
                {
                    txtTenNganhHoc.Text = string.Empty;
                }
            }
            else
            {
                txtIdLop.Text = string.Empty; // Xóa nội dung textbox IdLop
                txtTenLop.Text = string.Empty; // Xóa nội dung textbox TenLop
                //txtTenNganhHoc.Text = string.Empty;
                //cbbNganhHoc.SelectedIndex = -1; // Reset combobox NganhHoc
            }
        }

        private void cbbLocNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem textbox có chứa giá trị hợp lệ không
            if (!int.TryParse(txtIdLop.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Lớp Để Xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Tìm học kỳ dựa trên ID
                var lopHoc = lopHocService.GetALopHoc(id);

                if (lopHoc == null)
                {
                    MessageBox.Show("Không tìm thấy Lớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Lớp :'{lopHoc.TenLop}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    object selectedValue = cbbLocNganhHoc.SelectedValue;
                    lopHocService.DeleteALopHoc(id);
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FilterDataGridView();

                    if (cbbLocNganhHoc.Items.Count > 0 && selectedValue != null)
                    {
                        cbbLocNganhHoc.SelectedValue = selectedValue;
                    }
                    MakeBlankOfTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            //LoadInToDGVLop();
            //MakeBlankOfTextBox();

            //cbbLocNganhHoc.SelectedValue = -1;
            object selectedValue = cbbLocNganhHoc.SelectedValue;
            FilterDataGridView();
            if (cbbLocNganhHoc.Items.Count > 0 && selectedValue != null)
            {
                cbbLocNganhHoc.SelectedValue = selectedValue;
            }
            MakeBlankOfTextBox();

        }
        private void MakeBlankOfTextBox()
        {
            txtIdLop.Text = string.Empty; // Xóa nội dung textbox IdLop
            txtTenLop.Text = string.Empty; // Xóa nội dung textbox TenLop
            txtTenNganhHoc.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //ThemSuaLopHoc themSuaLopHoc = new();
            //themSuaLopHoc.DataSaved += ThemSuaLopHoc_DataSaved;
            //themSuaLopHoc.id = null;
            //themSuaLopHoc.ShowDialog();
            ThemSuaLopHoc themSuaLopHoc = new();
            themSuaLopHoc.DataSaved += ThemSuaLopHoc_DataSaved;
            themSuaLopHoc.id = null;
            if (_selectedNganhId.HasValue && _selectedNganhId != -1)
            {
                themSuaLopHoc.selectedNganhId = _selectedNganhId;
            }
            themSuaLopHoc.ShowDialog();
        }

        private void ThemSuaLopHoc_DataSaved(object? sender, /*EventArgs e*/  ThemSuaLopHoc.DataSavedEventArgs e)
        {
            //object selectedValue = cbbLocNganhHoc.SelectedValue;
            //FilterDataGridView();

            //if (cbbLocNganhHoc.Items.Count > 0 && selectedValue != null)
            //{
            //    cbbLocNganhHoc.SelectedValue = selectedValue;
            //}
            //MakeBlankOfTextBox();
            object selectedValue = e.SelectedNganhId;
            FilterDataGridView();
            if (cbbLocNganhHoc.Items.Count > 0 && selectedValue != null)
            {
                cbbLocNganhHoc.SelectedValue = selectedValue;
            }

            MakeBlankOfTextBox();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtTenLop.Text) || !int.TryParse(txtIdLop.Text, out id))
            {
                MessageBox.Show("Lop Hoc is invalid", "Chon dong de sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ////da co id roi thi dua du lieu
            //ThemSuaLopHoc themSuaLopHoc = new();
            //themSuaLopHoc.id = int.Parse(txtIdLop.Text);
            //themSuaLopHoc.DataSaved += ThemSuaLopHoc_DataSaved;
            //themSuaLopHoc.ShowDialog();
            ////sau khi sua xong thi dong va reload lai gripdata
            /////da co id roi thi dua du lieu
            ThemSuaLopHoc themSuaLopHoc = new();
            themSuaLopHoc.id = int.Parse(txtIdLop.Text);
            themSuaLopHoc.DataSaved += ThemSuaLopHoc_DataSaved;
            if (_selectedNganhId.HasValue && _selectedNganhId != -1)
            {
                themSuaLopHoc.selectedNganhId = _selectedNganhId;
            }
            themSuaLopHoc.ShowDialog();
            //sau khi sua xong thi dong va reload lai gripdata

        }
    }
}
