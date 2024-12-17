using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.BLL;
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
    public partial class NganhHoc : Form
    {
        private NganhHocService _nganhHocService = new NganhHocService();
        private KhoaHocService _khoaService = new KhoaHocService();

        public NganhHoc()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form
        }

        private void NganhHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void NganhHoc_Load(object sender, EventArgs e)
        {
            var result = _nganhHocService.GetAllNganhHocs();
            dgvnganhhoclist.DataSource = null;
            dgvnganhhoclist.DataSource = result;
            dgvnganhhoclist.Columns["HocKies"].Visible = false;
            dgvnganhhoclist.Columns["IdKhoaNavigation"].Visible = false;
            dgvnganhhoclist.Columns["LopHocs"].Visible = false;
            // do toan bo khoa hoc vao combobox hoac dropdown
            cbbkhoa.DataSource = _khoaService.GetAllKhoaHocs();
            //giau het cot cua khoahoc chi show cot ten khoa hoc
            cbbkhoa.DisplayMember = "TenKhoa";// hien thi ten khoa ra ngoai combobox
            cbbkhoa.ValueMember = "Id"; //lay gia tri theo id
            txtIdNganhHoc.Enabled = false;
            txtnganhhoc.Enabled = false;
            txtTimKiem.Enabled = false;


        }

        //private void dgvnganhhoclist_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvnganhhoclist.SelectedRows.Count > 0)
        //    {
        //        var selectdNganhHoc = (QLDKhoa_CNTT.DAL.Entities.NganhHoc)dgvnganhhoclist.SelectedRows[0].DataBoundItem;// vi bi trung ten nen dung la QLDKhoa_CNTT_Repository.Entities.NganhHoc 
        //                                                                                                                //neu khong trung ten chi can khai bao lop NganhHoc la duoc

        //        txtnganhhoc.Text = selectdNganhHoc.TenNganhHoc;
        //        txtIdNganhHoc.Text = selectdNganhHoc.Id.ToString();


        //        cbbkhoa.SelectedValue = selectdNganhHoc.IdKhoa;

        //    }
        //}
        private void dgvnganhhoclist_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvnganhhoclist.CurrentRow != null && dgvnganhhoclist.CurrentRow.DataBoundItem is QLDKhoa_CNTT.DAL.Entities.NganhHoc nganhHoc)
            {
                txtnganhhoc.Text = nganhHoc.TenNganhHoc;
                txtIdNganhHoc.Text = nganhHoc.Id.ToString();
                cbbkhoa.SelectedValue = nganhHoc.IdKhoa;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                MessageBox.Show("The search key is required", "Search key required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = _nganhHocService.SearchNganhHocs(txtTimKiem.Text.Trim());

            dgvnganhhoclist.DataSource = null;
            dgvnganhhoclist.DataSource = result;

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            int id;
            if (string.IsNullOrWhiteSpace(txtIdNganhHoc.Text) || !int.TryParse(txtIdNganhHoc.Text, out id))
            {
                MessageBox.Show("Nganh Hoc is required", "Ten Nganh Hoc required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _nganhHocService.DeletedNganhHoc(id);

            var result = _nganhHocService.GetAllNganhHocs();
            dgvnganhhoclist.DataSource = null;
            dgvnganhhoclist.DataSource = result;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            int id;
            if (string.IsNullOrWhiteSpace(txtIdNganhHoc.Text) || !int.TryParse(txtIdNganhHoc.Text, out id))
            {
                MessageBox.Show("Nganh Hoc is invalid", "Chon dong de sua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //da co id roi thi dua du lieu
            ThemSuaNganhHoc themSuaNganhHoc = new ThemSuaNganhHoc();
            themSuaNganhHoc.id = int.Parse(txtIdNganhHoc.Text);
            themSuaNganhHoc.ShowDialog();
            //sau khi sua xong thi dong va reload lai gripdata
            var result = _nganhHocService.GetAllNganhHocs();
            dgvnganhhoclist.DataSource = null;
            dgvnganhhoclist.DataSource = result;
            dgvnganhhoclist.Columns["HocKies"].Visible = false;
            dgvnganhhoclist.Columns["IdKhoaNavigation"].Visible = false;
            dgvnganhhoclist.Columns["LopHocs"].Visible = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            ThemSuaNganhHoc themSuaNganhHoc = new ThemSuaNganhHoc();

            themSuaNganhHoc.DataSaved += ThemSuaNganhHoc_DataSaved; // Đăng ký event

            themSuaNganhHoc.id = null;
            themSuaNganhHoc.ShowDialog();
            ////sau khi them xong thi dong va reload lai gripdata
            //var result = _nganhHocService.GetAllNganhHocs();
            //dgvnganhhoclist.DataSource = null;
            //dgvnganhhoclist.DataSource = result;
            //dgvnganhhoclist.Columns["HocKies"].Visible = false;
            //dgvnganhhoclist.Columns["IdKhoaNavigation"].Visible = false;
            //dgvnganhhoclist.Columns["LopHocs"].Visible = false;

        }
        private void ThemSuaNganhHoc_DataSaved(object sender, EventArgs e)
        {
            //sau khi them xong thi dong va reload lai gripdata
            var result = _nganhHocService.GetAllNganhHocs();
            dgvnganhhoclist.DataSource = null;
            dgvnganhhoclist.DataSource = result;
            dgvnganhhoclist.Columns["HocKies"].Visible = false;
            dgvnganhhoclist.Columns["IdKhoaNavigation"].Visible = false;
            dgvnganhhoclist.Columns["LopHocs"].Visible = false;
        }

        private void NganhHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // Chỉ xử lý khi người dùng nhấn dấu x
            {
                e.Cancel = true; // Ngăn đóng form mặc định
                this.Hide(); // Ẩn form
            }
        }
    }
}
