using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MAIN_UI
{
    public partial class DiemForm : Form
    {
        private DiemService diemService = new();
        private LanThiService lanThiService = new();
        private SinhVienService sinhVienService = new();
        private bool isAddingNew = false;
        private int? idLanThiInput = null;
        private int? idSinhVienInput = null;
        private bool isEditing = false;
        private int? currentEditId = null;

        public DiemForm()
        {
            InitializeComponent();
        }

        #region Load Data
        private void DiemForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            InitializeDataGridView();
            HideTextBoxInput();
            HideTextBoxOutput();
            SetupEventHandlers();
        }
        private void LoadComboBoxes()
        {
            LoadComboBoxInputSinhVien();
            LoadComboBoxInputLanThi();
            LoadComboBoxFilterSinhVien();
            LoadComboBoxFilterLanThi();
        }
        private void LoadComboBoxInputSinhVien()
        {
            sinhVienService = new();
            cbbInputSinhVien.DataSource = null;
            cbbInputSinhVien.DataSource = sinhVienService.GetAllSinhVien();
            cbbInputSinhVien.DisplayMember = "TenSinhVien";
            cbbInputSinhVien.ValueMember = "Id";
            cbbInputSinhVien.SelectedIndex = -1;
        }
        private void LoadComboBoxInputLanThi()
        {
            lanThiService = new();
            cbbInputLanThi.DataSource = null;
            cbbInputLanThi.DataSource = lanThiService.GetAllLanThis();
            cbbInputLanThi.DisplayMember = "LanThi1";
            cbbInputLanThi.ValueMember = "Id";
            cbbInputLanThi.SelectedIndex = -1;
        }
        private void LoadComboBoxFilterSinhVien()
        {
            sinhVienService = new();
            List<SinhVien> sinhViens = sinhVienService.GetAllSinhVien().ToList();
            sinhViens.Insert(0, new SinhVien { Id = -1, TenSinhVien = "Tất Cả" });
            cbbFilterBySinhVien.DataSource = sinhViens;
            cbbFilterBySinhVien.DisplayMember = "TenSinhVien";
            cbbFilterBySinhVien.ValueMember = "Id";
            cbbFilterBySinhVien.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterLanThi()
        {
            lanThiService = new();
            List<LanThi> lanThis = lanThiService.GetAllLanThis().ToList();
            lanThis.Insert(0, new LanThi { Id = -1, LanThi1 = 0 , NgayThi = DateOnly.FromDateTime(DateTime.Now) });
            cbbFilterByLanThi.DataSource = lanThis;
            cbbFilterByLanThi.DisplayMember = "LanThi1";
            cbbFilterByLanThi.ValueMember = "Id";
            cbbFilterByLanThi.SelectedIndex = 0;

        }
        private void InitializeDataGridView()
        {
            dgvDiem.SelectionChanged -= dgvDiem_SelectionChanged;
            dgvDiem.DataSource = null;
            LoadDataIntoDataGridView();
            dgvDiem.CellFormatting += dgvDiem_CellFormatting;
            ReNameAndHideCollumn();
            dgvDiem.ClearSelection();
            dgvDiem.SelectionChanged += dgvDiem_SelectionChanged;
        }
        private void LoadDataIntoDataGridView()
        {
            diemService = new();
            dgvDiem.DataSource = diemService.GetAllDiems();
        }
        private void ReNameAndHideCollumn()
        {
            dgvDiem.Columns["Id"].HeaderText = "ID";
            dgvDiem.Columns["IdSinhVien"].HeaderText = "Sinh Viên";
            dgvDiem.Columns["IdLanThi"].HeaderText = "Lần Thi";
            dgvDiem.Columns["Diem1"].HeaderText = "Điểm";
            dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Lấp đầy toàn bộ DataGridView
        }
        private void SetupEventHandlers()
        {
            cbbFilterByLanThi.SelectedIndexChanged += CbbFilterByLanThi_SelectedIndexChanged;
            cbbFilterBySinhVien.SelectedIndexChanged += CbbFilterBySinhVien_SelectedIndexChanged;
        }
        #endregion

        #region Filter Data
        private void CbbFilterByLanThi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FilterDGVByLanThi();
        }
        private void CbbFilterBySinhVien_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FilterDGVBySinhVien();
        }
        private void FilterDGVByLanThi()
        {
            if (cbbFilterByLanThi.SelectedIndex == 0 && cbbFilterByLanThi.SelectedValue is int && (int)cbbFilterByLanThi.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }
            if (cbbFilterByLanThi.SelectedValue is int idLanThi)
            {
                diemService = new();
                dgvDiem.DataSource = diemService.GetAllDiems().Where(mh => mh.IdLanThi == idLanThi).ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }
            else if (cbbFilterByLanThi.SelectedValue is LanThi lanThi)
            {
                diemService = new();
                dgvDiem.DataSource = diemService.GetAllDiems().Where(mh => mh.IdLanThi == lanThi.Id).ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }
            dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
        }
        private void FilterDGVBySinhVien()
        {
            if (cbbFilterBySinhVien.SelectedIndex == 0 && cbbFilterBySinhVien.SelectedValue is int && (int)cbbFilterBySinhVien.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }
            if (cbbFilterBySinhVien.SelectedValue is int idSinhVien)
            {
                diemService = new();
                dgvDiem.DataSource = diemService.GetBySinhVien(idSinhVien);
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);

            }
            else if (cbbFilterBySinhVien.SelectedValue is SinhVien sinhVien)
            {
                diemService = new();
                dgvDiem.DataSource = diemService.GetBySinhVien(sinhVien.Id);
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }
            dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            dgvDiem.Columns["IdLanThiNavigation"].Visible = false;

        }
        #endregion

        #region Handle DataGridView Event
        private void dgvDiem_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvDiem.Columns["IdSinhVien"].Index && e.Value is int idSinhVien)
            {

                string tenSinhVien = sinhVienService.GetAllSinhVien().FirstOrDefault(hk => hk.Id == idSinhVien)?.TenSinhVien;

                e.Value = tenSinhVien ?? ""; // Hiển thị tên ngành hoặc chuỗi rỗng nếu không tìm thấy
                e.FormattingApplied = true; // Đánh dấu đã format
            }
            if (e.ColumnIndex == dgvDiem.Columns["IdLanThi"].Index && e.Value is int idLanThi)
            {
                string tenLanThi = lanThiService.GetAllLanThis().FirstOrDefault(hk => hk.Id == idLanThi)?.LanThi1.ToString();

                e.Value = tenLanThi ?? ""; // Hiển thị tên ngành hoặc chuỗi rỗng nếu không tìm thấy
                e.FormattingApplied = true; // Đánh dấu đã format
            }
        }
        private void dgvDiem_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow != null && dgvDiem.CurrentRow.DataBoundItem is Diem diem)
            {
                txtOutputId.Text = diem.Id.ToString();
                txtOutputDiem.Text = diem.Diem1.ToString();


                // Lấy đối tượng lan thi
                lanThiService = new();
                var lanThi = lanThiService.GetALanThi(diem.IdLanThi);
                if (lanThi != null)
                {
                    txtOutputLanThi.Text = lanThi.LanThi1.ToString();
                }
                else
                {
                    txtOutputLanThi.Text = string.Empty;
                }
                // Lấy đối tượng sinh vien
                sinhVienService = new();
                var sinhVien = sinhVienService.GetAnSinhVien(diem.IdSinhVien);
                if (sinhVien != null)
                {
                    txtOutputSinhVien.Text = sinhVien.TenSinhVien;
                }
                else
                {
                    txtOutputSinhVien.Text = string.Empty;
                }
            }
            else
            {
                MakeBlankOfTextBox();
            }
        }

        #endregion

        #region Handle TextBox, Clear Textbox
        private void HideTextBoxOutput()
        {
            txtOutputId.Enabled = false;
            txtOutputDiem.Enabled = false;
            txtOutputSinhVien.Enabled = false;
            txtOutputLanThi.Enabled = false;

        }
        private void HideTextBoxInput()
        {
            txtInputId.Enabled = false;

        }
        private void MakeBlankOfTextBox()
        {
            txtOutputId.Clear();
            txtOutputDiem.Clear();
            txtOutputSinhVien.Clear();
            txtOutputLanThi.Clear();

        }
        private void ClearInputTextbox()
        {
            txtInputId.Clear();
            txtInputDiem.Clear();
            cbbInputSinhVien.SelectedIndex = -1;
            cbbInputLanThi.SelectedIndex = -1;
        }
        #endregion

        #region Validate Input
        private bool ValidateInput()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtInputDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputDiem.Focus();
                return false; // Thoát nếu không hợp lệ
            }


            if (cbbInputSinhVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Sinh Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            int idSinhVien;

            if (!int.TryParse(cbbInputSinhVien.SelectedValue.ToString(), out idSinhVien))
            {
                MessageBox.Show("Sinh Viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (cbbInputLanThi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Lần thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputLanThi.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            int idLanThi;
            if (!int.TryParse(cbbInputLanThi.SelectedValue.ToString(), out idLanThi))
            {
                MessageBox.Show("Lần thi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputLanThi.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            // Validate điểm là số thực
            if (!double.TryParse(txtInputDiem.Text, out double diem))
            {
                MessageBox.Show("Điểm phải là một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputDiem.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Handle Button
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            if (ValidateInput() == false) return;
            if (isAddingNew) // Thêm mới
            {
                try
                {
                    // lấy id
                    int idLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
                    int idSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());
                    idLanThiInput = idLanThi;
                    idSinhVienInput = idSinhVien;
                    Diem diem = new()
                    {
                        IdLanThi = idLanThi,
                        IdSinhVien = idSinhVien,
                        Diem1 = double.Parse(txtInputDiem.Text),

                    };
                    diemService.CreateADiem(diem);

                    MessageBox.Show("Thêm điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FilterDGVByLanThi();
                    FilterDGVBySinhVien();
                    isAddingNew = false;
                    //ClearInputTextbox();
                    if (idLanThiInput.HasValue) cbbFilterByLanThi.SelectedValue = idLanThiInput;
                    if (idSinhVienInput.HasValue) cbbFilterBySinhVien.SelectedValue = idSinhVienInput;
                    //LoadDataIntoDataGridView();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isEditing)
            {
                // Lấy thông tin lần thi
                diemService = new();
                Diem diem = diemService.GetADiem(id);

                if (diem == null)
                {
                    MessageBox.Show("Không Tìm Thấy Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đưa dữ liệu lên các ô input
                txtInputId.Text = diem.Id.ToString();
                txtInputDiem.Text = diem.Diem1.ToString();
                cbbInputLanThi.SelectedValue = diem.IdLanThi;
                cbbInputSinhVien.SelectedValue = diem.IdSinhVien;


                // Đặt trạng thái sửa và lưu ID
                isEditing = true;
                currentEditId = id;
                // Đổi text nút sửa để biết đang ở trạng thái edit
                btnSua.Text = "Cập nhật";
                btnXoa.Enabled = false;
                btnThem.Enabled = false;

                return; // Thoát khỏi hàm để chờ người dùng chỉnh sửa
            }
            else
            {
                // Validate dữ liệu
                if (!ValidateInput())
                {
                    return;
                }
                try
                {
                    diemService = new();
                    Diem diem = diemService.GetADiem((int)currentEditId);
                    if (diem == null)
                    {
                        MessageBox.Show("Không Tìm Thấy Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Cập nhật thông tin điểm
                    diem.Diem1 = double.Parse(txtInputDiem.Text);
                    diem.IdLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
                    diem.IdSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());
                    int? selectedValuedLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
                    int? selectedValuedSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());

                    // Gọi service để cập nhật
                    diemService.UpdataADiem(diem);

                    MessageBox.Show("Sửa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox(); // Xóa thông tin trong các ô input
                                         // Set the selected value for the filter combobox before filtering
                    if (selectedValuedLanThi.HasValue)
                    {
                        cbbFilterByLanThi.SelectedValue = selectedValuedLanThi;
                    }
                    if (selectedValuedSinhVien.HasValue)
                    {
                        cbbFilterBySinhVien.SelectedValue = selectedValuedSinhVien;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FilterDGVByLanThi();
                    FilterDGVBySinhVien();
                    isEditing = false;
                    currentEditId = null;
                    btnSua.Text = "Sửa";
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Điểm Để Xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                diemService = new();
                var diem = diemService.GetADiem(id);
                if (diem == null)
                {
                    MessageBox.Show("Không tìm thấy điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin sinh viên
                var sinhVien = sinhVienService.GetAnSinhVien(diem.IdSinhVien);
                string tenSinhVien = sinhVien?.TenSinhVien ?? "Unknown";

                // co id roi bat dau xoa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa điểm {diem.Diem1} của sinh viên: {tenSinhVien} ?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int? selectedValuedLanThi = diem.IdLanThi;
                    int? selectedValuedSinhVien = diem.IdSinhVien;

                    diemService.DeleteADiem(id);
                    MessageBox.Show("Xoa điểm Thanh Cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //FillterDataGripByLops();
                    FilterDGVByLanThi();
                    FilterDGVBySinhVien();
                    //if (cbbLocTheoLop.Items.Count > 0 && selectedValuedLops != null)
                    //{
                    cbbFilterByLanThi.SelectedValue = selectedValuedLanThi;
                    cbbFilterBySinhVien.SelectedValue = selectedValuedSinhVien;
                    //}
                    MakeBlankOfTextBox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            MakeBlankOfTextBox();
            ClearInputTextbox();
            cbbFilterByLanThi.SelectedValue = -1;
            cbbFilterBySinhVien.SelectedValue = -1;
            cbbInputLanThi.SelectedValue = -1;
            cbbInputSinhVien.SelectedValue = -1;
        }
        #endregion
    }
}