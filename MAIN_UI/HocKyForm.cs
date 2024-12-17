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
        private NganhHocService _nganhHocService = new();

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
            cbbNganhHoc.DataSource = _nganhHocService.GetAllNganhHocs();
            //giau het cot cua khoahoc chi show cot ten khoa hoc
            cbbNganhHoc.DisplayMember = "TenNganhHoc";// hien thi ten khoa ra ngoai combobox
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
            dgvHocKy.Columns["HinhThucs"].Visible = false;
            dgvHocKy.Columns["IdNganhHocNavigation"].Visible = false;
            //dgvHocKy.Columns["LopHocs"].Visible = false;
        }

        private void dgvHocKy_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocKy.CurrentRow != null && dgvHocKy.CurrentRow.DataBoundItem is HocKy hocKy)
            {
                txtidhocky.Text = hocKy.Id.ToString();
                txtTenHocKy.Text = hocKy.TenHocKy;
                cbbNganhHoc.SelectedValue = hocKy.IdNganhHoc;
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
            int id = int.Parse(txtidhocky.Text); // Lấy mã sản phẩm từ textbox.
            string tenHocKy = txtTenHocKy.Text;

            if (string.IsNullOrWhiteSpace(txtTenHocKy.Text) || !int.TryParse(txtidhocky.Text, out id)) // Kiểm tra mã sản phẩm có rỗng hay không.
            {
                MessageBox.Show("Mã Hoc Ky là bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Hiển thị hộp thoại xác nhận xóa.
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa '{tenHocKy}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn Yes.
                {
                    if (_hocKyService.DeleteHocKy(id)) // Gọi hàm XoaSanPham trong SanPhamBUS để xóa sản phẩm.
                    {
                        MessageBox.Show("Xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataintoDataGripView(); // Load lại dữ liệu sau khi xóa.
                        txtidhocky.Text = ""; // Xóa trắng các textbox.
                        txtTenHocKy.Text = "";
                        cbbNganhHoc.SelectedValue = "";
                    }
                    else
                    {
                        MessageBox.Show("Xóa hoc ky thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // Nếu người dùng chọn No, không làm gì cả.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hoc ky: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
