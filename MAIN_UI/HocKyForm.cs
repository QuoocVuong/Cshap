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
    public partial class HocKyForm : Form
    {
        private HocKyService _hocKyService = new();
        private NamHocService _namHocService = new();

        public HocKyForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void HocKyForm_Load(object sender, EventArgs e)
        {
            LoadDataintoDataGripView();
            // do toan bo khoa hoc vao combobox hoac dropdown
            cbbNganhHoc.DataSource = _namHocService.GetAllNamHocs();
            //giau het cot cua khoahoc chi show cot ten khoa hoc
            cbbNganhHoc.DisplayMember = "TenNamHoc";// hien thi ten khoa ra ngoai combobox
            cbbNganhHoc.ValueMember = "Id"; //lay gia tri theo id
            txtidhocky.Enabled = false;
            txtTenHocKy.Enabled = false;
            cbbNganhHoc.Enabled = false;

        }
        private void LoadDataintoDataGripView()
        {

            var result = _hocKyService.GetAllHocKys();
            dgvHocKy.DataSource = null;
            dgvHocKy.DataSource = result;
            dgvHocKy.Columns["IdNamHocNavigation"].Visible = false;
            dgvHocKy.Columns["MonHocs"].Visible = false;
            //dgvHocKy.Columns["LopHocs"].Visible = false;
        }

        private void dgvHocKy_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocKy.CurrentRow != null && dgvHocKy.CurrentRow.DataBoundItem is HocKy hocKy)
            {
                txtidhocky.Text = hocKy.Id.ToString();
                txtTenHocKy.Text = hocKy.TenHocKy;
                cbbNganhHoc.SelectedValue = hocKy.IdNamHoc;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form
        }

        private void HocKyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem textbox có chứa giá trị hợp lệ không
            if (!int.TryParse(txtidhocky.Text, out int id))
            {
                MessageBox.Show("Mã Học Kỳ phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Tìm học kỳ dựa trên ID
                var hocKy = _hocKyService.GetAHocKy(id);

                if (hocKy == null)
                {
                    MessageBox.Show("Không tìm thấy học kỳ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa '{hocKy.TenHocKy}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _hocKyService.DeleteHocKy(id);
                    MessageBox.Show("Xóa học kỳ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataintoDataGripView(); // Load lại dữ liệu
                    txtidhocky.Clear();
                    txtTenHocKy.Clear();
                    cbbNganhHoc.SelectedIndex = -1; // Reset combobox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HocKyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // Chỉ xử lý khi người dùng nhấn dấu x
            {
                e.Cancel = true; // Ngăn đóng form mặc định
                this.Hide(); // Ẩn form
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaXoaHocKy themSuaXoaHocKy = new();
            themSuaXoaHocKy.DavaSaver += ThemSuaHocKy_DataSave;
            themSuaXoaHocKy.id = null;
            themSuaXoaHocKy.ShowDialog();
        }
        private void ThemSuaHocKy_DataSave(object sender, EventArgs e)
        {
            //sau khi them xong thi dong va reload lai gripdata
            LoadDataintoDataGripView();
            //dgvnganhhoclist.Columns["IdKhoaNavigation"].Visible = false;
            //dgvnganhhoclist.Columns["LopHocs"].Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtTenHocKy.Text) || !int.TryParse(txtidhocky.Text, out id))
            {
                MessageBox.Show("Hoc Ky is invalid", "Chon dong de sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //da co id roi thi dua du lieu
            ThemSuaXoaHocKy themSuaXoaHocKy = new();
            themSuaXoaHocKy.id = int.Parse(txtidhocky.Text);
            themSuaXoaHocKy.ShowDialog();
            //sau khi sua xong thi dong va reload lai gripdata
            LoadDataintoDataGripView();
        }
    }
}
