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
    public partial class MonHocForm : Form
    {
        public MonHocForm()
        {
            InitializeComponent();
        }
        private int? idHocKyInput = null;
        private int? selectedHocKy = null;
        private bool isAddingNew = false;
        private MonHocService monHocService = new();
        private HocKyService hocKyService = new();
        private void LoadComBoBoxInput()
        {
            hocKyService = new();
            cbbInputHocKy.DataSource = null;
            cbbInputHocKy.DataSource = hocKyService.GetAllHocKys();
            cbbInputHocKy.DisplayMember = "TenHocKy";
            cbbInputHocKy.ValueMember = "Id";
            cbbInputHocKy.SelectedIndex = -1;
        }
        private void LoadComBoBoxFilter()
        {
            hocKyService = new();
            List<HocKy> hocKy = hocKyService.GetAllHocKys().ToList();
            hocKy.Insert(0, new HocKy { Id = -1, TenHocKy = "Tất Cả" });

            cbbFilterByHocKy.DataSource = hocKy;
            cbbFilterByHocKy.DisplayMember = "TenHocKy";
            cbbFilterByHocKy.ValueMember = "Id";
            cbbFilterByHocKy.SelectedIndex = 0;

        }
        private void LoadDataIntoDataGripView()
        {
            //DgvMonHoc_SelectionChanged(null, null);
            dgvMonHoc.SelectionChanged -= DgvMonHoc_SelectionChanged;
            monHocService = new();
            dgvMonHoc.DataSource = null;
            dgvMonHoc.DataSource = monHocService.GetAllMonHocs();


            dgvMonHoc.CellFormatting += DgvMonHoc_CellFormatting;
            ReNameAndHideCollumn();
            //dgvMonHoc.SelectionChanged += DgvMonHoc_SelectionChanged;
            // 1. Tạm thời gỡ bỏ sự kiện SelectionChanged
            //dgvMonHoc.CurrentCell = null;

            // 2. Bỏ chọn tất cả các dòng
            dgvMonHoc.ClearSelection();

            // 3. Gán lại sự kiện SelectionChanged
            dgvMonHoc.SelectionChanged += DgvMonHoc_SelectionChanged;


        }

        private void DgvMonHoc_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow != null && dgvMonHoc.CurrentRow.DataBoundItem is MonHoc monHoc)
            {
                txtOutputId.Text = monHoc.Id.ToString();
                txtOutputMaMonHoc.Text = monHoc.MaMonHoc;
                txtOutputTenMonHoc.Text = monHoc.TenMonHoc;
                txtOutputSoGio.Text = monHoc.SoGio.ToString();
                // Lấy đối tượng hoc ky
                hocKyService = new();
                var hocKy = hocKyService.GetAHocKy(monHoc.IdHocKy);
                if (hocKy != null)
                {
                    txtOutputHocKy.Text = hocKy.TenHocKy; // Hiển thị tên hoc ki
                }
                else
                {
                    txtOutputHocKy.Text = string.Empty;
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
            txtOutputMaMonHoc.Clear();
            txtOutputTenMonHoc.Clear();
            txtOutputSoGio.Clear();
            txtOutputHocKy.Clear();

        }

        private void DgvMonHoc_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvMonHoc.Columns["IdHocKy"].Index && e.Value is int idHocKy)
            {
                // Tìm tên ngành học từ Id

                string tenHocKy = hocKyService.GetAllHocKys().FirstOrDefault(hk => hk.Id == idHocKy)?.TenHocKy;

                e.Value = tenHocKy ?? ""; // Hiển thị tên ngành hoặc chuỗi rỗng nếu không tìm thấy
                e.FormattingApplied = true; // Đánh dấu đã format
            }
        }

        private void HideTextBoxOutput()
        {
            txtOutputId.Enabled = false;
            txtOutputMaMonHoc.Enabled = false;
            txtOutputTenMonHoc.Enabled = false;
            txtOutputSoGio.Enabled = false;
            txtOutputHocKy.Enabled = false;
        }
        private void HideTextBoxInput()
        {
            txtInputId.Enabled = false;
        }
        private void ReNameAndHideCollumn()
        {
            dgvMonHoc.Columns["Id"].HeaderText = "ID";
            dgvMonHoc.Columns["MaMonHoc"].HeaderText = "Mã Môn Học";
            dgvMonHoc.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
            dgvMonHoc.Columns["SoGio"].HeaderText = "Số Giờ";
            dgvMonHoc.Columns["IdHocKy"].HeaderText = "Học Kỳ";
            dgvMonHoc.Columns["IdHocKyNavigation"].Visible = false;
            dgvMonHoc.Columns["LanThis"].Visible = false;
            dgvMonHoc.Columns["IdGiangViens"].Visible = false;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Lấp đầy toàn bộ DataGridView



        }
        private bool ValidateInput()
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtInputMaMonHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập Ma lớp học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputMaMonHoc.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (string.IsNullOrWhiteSpace(txtInputTenMonHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Mon học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputTenMonHoc.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (string.IsNullOrWhiteSpace(txtInputSoGio.Text))
            {
                MessageBox.Show("Vui lòng nhập so gio học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputSoGio.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            // Validate số giờ là số nguyên
            if (!int.TryParse(txtInputSoGio.Text, out int soGio))
            {
                MessageBox.Show("Số giờ phải là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputSoGio.Focus();
                return false;
            }

            if (cbbInputHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Hoc ky.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputHocKy.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            int idHocKy;

            if (!int.TryParse(cbbInputHocKy.SelectedValue.ToString(), out idHocKy))
            {
                MessageBox.Show("Học Ky không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputHocKy.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            return true;
        }
        private void ClearInputTextbox()
        {
            txtInputId.Clear();
            txtInputMaMonHoc.Clear();
            txtInputSoGio.Clear();
            txtInputTenMonHoc.Clear();
            cbbInputHocKy.SelectedIndex = -1;
        }
        private void FilterDGVByHocKy()
        {
            if (cbbFilterByHocKy.SelectedIndex == 0 && cbbFilterByHocKy.SelectedValue is int && (int)cbbFilterByHocKy.SelectedValue == -1)
            {
                LoadDataIntoDataGripView();
                return;
            }
            if (cbbFilterByHocKy.SelectedValue is int idHocKy)
            {
                monHocService = new();

                dgvMonHoc.DataSource = monHocService.GetAllMonHocs().Where(mh => mh.IdHocKy == idHocKy).ToList();
                ReNameAndHideCollumn();
                dgvMonHoc.CurrentCell = null;

                DgvMonHoc_SelectionChanged(null, null);
            }
            else if (cbbFilterByHocKy.SelectedValue is HocKy hocKy)
            {
                monHocService = new();

                dgvMonHoc.DataSource = monHocService.GetAllMonHocs().Where(mh => mh.IdHocKy == hocKy.Id).ToList();
                ReNameAndHideCollumn();

                selectedHocKy = hocKy.Id;
                dgvMonHoc.CurrentCell = null;
                //MakeBlankOfTextBox();
                DgvMonHoc_SelectionChanged(null, null);
            }
            dgvMonHoc.Columns["IdHocKyNavigation"].Visible = false;
            dgvMonHoc.Columns["LanThis"].Visible = false;
            dgvMonHoc.Columns["IdGiangViens"].Visible = false;
        }
        private void MonHocForm_Load(object sender, EventArgs e)
        {
            LoadComBoBoxFilter();
            LoadComBoBoxInput();
            cbbFilterByHocKy.SelectedIndexChanged += CbbFilterByHocKy_SelectedIndexChanged;
            dgvMonHoc.CurrentCell = null;
            LoadDataIntoDataGripView();

            HideTextBoxOutput();
            HideTextBoxInput();
            //// 1. Tạm thời gỡ bỏ sự kiện SelectionChanged
            //dgvMonHoc.SelectionChanged -= DgvMonHoc_SelectionChanged;

            //// 2. Bỏ chọn tất cả các dòng
            //dgvMonHoc.ClearSelection();

            //// 3. Gán lại sự kiện SelectionChanged
            //dgvMonHoc.SelectionChanged += DgvMonHoc_SelectionChanged;

        }

        private void CbbFilterByHocKy_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FilterDGVByHocKy();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            if (ValidateInput() == false) return;
            if (isAddingNew) // Thêm mới
            {
                try
                {
                    // lấy id ngành học
                    int idHocKy = int.Parse(cbbInputHocKy.SelectedValue.ToString());
                    idHocKyInput = idHocKy;
                    MonHoc monHoc = new()
                    {
                        MaMonHoc = txtInputMaMonHoc.Text.Trim(),
                        TenMonHoc = txtInputTenMonHoc.Text.Trim(),
                        SoGio = int.Parse(txtInputSoGio.Text.ToString()),
                        IdHocKy = idHocKy,

                    };
                    monHocService.CreateAMonHoc(monHoc);

                    MessageBox.Show("Thêm mon học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FilterDGVByHocKy();
                    isAddingNew = false;
                    //ClearInputTextbox();
                    if (idHocKyInput.HasValue) cbbFilterByHocKy.SelectedValue = idHocKyInput;
                    //idHocKyInput = null;

                    //LoadDataIntoDataGripView();
                }
            }
        }





        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGripView();
            MakeBlankOfTextBox();
            ClearInputTextbox();
            cbbFilterByHocKy.SelectedValue = -1;
            cbbInputHocKy.SelectedValue = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Mon Hoc Để Xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                monHocService = new();
                var monHoc = monHocService.GetAMonHoc(id);
                if (monHoc == null)
                {
                    MessageBox.Show("Không tìm thấy Sinh Vien.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // co id roi bat dau xoa
                DialogResult result = MessageBox.Show($"Ban Co Chac Muon Xoa Mon Hoc: {monHoc.TenMonHoc}.", "Xac Nhan Xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int? selectedValuedHocKy = monHoc.IdHocKy;
                    monHocService.DeleteAMonHoc(id);
                    MessageBox.Show("Xoa Mon Hoc Thanh Cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //FillterDataGripByLops();
                    FilterDGVByHocKy();
                    //if (cbbLocTheoLop.Items.Count > 0 && selectedValuedLops != null)
                    //{
                    cbbFilterByHocKy.SelectedValue = selectedValuedHocKy;
                    //}
                    MakeBlankOfTextBox();
                    //LoadDataIntoDataGripView();
                    //cbbFilterByHocKy.SelectedValue = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (!int.TryParse(txtOutputId.Text, out int id))
        //    {
        //        MessageBox.Show("Vui Lòng Chọn Mon Hoc Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        monHocService = new();
        //        MonHoc monHoc = monHocService.GetAMonHoc((int)id);
        //        if (monHoc == null)
        //        {
        //            MessageBox.Show("Không Tìm Thấy Môn Học Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        //txtInputId.Text = monHoc.Id.ToString();
        //        //txtInputMaMonHoc.Text = monHoc.MaMonHoc;
        //        //txtInputTenMonHoc.Text = monHoc.TenMonHoc;
        //        //txtInputSoGio.Text = monHoc.SoGio.ToString();
        //        //cbbInputHocKy.SelectedValue = monHoc.IdHocKy;

        //        //monHocService.UpdataAMonHoc(monHoc);

        //        // Cập nhật thông tin môn học
        //        monHoc.MaMonHoc = txtInputMaMonHoc.Text.Trim();
        //        monHoc.TenMonHoc = txtInputTenMonHoc.Text.Trim();
        //        monHoc.SoGio = int.Parse(txtInputSoGio.Text);
        //        monHoc.IdHocKy = int.Parse(cbbInputHocKy.SelectedValue.ToString());

        //        // Gọi service để cập nhật
        //        monHocService.UpdataAMonHoc(monHoc);

        //        MessageBox.Show("Sửa mon học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ClearInputTextbox();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Có lỗi xảy ra khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        FilterDGVByHocKy();
        //    }

        //}
        private bool isEditing = false; // Biến cờ để kiểm tra xem đang ở trạng thái sửa hay không
        private int? currentEditId = null; // Lưu ID của môn học đang chỉnh sửa

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Môn Học Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEditing) // Nếu chưa ở trạng thái sửa
            {
                // Lấy thông tin môn học
                monHocService = new();
                MonHoc monHoc = monHocService.GetAMonHoc(id);

                if (monHoc == null)
                {
                    MessageBox.Show("Không Tìm Thấy Môn Học Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đưa dữ liệu lên các ô input
                txtInputId.Text = monHoc.Id.ToString();
                txtInputMaMonHoc.Text = monHoc.MaMonHoc;
                txtInputTenMonHoc.Text = monHoc.TenMonHoc;
                txtInputSoGio.Text = monHoc.SoGio.ToString();
                cbbInputHocKy.SelectedValue = monHoc.IdHocKy;


                // Đặt trạng thái sửa và lưu ID
                isEditing = true;
                currentEditId = id;
                // Đổi text nút sửa để biết đang ở trạng thái edit
                btnSua.Text = "Cập nhật";
                btnXoa.Enabled = false;
                btnthem.Enabled = false;

                return; // Thoát khỏi hàm để chờ người dùng chỉnh sửa
            }
            else // Nếu đang ở trạng thái sửa
            {
                // Validate dữ liệu
                if (!ValidateInput())
                {
                    return;
                }
                try
                {
                    monHocService = new();
                    MonHoc monHoc = monHocService.GetAMonHoc((int)currentEditId);
                    if (monHoc == null)
                    {
                        MessageBox.Show("Không Tìm Thấy Môn Học Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // Cập nhật thông tin môn học
                    monHoc.MaMonHoc = txtInputMaMonHoc.Text.Trim();
                    monHoc.TenMonHoc = txtInputTenMonHoc.Text.Trim();
                    monHoc.SoGio = int.Parse(txtInputSoGio.Text);
                    monHoc.IdHocKy = int.Parse(cbbInputHocKy.SelectedValue.ToString());

                    int? selectedValuedHocKy = int.Parse(cbbInputHocKy.SelectedValue.ToString());



                    // Gọi service để cập nhật
                    monHocService.UpdataAMonHoc(monHoc);

                    MessageBox.Show("Sửa môn học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputTextbox(); // Xóa thông tin trong các ô input

                    // Set the selected value for the filter combobox before filtering
                    if (selectedValuedHocKy.HasValue)
                    {
                        cbbFilterByHocKy.SelectedValue = selectedValuedHocKy;
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FilterDGVByHocKy(); // Load lại dữ liệu vào DataGridView sau khi sửa
                    isEditing = false;
                    currentEditId = null;
                    btnSua.Text = "Sửa";
                    btnXoa.Enabled = true;
                    btnthem.Enabled = true;
                    //if (cbbInputHocKy.SelectedValue != null && int.TryParse(cbbInputHocKy.SelectedValue.ToString(), out int idHocKy))
                    //{
                    //    // set filter by học kỳ theo input sau khi update
                    //    cbbFilterByHocKy.SelectedValue = idHocKy;
                    //    FilterDGVByHocKy();
                    //}
                    //else
                    //{
                    //    // Nếu ko có học kỳ thì load lại toàn bộ data
                    //    LoadDataIntoDataGripView();
                    //}
                    FilterDGVByHocKy();
                }

            }
        }
    }
}
