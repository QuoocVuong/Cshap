using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MAIN_UI
{
    public partial class LanThiForm : Form
    {
        public LanThiForm()
        {
            InitializeComponent();
        }

        private LanThiService lanThiService = new();
        private MonHocService monHocService = new();
        private bool isAddingNew = false;
        private int? selectedMonHoc = null;
        private int? idMonHocInput = null;
        private bool isEditing = false;
        private int? currentEditId = null;
        private void LanThiForm_Load(object sender, EventArgs e)
        {
            LoadComBoBoxFilter();
            LoadComBoBoxInput();

            dgvLanThi.CurrentCell = null;
            LoadDataIntoDataGridView();

            HideTextBoxInput();
            HideTextBoxOutput();

            cbbFilterByMonHoc.SelectedIndexChanged += CbbFilterByMonHoc_SelectedIndexChanged;


        }
        private void LoadComBoBoxInput()
        {
            monHocService = new();
            cbbInputMonHoc.DataSource = null;
            cbbInputMonHoc.DataSource = monHocService.GetAllMonHocs();
            cbbInputMonHoc.DisplayMember = "TenMonHoc";
            cbbInputMonHoc.ValueMember = "Id";
            cbbInputMonHoc.SelectedIndex = -1;
        }
        private void LoadComBoBoxFilter()
        {
            monHocService = new();
            List<MonHoc> monHocs = monHocService.GetAllMonHocs().ToList();
            monHocs.Insert(0, new MonHoc { Id = -1, TenMonHoc = "Tất Cả" });

            cbbFilterByMonHoc.DataSource = monHocs;
            cbbFilterByMonHoc.DisplayMember = "TenMonHoc";
            cbbFilterByMonHoc.ValueMember = "Id";
            cbbFilterByMonHoc.SelectedIndex = 0;

        }
        private void LoadDataIntoDataGridView()
        {
            dgvLanThi.SelectionChanged -= dgvLanThi_SelectionChanged;
            lanThiService = new();
            dgvLanThi.DataSource = null;
            dgvLanThi.DataSource = lanThiService.GetAllLanThis();
            dgvLanThi.CellFormatting += dgvLanThi_CellFormatting;
            ReNameAndHideCollumn();
            //dgvLanThi.SelectionChanged += dgvLanThi_SelectionChanged;

            // 1. Tạm thời gỡ bỏ sự kiện SelectionChanged
            //dgvLanThi.CurrentCell = null;

            // 2. Bỏ chọn tất cả các dòng
            dgvLanThi.ClearSelection();

            // 3. Gán lại sự kiện SelectionChanged
            dgvLanThi.SelectionChanged += dgvLanThi_SelectionChanged;

        }
        private void ReNameAndHideCollumn()
        {
            dgvLanThi.Columns["Id"].HeaderText = "ID";
            dgvLanThi.Columns["LanThi1"].HeaderText = "Lần Thi";
            dgvLanThi.Columns["NgayThi"].HeaderText = "Ngày Thi";
            dgvLanThi.Columns["IdMonHoc"].HeaderText = "Môn Học";
            dgvLanThi.Columns["Diems"].Visible = false;
            dgvLanThi.Columns["IdMonHocNavigation"].Visible = false;
            dgvLanThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void FilterDGVByMonHoc()
        {
            if (cbbFilterByMonHoc.SelectedIndex == 0 && cbbFilterByMonHoc.SelectedValue is int && (int)cbbFilterByMonHoc.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }
            if (cbbFilterByMonHoc.SelectedValue is int idMonHoc)
            {
                lanThiService = new();
                dgvLanThi.DataSource = lanThiService.GetAllLanThis().Where(mh => mh.IdMonHoc == idMonHoc).ToList();
                ReNameAndHideCollumn();
                dgvLanThi.CurrentCell = null;

                dgvLanThi_SelectionChanged(null, null);
            }
            else if (cbbFilterByMonHoc.SelectedValue is MonHoc monHoc)
            {
                lanThiService = new();
                dgvLanThi.DataSource = lanThiService.GetAllLanThis().Where(mh => mh.IdMonHoc == monHoc.Id).ToList();
                ReNameAndHideCollumn();
                selectedMonHoc = monHoc.Id;
                dgvLanThi.CurrentCell = null;
                //MakeBlankOfTextBox();
                dgvLanThi_SelectionChanged(null, null);
            }
        }
        private void dgvLanThi_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvLanThi.Columns["IdMonHoc"].Index && e.Value is int idMonHoc)
            {
                string tenMonHoc = monHocService.GetAllMonHocs().FirstOrDefault(hk => hk.Id == idMonHoc)?.TenMonHoc;
                e.Value = tenMonHoc ?? ""; // Hiển thị tên ngành hoặc chuỗi rỗng nếu không tìm thấy
                e.FormattingApplied = true; // Đánh dấu đã format
            }
        }
        private void HideTextBoxOutput()
        {
            txtOutputId.Enabled = false;
            txtOutputLanThi.Enabled = false;
            dtpOutputNgayThi.Enabled = false;
            txtOutputMonHoc.Enabled = false;
        }
        private void HideTextBoxInput()
        {
            txtInputId.Enabled = false;

        }
        private void dgvLanThi_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLanThi.CurrentRow != null && dgvLanThi.CurrentRow.DataBoundItem is LanThi lanThi)
            {
                txtOutputId.Text = lanThi.Id.ToString();
                txtOutputLanThi.Text = lanThi.LanThi1.ToString();
                dtpOutputNgayThi.Value = lanThi.NgayThi.ToDateTime(TimeOnly.MinValue);

                // Lấy đối tượng mon hoc
                monHocService = new();
                var monHoc = monHocService.GetAMonHoc(lanThi.IdMonHoc);
                if (monHoc != null)
                {
                    txtOutputMonHoc.Text = monHoc.TenMonHoc;
                }
                else
                {
                    txtOutputMonHoc.Text = string.Empty;
                }
            }
            else
            {
                MakeBlankOfTextBox();
            }
        }
        private void MakeBlankOfTextBox()
        {
            txtOutputId.Clear();
            txtOutputLanThi.Clear();
            txtOutputMonHoc.Clear();

        }
        private bool ValidateInput()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtInputLanThi.Text))
            {
                MessageBox.Show("Vui lòng nhập lan thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputLanThi.Focus();
                return false; // Thoát nếu không hợp lệ
            }


            if (cbbInputMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Mon học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputMonHoc.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            int idMonHoc;

            if (!int.TryParse(cbbInputMonHoc.SelectedValue.ToString(), out idMonHoc))
            {
                MessageBox.Show("Mon hoc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputMonHoc.Focus();
                return false; // Thoát nếu không hợp lệ
            }

            // Validate lần thi là số nguyên
            if (!int.TryParse(txtInputLanThi.Text, out int lanThi))
            {
                MessageBox.Show("Lần thi phải là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputLanThi.Focus();
                return false;
            }
            return true;
        }
        private void ClearInputTextbox()
        {
            txtInputId.Clear();
            txtInputLanThi.Clear();
            cbbInputMonHoc.SelectedIndex = -1;
        }
        private void CbbFilterByMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FilterDGVByMonHoc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            if (ValidateInput() == false) return;
            if (isAddingNew) // Thêm mới
            {
                try
                {
                    // lấy id ngành học
                    int idMonHoc = int.Parse(cbbInputMonHoc.SelectedValue.ToString());
                    idMonHocInput = idMonHoc;
                    LanThi lanThi = new()
                    {
                        LanThi1 = int.Parse(txtInputLanThi.Text.ToString()),
                        NgayThi = DateOnly.FromDateTime(dtpInputNgayThi.Value),
                        IdMonHoc = idMonHoc,
                    };
                    lanThiService.CreateALanThi(lanThi);

                    MessageBox.Show("Thêm lần thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FilterDGVByMonHoc();
                    isAddingNew = false;
                    //ClearInputTextbox();
                    if (idMonHocInput.HasValue) cbbFilterByMonHoc.SelectedValue = idMonHocInput;
                    //idHocKyInput = null;

                    //LoadDataIntoDataGridView();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Lần Thi Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEditing)
            {
                // Lấy thông tin lần thi
                lanThiService = new();
                LanThi lanThi = lanThiService.GetALanThi(id);

                if (lanThi == null)
                {
                    MessageBox.Show("Không Tìm Thấy Lần Thi Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đưa dữ liệu lên các ô input
                txtInputId.Text = lanThi.Id.ToString();
                txtInputLanThi.Text = lanThi.LanThi1.ToString();
                dtpInputNgayThi.Value = lanThi.NgayThi.ToDateTime(TimeOnly.MinValue);
                cbbInputMonHoc.SelectedValue = lanThi.IdMonHoc;


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
                if (!ValidateInput())
                {
                    return;
                }
                try
                {
                    lanThiService = new();
                    LanThi lanThi = lanThiService.GetALanThi((int)currentEditId);
                    if (lanThi == null)
                    {
                        MessageBox.Show("Không Tìm Thấy Lần Thi Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Cập nhật thông tin môn học
                    lanThi.LanThi1 = int.Parse(txtInputLanThi.Text);
                    lanThi.NgayThi = DateOnly.FromDateTime(dtpInputNgayThi.Value);
                    lanThi.IdMonHoc = int.Parse(cbbInputMonHoc.SelectedValue.ToString());

                    int? selectedValuedMonHoc = int.Parse(cbbInputMonHoc.SelectedValue.ToString());


                    // Gọi service để cập nhật
                    lanThiService.UpdataALanThi(lanThi);

                    MessageBox.Show("Sửa lần thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox(); // Xóa thông tin trong các ô input
                                         // Set the selected value for the filter combobox before filtering
                    if (selectedValuedMonHoc.HasValue)
                    {
                        cbbFilterByMonHoc.SelectedValue = selectedValuedMonHoc;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FilterDGVByMonHoc();
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
                MessageBox.Show("Vui Lòng Chọn Lần Thi Để Xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                lanThiService = new();
                var lanThi = lanThiService.GetALanThi(id);
                if (lanThi == null)
                {
                    MessageBox.Show("Không tìm thấy lần thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // co id roi bat dau xoa
                DialogResult result = MessageBox.Show($"Ban Co Chac Muon Xoa Lần Thi: {lanThi.LanThi1}.", "Xac Nhan Xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int? selectedValuedMonHoc = lanThi.IdMonHoc;
                    lanThiService.DeleteALanThi(id);
                    MessageBox.Show("Xoa Lần thi Thanh Cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //FillterDataGripByLops();
                    FilterDGVByMonHoc();
                    //if (cbbLocTheoLop.Items.Count > 0 && selectedValuedLops != null)
                    //{
                    cbbFilterByMonHoc.SelectedValue = selectedValuedMonHoc;
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
            cbbFilterByMonHoc.SelectedValue = -1;
            cbbInputMonHoc.SelectedValue = -1;
        }
    }
}