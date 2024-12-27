using QLDKhoa_CNTT.BLL;
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
    public partial class KhoaHoc : Form
    {
        private KhoaHocService _service = new KhoaHocService();

        public KhoaHoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form
        }

        private void KhoaHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void KhoaHoc_Load(object sender, EventArgs e)
        {
            var result = _service.GetAllKhoaHocs();

            dgvKhoaHocList.DataSource = null;// xoa luoi day ds moi
            dgvKhoaHocList.DataSource = result;
            dgvKhoaHocList.Columns["NganhHocs"].Visible = false;// an cot nganhghocs

        }

        private void KhoaHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // Chỉ xử lý khi người dùng nhấn dấu x
            {
                e.Cancel = true; // Ngăn đóng form mặc định
                this.Hide(); // Ẩn form
            }
        }

        //private void dgvKhoaHocLis_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvKhoaHocList.SelectedRows.Count > 0)
        //    {
        //        var selectdKhoaHoc = (QLDKhoa_CNTT.DAL.Entities.KhoaHoc)dgvKhoaHocList.SelectedRows[0].DataBoundItem;
        //        // vi bi trung ten nen dung la QLDKhoa_CNTT_Repository.Entities.NganhHoc 
        //        //neu khong trung ten chi can khai bao lop NganhHoc la duoc

        //        txttenkhoa.Text = selectdKhoaHoc.TenKhoa;





        //    }
        //}
        private void dgvKhoaHocLis_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoaHocList.CurrentRow != null && dgvKhoaHocList.CurrentRow.DataBoundItem is Khoa khoa)
            {
                txtIdKhoa.Text = khoa.Id.ToString();
                txttenkhoa.Text = khoa.TenKhoa;
            }
            
        }
        private void btnxoatenkhoa_Click(object sender, EventArgs e)
        {
            //int id;
            //if (string.IsNullOrWhiteSpace(txttenkhoa.Text) || !int.TryParse(txtIdKhoa.Text, out id))
            //{
            //    MessageBox.Show("Khoa Hoc is required", "Ten Khoa Hoc required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //_service.DeletedKhoaHoc(id);

            //var result = _service.GetAllKhoaHocs();
            //dgvKhoaHocList.DataSource = null;
            //dgvKhoaHocList.DataSource = result;


            // Kiểm tra xem textbox có chứa giá trị hợp lệ không
            if (!int.TryParse(txtIdKhoa.Text, out int id))
            {
                MessageBox.Show("Vui long chon khoa can xoa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Tìm học kỳ dựa trên ID
                var khoas = _service.GetAllKhoaHocs();

                if (khoas == null)
                {
                    MessageBox.Show("Không tìm thấy khoa .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa '?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _service.DeletedKhoaHoc(id);
                    MessageBox.Show("Xóa học kỳ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataKhoaHoc(); // Load lại dữ liệu
                    txtIdKhoa.Clear();
                    txttenkhoa.Clear();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        //private void btnxoatenkhoa_Click(object sender, EventArgs e)
        //{
        //    if (dgvKhoaHocList.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Please select a Khoa Hoc to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    var selectedKhoaHoc = (QLDKhoa_CNTT.DAL.Entities.KhoaHoc)dgvKhoaHocList.SelectedRows[0].DataBoundItem;
        //    int id = selectedKhoaHoc.Id; // Get the ID from the selected row


        //    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete Khoa Hoc: {selectedKhoaHoc.TenKhoa}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            _service.DeletedKhoaHoc(id);
        //            // Refresh the DataGridView after successful deletion
        //            var result = _service.GetAllKhoaHocs();
        //            dgvKhoaHocList.DataSource = null;
        //            dgvKhoaHocList.DataSource = result;

        //            // Clear the textbox after deletion
        //            txttenkhoa.Clear();


        //            MessageBox.Show("Khoa Hoc deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        }
        //        catch (Exception ex) // Catch potential exceptions during deletion
        //        {
        //            MessageBox.Show($"Error deleting Khoa Hoc: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //}

        private void LoadDataKhoaHoc()
        {
            var result = _service.GetAllKhoaHocs();
            dgvKhoaHocList.DataSource = null;
            dgvKhoaHocList.DataSource = result;
            dgvKhoaHocList.Columns["NganhHocs"].Visible = false;
        }
    }
}
