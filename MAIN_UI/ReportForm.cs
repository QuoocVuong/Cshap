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
                    reportViewer1.LocalReport.ReportPath = "C:\\CSharp\\QLDKHOA_CNTT\\MAIN_UI\\BaoCaoDiem.rdlc"; // Đảm bảo đường dẫn chính xác

                    // Lấy dữ liệu cho bảng Diem
                    string diemQuery = "SELECT\r\n    Diem.ID AS Diem_ID,\r\n    Diem.Diem AS Diem_SoDiem,\r\n    SinhVien.MaSinhVien AS SinhVien_MaSV,\r\n    SinhVien.TenSinhVien AS SinhVien_TenSV,\r\n    SinhVien.NgaySinh AS SinhVien_NgaySinh,\r\n    LopHoc.TenLop AS LopHoc_TenLop,\r\n    NganhHoc.TenNganh AS NganhHoc_TenNganh,\r\n    Khoa.TenKhoa AS Khoa_TenKhoa,\r\n    LanThi.LanThi AS LanThi_LanThi,\r\n    MonHoc.TenMonHoc AS MonHoc_TenMonHoc,\r\n    HocKy.TenHocKy AS HocKy_TenHocKy,\r\n    NamHoc.TenNamHoc AS NamHoc_TenNamHoc\r\nFROM\r\n    Diem\r\nINNER JOIN\r\n    SinhVien ON Diem.ID_SinhVien = SinhVien.ID\r\nINNER JOIN\r\n    LopHoc ON SinhVien.ID_Lop = LopHoc.ID\r\nINNER JOIN\r\n    NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID\r\nINNER JOIN\r\n    Khoa ON NganhHoc.ID_Khoa = Khoa.ID\r\nINNER JOIN\r\n    LanThi ON Diem.ID_LanThi = LanThi.ID\r\nINNER JOIN\r\n    MonHoc ON LanThi.ID_MonHoc = MonHoc.ID\r\nINNER JOIN\r\n    HocKy ON MonHoc.ID_HocKy = HocKy.ID\r\nINNER JOIN\r\n    NamHoc ON HocKy.ID_NamHoc = NamHoc.ID;";
                    DataTable diemData = dbConnection.load(diemQuery);
                    ReportDataSource diemDataSource = new ReportDataSource("DataSetDiem", diemData); // "DataSetDiem" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng SinhVien
                    string sinhVienQuery = "SELECT ID, MaSinhVien, TenSinhVien, NgaySinh, ID_Lop FROM SinhVien;";
                    DataTable sinhVienData = dbConnection.load(sinhVienQuery);
                    ReportDataSource sinhVienDataSource = new ReportDataSource("DataSetSinhVien", sinhVienData); // "DataSetSinhVien" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng LanThi
                    string lanThiQuery = "SELECT ID, LanThi, NgayThi, ID_MonHoc, HinhThucThi FROM LanThi;";
                    DataTable lanThiData = dbConnection.load(lanThiQuery);
                    ReportDataSource lanThiDataSource = new ReportDataSource("DataSetLanThi", lanThiData); // "DataSetLanThi" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng MonHoc
                    string monHocQuery = "SELECT ID, MaMonHoc, TenMonHoc, SoGio, ID_HocKy FROM MonHoc;";
                    DataTable monHocData = dbConnection.load(monHocQuery);
                    ReportDataSource monHocDataSource = new ReportDataSource("DataSetMonHoc", monHocData); // "DataSetMonHoc" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng LopHoc
                    string lopHocQuery = "SELECT ID, TenLop, ID_Nganh FROM LopHoc;";
                    DataTable lopHocData = dbConnection.load(lopHocQuery);
                    ReportDataSource lopHocDataSource = new ReportDataSource("DataSetLopHoc", lopHocData); // "DataSetLopHoc" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng NganhHoc
                    string nganhHocQuery = "SELECT ID, TenNganhHoc, ID_Khoa FROM NganhHoc;";
                    DataTable nganhHocData = dbConnection.load(nganhHocQuery);
                    ReportDataSource nganhHocDataSource = new ReportDataSource("DataSetNganhHoc", nganhHocData); // "DataSetNganhHoc" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng Khoa
                    string khoaQuery = "SELECT ID, TenKhoa FROM Khoa;";
                    DataTable khoaData = dbConnection.load(khoaQuery);
                    ReportDataSource khoaDataSource = new ReportDataSource("DataSetKhoa", khoaData); // "DataSetKhoa" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng HocKy
                    string hocKyQuery = "SELECT ID, TenHocKy, ID_NamHoc FROM HocKy;";
                    DataTable hocKyData = dbConnection.load(hocKyQuery);
                    ReportDataSource hocKyDataSource = new ReportDataSource("DataSetHocKy", hocKyData); // "DataSetHocKy" phải trùng với tên dataset trong RDLC

                    // Lấy dữ liệu cho bảng NamHoc
                    string namHocQuery = "SELECT ID, TenNamHoc FROM NamHoc;";
                    DataTable namHocData = dbConnection.load(namHocQuery);
                    ReportDataSource namHocDataSource = new ReportDataSource("DataSetNamHoc", namHocData); // "DataSetNamHoc" phải trùng với tên dataset trong RDLC

                    // Thêm tất cả các Data Source vào báo cáo
                    reportViewer1.LocalReport.DataSources.Clear(); // Xóa các datasource cũ nếu có
                    reportViewer1.LocalReport.DataSources.Add(diemDataSource);
                    reportViewer1.LocalReport.DataSources.Add(sinhVienDataSource);
                    reportViewer1.LocalReport.DataSources.Add(lanThiDataSource);
                    reportViewer1.LocalReport.DataSources.Add(monHocDataSource);
                    reportViewer1.LocalReport.DataSources.Add(lopHocDataSource);
                    reportViewer1.LocalReport.DataSources.Add(nganhHocDataSource);
                    reportViewer1.LocalReport.DataSources.Add(khoaDataSource);
                    reportViewer1.LocalReport.DataSources.Add(hocKyDataSource);
                    reportViewer1.LocalReport.DataSources.Add(namHocDataSource);

                    this.reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (_option == "xdsdtheomon")
            {
                // Xử lý cho tùy chọn "xdsdtheomon" nếu cần
            }
        }
    }
}