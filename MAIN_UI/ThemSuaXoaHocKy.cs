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
    public partial class ThemSuaXoaHocKy : Form
    {
        public ThemSuaXoaHocKy()
        {
            InitializeComponent();
        }
        private NamHocService namHocService = new();
        private HocKyService hocKyService = new();
        public event EventHandler DavaSaver;
        public int? id { get; set; }

        private void ThemSuaXoaHocKy_Load(object sender, EventArgs e)
        {
            // do toan bo khoa hoc vao combobox hoac dropdown
            cbbNamHoc.DataSource = namHocService.GetAllNamHocs();
            //giau het cot cua khoahoc chi show cot ten khoa hoc
            cbbNamHoc.DisplayMember = "TenNamHoc";// hien thi ten khoa ra ngoai combobox
            cbbNamHoc.ValueMember = "Id"; //lay gia tri theo id

            //phan sua du lieu
            if (this.id != null)
            {
                // edit mode, hien thi data
                var hocKy = hocKyService.GetAHocKy((int)id);
                txtTenHocKy.Text = hocKy.TenHocKy;

                txtid.Text = hocKy.Id.ToString();
                txtid.Enabled = false;
                cbbNamHoc.SelectedValue = hocKy.IdNamHoc;
                label1.Text = "Chinh Sua hoc Ky";


                //cbbkhoa.SelectedValue = nganhHoc.IdKhoa;

            }
            label1.Text = "Them hoc Ky ";
            txtid.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (id == null) // Thêm mới
            {
                HocKy hocKy = new()

                {

                    TenHocKy = txtTenHocKy.Text.Trim(),
                    IdNamHoc = int.Parse(cbbNamHoc.SelectedValue.ToString()),
                };
                hocKyService.AddHocKy(hocKy);
            }
            else // Cập nhật
            {
                HocKy hocKy = hocKyService.GetAHocKy((int)id); // Lấy ngành học cần cập nhật
                if (hocKy != null)
                {
                    hocKy.TenHocKy = txtTenHocKy.Text.Trim();
                    hocKy.IdNamHoc = int.Parse(cbbNamHoc.SelectedValue.ToString());
                    hocKyService.UpdateAHocKy(hocKy);
                }
            }
            this.Close();

            DavaSaver?.Invoke(this, EventArgs.Empty); // Kích hoạt event sau khi lưu


        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
