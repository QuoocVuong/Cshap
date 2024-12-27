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
    public partial class ThemSuaLopHoc : Form
    {
        public ThemSuaLopHoc()
        {
            InitializeComponent();
        }
        private NganhHocService nganhHocService = new();
        private LopHocService lopHocService = new LopHocService();
        public event EventHandler<DataSavedEventArgs> DataSaved;
        public int? id { get; set; }
        public int? selectedNganhId { get; set; }
        public class DataSavedEventArgs : EventArgs
        {
            public int? SelectedNganhId { get; set; }
        }

        private void ThemSuaLopHoc_Load(object sender, EventArgs e)
        {
            // do toan bo khoa hoc vao combobox hoac dropdown
            cbbNganhHoc.DataSource = nganhHocService.GetAllNganhHocs();
            //giau het cot cua khoahoc chi show cot ten khoa hoc
            cbbNganhHoc.DisplayMember = "TenNganhHoc";// hien thi ten khoa ra ngoai combobox
            cbbNganhHoc.ValueMember = "Id"; //lay gia tri theo id

            //phan sua du lieu
            if (this.id != null)
            {
               
                // edit mode, hien thi data
                var lopHoc = lopHocService.GetALopHoc((int)id);
                txtTenLop.Text = lopHoc.TenLop;

                txtId.Text = lopHoc.Id.ToString();
                txtId.Enabled = false;
                cbbNganhHoc.SelectedValue = lopHoc.IdNganh;
                label1.Text = "Chinh Sua Lop Hoc";


                //cbbkhoa.SelectedValue = nganhHoc.IdKhoa;

            }
            else
            {
                cbbNganhHoc.SelectedIndex = -1; //Bỏ chọn item trong combobox khi thêm mới
                label1.Text = "Them Lop Hoc Moi";
                txtId.Enabled = false;
            }
            if (selectedNganhId.HasValue && selectedNganhId != -1)
            {
                cbbNganhHoc.SelectedValue = selectedNganhId;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLop.Focus();
                return; // Thoát nếu không hợp lệ
            }

            if (cbbNganhHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ngành học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbNganhHoc.Focus();
                return; // Thoát nếu không hợp lệ
            }
            int idNganh;

            if (!int.TryParse(cbbNganhHoc.SelectedValue.ToString(), out idNganh))
            {
                MessageBox.Show("Ngành học không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbNganhHoc.Focus();
                return; // Thoát nếu không hợp lệ
            }


            try
            {
                
                if (this.id == null) // Thêm mới
                {
                    LopHoc lopHoc = new()

                    {

                        TenLop = txtTenLop.Text.Trim(),
                        IdNganh = idNganh
                    };
                    lopHocService.AddALopHoc(lopHoc);
                    MessageBox.Show("Thêm lớp học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Cập nhật
                {

                    LopHoc lopHoc = lopHocService.GetALopHoc((int)id); 
                    if (lopHoc != null)
                    {
                        lopHoc.TenLop = txtTenLop.Text.Trim();
                        lopHoc.IdNganh = idNganh;
                        lopHoc.Id = Int32.Parse(lopHoc.Id.ToString());

                        lopHocService.UpdataALopHoc(lopHoc);
                        MessageBox.Show("Cập nhật lớp học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                DataSaved?.Invoke(this, new DataSavedEventArgs { SelectedNganhId = idNganh }); // Kích hoạt event sau khi lưu
                this.Close();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

