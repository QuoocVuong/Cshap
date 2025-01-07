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
using QLDKhoa_CNTT.BLL;

namespace MAIN_UI
{
    public partial class ThemSuaNganhHoc : Form
    {

        private NganhHocService _nganhhocService = new();
        private KhoaHocService _khoaService = new();

        public event EventHandler DataSaved; // Tạo event

        public int? id { get; set; }
        public ThemSuaNganhHoc()
        {
            InitializeComponent();
        }

        private void ThemSuaNganhHoc_Load(object sender, EventArgs e)
        {
            // do toan bo khoa hoc vao combobox hoac dropdown
            cbbkhoa.DataSource = _khoaService.GetAllKhoaHocs();
            //giau het cot cua khoahoc chi show cot ten khoa hoc
            cbbkhoa.DisplayMember = "TenKhoa";// hien thi ten khoa ra ngoai combobox
            cbbkhoa.ValueMember = "Id"; //lay gia tri theo id

            //phan sua du lieu
            if (this.id != null)
            {
                // edit mode, hien thi data
                var nganhHoc = _nganhhocService.GetANganhHoc((int)id);
                txttennganh.Text = nganhHoc.TenNganhHoc;

                txtid.Text = nganhHoc.Id.ToString();
                txtid.Enabled = false;
                cbbkhoa.SelectedValue = nganhHoc.IdKhoa;
                label1.Text = "Chinh Sua Nganh Hoc";


                //cbbkhoa.SelectedValue = nganhHoc.IdKhoa;

            }
            txtid.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (id == null) // Thêm mới
            {
                QLDKhoa_CNTT.DAL.Entities.NganhHoc nganhHoc = new()

                {

                    TenNganhHoc = txttennganh.Text.Trim(),
                    IdKhoa = int.Parse(cbbkhoa.SelectedValue.ToString()),
                };
                _nganhhocService.AddANganhHoc(nganhHoc);
            }
            else // Cập nhật
            {
                QLDKhoa_CNTT.DAL.Entities.NganhHoc nganhHoc = _nganhhocService.GetANganhHoc((int)id); // Lấy ngành học cần cập nhật
                if (nganhHoc != null)
                {
                    nganhHoc.TenNganhHoc = txttennganh.Text.Trim();
                    nganhHoc.IdKhoa = int.Parse(cbbkhoa.SelectedValue.ToString());
                    _nganhhocService.UpdateANganhHoc(nganhHoc);
                }
            }
            this.Close();

            DataSaved?.Invoke(this, EventArgs.Empty); // Kích hoạt event sau khi lưu

            // ... other code (refresh DataGridView, etc.) ...
        }
    }
}
