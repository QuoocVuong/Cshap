using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QLDKhoa_CNTT.DAL;

namespace MAIN_UI
{
    public partial class ReportForm : Form
    {
        private string _option;
        DbConnection dbConnection = new DbConnection();

        public ReportForm(string option)
        {
            InitializeComponent();
            _option = option;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (_option == "xdsd")
            {
                try
                {
                    reportViewer1.LocalReport.ReportPath = "C:\\CSharp\\QLDKHOA_CNTT\\MAIN_UI\\TotalReport.rdlc"; // Đảm bảo đường dẫn chính xác

                    // Lấy dữ liệu cho bảng Diem
                    string mainQuery = "SELECT\r\n    Diem.Diem,\r\n    SinhVien.MaSinhVien,\r\n    SinhVien.NgaySinh,\r\n    SinhVien.TenSinhVien,\r\n    LanThi.LanThi,\r\n    LanThi.NgayThi,\r\n    LanThi.HinhThucThi,\r\n    LopHoc.TenLop,\r\n    MonHoc.MaMonHoc,\r\n    MonHoc.TenMonHoc,\r\n    MonHoc.SoGio,\r\n    NganhHoc.TenNganhHoc,\r\n    HocKy.TenHocKy,\r\n    NamHoc.TenNamHoc,\r\n    Khoa.TenKhoa\r\nFROM\r\n    Diem\r\nINNER JOIN\r\n    SinhVien ON Diem.ID_SinhVien = SinhVien.ID\r\nINNER JOIN\r\n    LanThi ON Diem.ID_LanThi = LanThi.ID\r\nINNER JOIN\r\n    LopHoc ON SinhVien.ID_Lop = LopHoc.ID\r\nINNER JOIN\r\n    MonHoc ON LanThi.ID_MonHoc = MonHoc.ID\r\nINNER JOIN\r\n    NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID\r\nINNER JOIN\r\n    HocKy ON MonHoc.ID_HocKy = HocKy.ID\r\nINNER JOIN\r\n    NamHoc ON HocKy.ID_NamHoc = NamHoc.ID\r\nINNER JOIN\r\n    Khoa ON NganhHoc.ID_Khoa = Khoa.ID;";
                    DataTable mainData = dbConnection.load(mainQuery);
                    ReportDataSource diemDataSource = new ReportDataSource("TotalDataSet", mainData); // "DataSetDiem" phải trùng với tên dataset trong RDLC

                    
                    // Thêm tất cả các Data Source vào báo cáo
                    reportViewer1.LocalReport.DataSources.Clear(); // Xóa các datasource cũ nếu có
                    reportViewer1.LocalReport.DataSources.Add(diemDataSource);
                    

                    this.reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (_option == "xemdiem")
            {
                try
                {
                    reportViewer1.LocalReport.ReportPath = "C:\\CSharp\\QLDKHOA_CNTT\\MAIN_UI\\BangDiem.rdlc";
                    string diemQuery = "SELECT   ID_SinhVien, ID_LanThi, Diem FROM         Diem;";
                    DataTable mainData = dbConnection.load(diemQuery);
                    ReportDataSource bangDiemDataSource = new ReportDataSource("diemdataset", diemQuery); // "DataSetDiem" phải trùng với tên dataset trong RDLC


                    // Thêm tất cả các Data Source vào báo cáo
                    reportViewer1.LocalReport.DataSources.Clear(); // Xóa các datasource cũ nếu có
                    reportViewer1.LocalReport.DataSources.Add(bangDiemDataSource);


                    this.reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}