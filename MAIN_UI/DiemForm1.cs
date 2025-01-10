using QLDKhoa_CNTT.BLL;
using QLDKhoa_CNTT.BLL.Services;
using QLDKhoa_CNTT.DAL;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace MAIN_UI
{
    public partial class DiemForm1 : Form
    {

        private readonly QuanLyDiemKhoaCnttContext _dbContext;
        private readonly HocKyService _hockyService;

       

        private readonly NamHocService _namHocService;
        private readonly UserRoleService _userRoleService;
        private readonly RolePermissionService _rolePermissionService;
        private int _currentUserId;
        private readonly UserService _userService;
        private readonly DiemService _diemService;
        private readonly LanThiService _lanThiService;
        private readonly SinhVienService _sinhVienService;
        private readonly MonHocService _monHocService;
        private readonly LopHocService _lopHocService;
        private readonly NganhHocService _nganhHocService;
        private List<string> userPermissions = new List<string>();

        public DiemForm1(
            QuanLyDiemKhoaCnttContext dbContext,
            int currentUserId, 
            UserService userService, 
            DiemService diemService, 
            LanThiService lanThiService, 
            SinhVienService sinhVienService, 
            MonHocService monHocService, 
            LopHocService lopHocService, 
            NganhHocService nganhHocService, 
            HocKyService hockyService, 
            NamHocService namHocService, 
            UserRoleService userRoleService, 
            RolePermissionService rolePermissionService
            )
        {
            InitializeComponent();
            _dbContext = dbContext;
            _currentUserId = currentUserId;
            _userService = userService;
            _diemService = diemService;
            _lanThiService = lanThiService;
            _sinhVienService = sinhVienService;
            _monHocService = monHocService;
            _lopHocService = lopHocService;
            _nganhHocService = nganhHocService;
            _hockyService = hockyService;
            _namHocService = namHocService;
            _userRoleService = userRoleService;
            _rolePermissionService = rolePermissionService;
            LoadUserPermissions();
        }

        #region Load Data
        private void DiemForm1_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            InitializeDataGridView();
            HideTextBoxInput();
            HideTextBoxOutput();
            SetupEventHandlers();
            FilterDGV();
            LoadUserPermissions();
        }

        private void LoadUserPermissions()
        {
            var userRoles = _userRoleService.GetUserRolesByUserId(_currentUserId).ToList();
            if (userRoles.Any())
            {
                foreach (var userRole in userRoles)
                {
                    userPermissions.AddRange(_rolePermissionService.GetPermissionsByRoleId(userRole.RoleId).Select(p => p.Permission.PermissionName));
                }

                btnThem.Enabled = userPermissions.Contains("add_student");
                btnSua.Enabled = userPermissions.Contains("edit_student");
                btnXoa.Enabled = userPermissions.Contains("delete_student");
                btnXemDanhSachDiem.Enabled = userPermissions.Contains("view_course");
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnXemDanhSachDiem.Enabled = false;
            }
        }
        private void LoadComboBoxes()
        {
            LoadComboBoxFilterNamHoc();
            cbbFilterByNamHoc.SelectedValue = -1;
            LoadComboBoxFilterHocKy(-1); // Pass -1 for NamHoc ID to load all
            LoadComboBoxFilterNganhHoc(-1, -1); // Pass -1 for HocKy and NamHoc IDs
            LoadComboBoxFilterMonHoc(-1, -1); // Pass -1 for NganhHoc and HocKy IDs
            LoadComboBoxFilterLanThi(-1); // Pass -1 for MonHoc ID
            LoadComboBoxFilterSinhVien(-1); // Pass -1 for LanThi ID
            //LoadComboBoxInputLop(); // Load thông tin Lớp

            //LoadComboBoxInputMonHoc();
            FilterDGV();

        }
        private void LoadComboBoxFilterNamHoc()
        {
            //_namHocService = new();
            List<NamHoc> namHocs = _namHocService.GetAllNamHocs().ToList();
            namHocs.Insert(0, new NamHoc { Id = -1, TenNamHoc = "Tất Cả" });
            cbbFilterByNamHoc.DataSource = namHocs;
            cbbFilterByNamHoc.DisplayMember = "TenNamHoc";
            cbbFilterByNamHoc.ValueMember = "Id";
            cbbFilterByNamHoc.SelectedIndex = 0;
        }

        private void LoadComboBoxFilterHocKy(int? idNamHoc = null)
        {
            //hockyService = new();
            List<HocKy> hocKys;

            if (idNamHoc.HasValue && idNamHoc > 0)
            {
                hocKys = _hockyService.GetAllHocKys()
                    .Where(hk => hk.IdNamHoc == idNamHoc)
                    .ToList();
            }
            else
            {
                hocKys = _hockyService.GetAllHocKys().ToList();
            }

            hocKys.Insert(0, new HocKy { Id = -1, TenHocKy = "Tất Cả" });
            cbbFilterByHocKy.DataSource = hocKys;
            cbbFilterByHocKy.DisplayMember = "TenHocKy";
            cbbFilterByHocKy.ValueMember = "Id";
            cbbFilterByHocKy.SelectedIndex = 0;
        }

        private void LoadComboBoxFilterNganhHoc(int? idHocKy = null, int? idNamHoc = null)
        {
           // nganhHocService = new();
            List<QLDKhoa_CNTT.DAL.Entities.NganhHoc> nganhHocs;

            if (!(idHocKy.HasValue && idHocKy > 0) && !(idNamHoc.HasValue && idNamHoc > 0))
            {
                nganhHocs = _nganhHocService.GetAllNganhHocs().ToList();
            }
            else if (idHocKy.HasValue && idHocKy > 0 && !(idNamHoc.HasValue && idNamHoc > 0))
            {
                nganhHocs = _nganhHocService.GetAllNganhHocs()
                .Where(n => n.LopHocs.Any(lop =>
                    lop.SinhViens.Any(sv =>
                        sv.Diems.Any(d =>
                          d.IdLanThiNavigation != null &&
                          d.IdLanThiNavigation.IdMonHocNavigation != null &&
                          d.IdLanThiNavigation.IdMonHocNavigation.IdHocKy == idHocKy
                       )
                    )
               ))
               .Distinct()
               .ToList();
            }
            else if ((idHocKy.HasValue && idHocKy > 0) && (idNamHoc.HasValue && idNamHoc > 0))
            {
                nganhHocs = _nganhHocService.GetAllNganhHocs()
                   .Where(n => n.LopHocs.Any(lop =>
                        lop.SinhViens.Any(sv =>
                            sv.Diems.Any(d =>
                                d.IdLanThiNavigation != null &&
                                d.IdLanThiNavigation.IdMonHocNavigation != null &&
                                d.IdLanThiNavigation.IdMonHocNavigation.IdHocKy == idHocKy &&
                                d.IdLanThiNavigation.IdMonHocNavigation.IdHocKyNavigation.IdNamHoc == idNamHoc
                            )
                       )
                   ))
                   .Distinct()
                   .ToList();
            }
            else
            {
                nganhHocs = _nganhHocService.GetAllNganhHocs().ToList();
            }

            nganhHocs.Insert(0, new QLDKhoa_CNTT.DAL.Entities.NganhHoc { Id = -1, TenNganhHoc = "Tất Cả" });
            cbbFilterByNganh.DataSource = nganhHocs;
            cbbFilterByNganh.DisplayMember = "TenNganhHoc";
            cbbFilterByNganh.ValueMember = "Id";
            cbbFilterByNganh.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterMonHoc(int? idNganh = null, int? idHocKy = null)
        {
            //monHocService = new();
            List<MonHoc> monHocs;

            if (idNganh.HasValue && idNganh > 0 && idHocKy.HasValue && idHocKy > 0)
            {
                monHocs = _monHocService.GetAllMonHocs()
                    .Where(mh => mh.IdHocKy == idHocKy &&
                                 _nganhHocService.GetAllNganhHocs().Any(nh => nh.Id == idNganh &&
                                                                            nh.LopHocs.Any(lop => _sinhVienService.GetAllSinhVien().Any(sv => sv.IdLop == lop.Id &&
                                                                                                                                   _diemService.GetAllDiems().Any(d => d.IdLanThiNavigation.IdMonHoc == mh.Id)))))
                    .ToList();
            }
            else if (idHocKy.HasValue && idHocKy > 0)
            {
                monHocs = _monHocService.GetAllMonHocs().Where(mh => mh.IdHocKy == idHocKy).ToList();
            }
            else
            {
                monHocs = _monHocService.GetAllMonHocs().ToList();
            }

            monHocs.Insert(0, new MonHoc { Id = -1, TenMonHoc = "Tất Cả" });
            cbbFilterByMonHoc.DataSource = monHocs;
            cbbFilterByMonHoc.DisplayMember = "TenMonHoc";
            cbbFilterByMonHoc.ValueMember = "Id";
            cbbFilterByMonHoc.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterHinhThucThi(int? idMonHoc = null)
        {
            //_lanThiService = new();
            List<string> hinhThucThis;

            if (idMonHoc.HasValue && idMonHoc > 0)
            {
                hinhThucThis = _lanThiService.GetAllLanThis()
                    .Where(lt => lt.IdMonHoc == idMonHoc)
                    .Select(lt => lt.HinhThucThi)
                    .Distinct()
                    .ToList();
            }
            else
            {
                hinhThucThis = new List<string>();
            }

            hinhThucThis.Insert(0, "Tất Cả");
            cbbFilterByHinhThucThi.DataSource = hinhThucThis;
            cbbFilterByHinhThucThi.SelectedIndex = 0;
        }

        private void LoadComboBoxFilterLanThi(int? idMonHoc = null, string hinhThucThi = null)
        {
           // _lanThiService = new();
            List<LanThi> lanThis;

            if (idMonHoc.HasValue && idMonHoc > 0 && !string.IsNullOrEmpty(hinhThucThi) && hinhThucThi != "Tất Cả")
            {
                lanThis = _lanThiService.GetAllLanThis()
                    .Where(lt => lt.IdMonHoc == idMonHoc && lt.HinhThucThi == hinhThucThi)
                    .ToList();
            }
            else if (idMonHoc.HasValue && idMonHoc > 0)
            {
                lanThis = _lanThiService.GetAllLanThis()
                    .Where(lt => lt.IdMonHoc == idMonHoc)
                    .ToList();
            }
            else
            {
                lanThis = new List<LanThi>();
            }

            lanThis.Insert(0, new LanThi { Id = -1, LanThi1 = 0, NgayThi = DateOnly.FromDateTime(DateTime.Now) });
            cbbFilterByLanThi.DataSource = lanThis;
            cbbFilterByLanThi.DisplayMember = "LanThi1";
            cbbFilterByLanThi.ValueMember = "Id";
            cbbFilterByLanThi.SelectedIndex = 0;
        }

        private void LoadComboBoxFilterSinhVien(int? idLanThi = null, int? idLop = null)
        {
            //sinhVienService = new();
            List<SinhVien> sinhViens;

            if (idLanThi.HasValue && idLanThi > 0)
            {
                sinhViens = _sinhVienService.GetAllSinhVien()
                    .Where(sv => sv.Diems.Any(d => d.IdLanThi == idLanThi))
                    .ToList();

                if (idLop.HasValue && idLop > 0)
                {
                    sinhViens = sinhViens.Where(sv => sv.IdLop == idLop).ToList();
                }

            }
            else if (idLop.HasValue && idLop > 0)
            {
                sinhViens = _sinhVienService.GetAllSinhVien()
                     .Where(sv => sv.IdLop == idLop)
                    .ToList();
            }
            else
            {
                sinhViens = _sinhVienService.GetAllSinhVien().ToList();
            }

            sinhViens.Insert(0, new SinhVien { Id = -1, TenSinhVien = "Tất Cả" });
            cbbFilterBySinhVien.DataSource = sinhViens;
            cbbFilterBySinhVien.DisplayMember = "TenSinhVien";
            cbbFilterBySinhVien.ValueMember = "Id";
            cbbFilterBySinhVien.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterLop(int? idNganh = null)
        {
            //_lopHocService = new();
            List<LopHoc> lopHocs;

            if (idNganh.HasValue && idNganh > 0)
            {
                lopHocs = _lopHocService.GetAllLopHocs().Where(l => l.IdNganh == idNganh).ToList();
            }
            else
            {
                lopHocs = _lopHocService.GetAllLopHocs().ToList();
            }

            lopHocs.Insert(0, new LopHoc { Id = -1, TenLop = "Tất Cả" });
            cbbFilterByLop.DataSource = lopHocs;
            cbbFilterByLop.DisplayMember = "TenLop";
            cbbFilterByLop.ValueMember = "Id";
            cbbFilterByLop.SelectedIndex = 0;
        }

        //private void LoadComboBoxInputLop()
        //{
        //    lopHocService = new();
        //    cbbInputLopHoc.DataSource = lopHocService.GetAllLopHocs();
        //    cbbInputLopHoc.DisplayMember = "TenLop";
        //    cbbInputLopHoc.ValueMember = "Id";
        //    cbbInputLopHoc.SelectedIndex = -1; // Không chọn mặc định
        //}
        //private void LoadComboBoxInputSinhVien(int? idLop)
        //{
        //    sinhVienService = new();
        //    cbbInputSinhVien.DataSource = null;
        //    if (idLop.HasValue)
        //    {
        //        var lop = sinhVienService.GetAllSinhVien()
        //                                 .Where(sv => sv.IdLop == idLop)
        //                                 .ToList();
        //        cbbInputSinhVien.DataSource = lop;
        //    }
        //    else
        //    {
        //        cbbInputSinhVien.DataSource = sinhVienService.GetAllSinhVien(); // Nếu không có lớp nào được chọn, hiển thị tất cả
        //    }
        //    cbbInputSinhVien.DisplayMember = "TenSinhVien";
        //    cbbInputSinhVien.ValueMember = "Id";
        //    cbbInputSinhVien.SelectedIndex = -1;
        //}
        //private void LoadComboBoxInputMonHoc()
        //{
        //    monHocService = new();
        //    cbbInputMonHoc.DataSource = monHocService.GetAllMonHocs();
        //    cbbInputMonHoc.DisplayMember = "TenMonHoc";
        //    cbbInputMonHoc.ValueMember = "Id";
        //    cbbInputMonHoc.SelectedIndex = -1;
        //}
        //private void LoadComboBoxInputHinhThucThi(int? idMonHoc)
        //{
        //    cbbInputHinhThucThi.DataSource = null;
        //    if (idMonHoc.HasValue)
        //    {
        //        var hinhThucThis = lanThiService.GetAllLanThis()
        //                                      .Where(lt => lt.IdMonHoc == idMonHoc)
        //                                      .Select(lt => lt.HinhThucThi)
        //                                      .Distinct()
        //                                      .ToList();
        //        cbbInputHinhThucThi.DataSource = hinhThucThis;
        //    }
        //    cbbInputHinhThucThi.SelectedIndex = -1;
        //}
        //private void LoadComboBoxInputLanThi(int? idMonHoc = null, string hinhThucThi = null)
        //{
        //    lanThiService = new();
        //    List<LanThi> lanThi;
        //    if (idMonHoc.HasValue && !string.IsNullOrEmpty(hinhThucThi))
        //    {
        //        lanThi = lanThiService.GetAllLanThis()
        //                              .Where(lt => lt.IdMonHoc == idMonHoc.Value && lt.HinhThucThi == hinhThucThi)
        //                              .ToList();
        //    }
        //    else
        //    {
        //        lanThi = new List<LanThi>();
        //    }
        //    cbbInputLanThi.DataSource = null;
        //    cbbInputLanThi.DataSource = lanThi;
        //    cbbInputLanThi.DisplayMember = "LanThi1";
        //    cbbInputLanThi.ValueMember = "Id";
        //    cbbInputLanThi.SelectedIndex = -1;
        //}

        private void InitializeDataGridView()
        {
            dgvDiem.SelectionChanged -= dgvDiem_SelectionChanged;
            dgvDiem.DataSource = null;
            DataGridViewTextBoxColumn colLopHoc = new DataGridViewTextBoxColumn();
            colLopHoc.Name = "LopHoc";
            colLopHoc.HeaderText = "Lớp Học";
            dgvDiem.Columns.Add(colLopHoc);

            DataGridViewTextBoxColumn colMonHoc = new DataGridViewTextBoxColumn();
            colMonHoc.Name = "MonHoc";
            colMonHoc.HeaderText = "Môn Học";
            dgvDiem.Columns.Add(colMonHoc);

            DataGridViewTextBoxColumn colHinhThucThi = new DataGridViewTextBoxColumn();
            colHinhThucThi.Name = "HinhThucThi";
            colHinhThucThi.HeaderText = "Hình Thức Thi";
            dgvDiem.Columns.Add(colHinhThucThi);

            DataGridViewTextBoxColumn colNganhHoc = new DataGridViewTextBoxColumn();
            colNganhHoc.Name = "NganhHoc";
            colNganhHoc.HeaderText = "Ngành Học";
            dgvDiem.Columns.Add(colNganhHoc);

            DataGridViewTextBoxColumn colNgayThi = new DataGridViewTextBoxColumn();
            colNgayThi.Name = "NgayThi";
            colNgayThi.HeaderText = "Ngày Thi";
            dgvDiem.Columns.Add(colNgayThi);

            LoadDataIntoDataGridView();
            dgvDiem.CellFormatting += dgvDiem_CellFormatting;
            ReNameAndHideCollumn();
            dgvDiem.ClearSelection();
            dgvDiem.SelectionChanged += dgvDiem_SelectionChanged;
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadDataIntoDataGridView()
        {
            //diemService = new();
            dgvDiem.DataSource = _diemService.GetAllDiems().ToList(); ;
        }
        private void ReNameAndHideCollumn()
        {
            if (dgvDiem.Columns.Contains("Id"))
            {
                dgvDiem.Columns["Id"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdSinhVien"))
            {
                dgvDiem.Columns["IdSinhVien"].HeaderText = "Sinh Viên";
            }
            if (dgvDiem.Columns.Contains("IdLanThi"))
            {
                dgvDiem.Columns["IdLanThi"].HeaderText = "Lần Thi";
            }
            if (dgvDiem.Columns.Contains("Diem1"))
            {
                dgvDiem.Columns["Diem1"].HeaderText = "Điểm";
            }
            if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
            {
                dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
            {
                dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            }
        }
        private void SetupEventHandlers()
        {
            cbbFilterByNamHoc.SelectedIndexChanged += CbbFilterByNamHoc_SelectedIndexChanged;
            cbbFilterByHocKy.SelectedIndexChanged += CbbFilterByHocKy_SelectedIndexChanged;
            cbbFilterByNganh.SelectedIndexChanged += CbbFilterByNganh_SelectedIndexChanged;
            cbbFilterByLanThi.SelectedIndexChanged += CbbFilterByLanThi_SelectedIndexChanged;
            cbbFilterBySinhVien.SelectedIndexChanged += CbbFilterBySinhVien_SelectedIndexChanged;
            //cbbInputMonHoc.SelectedIndexChanged += CbbInputMonHoc_SelectedIndexChanged;
            //cbbInputHinhThucThi.SelectedIndexChanged += CbbInputHinhThucThi_SelectedIndexChanged;
            //cbbInputLopHoc.SelectedIndexChanged += CbbInputLopHoc_SelectedIndexChanged;
            cbbFilterByLop.SelectedIndexChanged += CbbFilterByLop_SelectedIndexChanged;
            cbbFilterByMonHoc.SelectedIndexChanged += CbbFilterByMonHoc_SelectedIndexChanged;
            cbbFilterByHinhThucThi.SelectedIndexChanged += CbbFilterByHinhThucThi_SelectedIndexChanged;
        }

        private void CbbFilterByNamHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByNamHoc.SelectedValue is NamHoc namHocSelected)
            {
                int idNamHoc = namHocSelected.Id;

                LoadComboBoxFilterHocKy(idNamHoc);
                LoadComboBoxFilterNganhHoc(-1, idNamHoc);
                LoadComboBoxFilterMonHoc(-1, -1);
                LoadComboBoxFilterLanThi(-1);
                LoadComboBoxFilterSinhVien(-1);
                LoadComboBoxFilterLop(-1);
                FilterDGV();
            }
            else if (cbbFilterByNamHoc.SelectedValue is int id)
            {
                int idNamHoc = id;
                LoadComboBoxFilterHocKy(idNamHoc);
                LoadComboBoxFilterNganhHoc(-1, idNamHoc);
                LoadComboBoxFilterMonHoc(-1, -1);
                LoadComboBoxFilterLanThi(-1);
                LoadComboBoxFilterSinhVien(-1);
                LoadComboBoxFilterLop(-1);
                FilterDGV();

            }
            else
            {
                // Xử lý trường hợp SelectedValue không hợp lệ (ví dụ: combobox rỗng)
                MessageBox.Show("Vui lòng chọn năm học.");

                // Hoặc bạn có thể reset các ComboBox khác về trạng thái ban đầu nếu cần
                LoadComboBoxFilterHocKy(-1);
                LoadComboBoxFilterNganhHoc(-1, -1);
                // ... (reset các ComboBox khác)
                FilterDGV(); // Refresh DataGridView to show all data
            }
        }
        private void CbbFilterByHocKy_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByHocKy.SelectedValue is HocKy hocKySelected)
            {
                int idHocKy = hocKySelected.Id;

                if (cbbFilterByNamHoc.SelectedValue is NamHoc namHocSelected)
                {
                    int idNamHoc = namHocSelected.Id;
                    LoadComboBoxFilterNganhHoc(idHocKy, idNamHoc);
                }
                else if (cbbFilterByNamHoc.SelectedValue is int idNamHoc)
                {
                    LoadComboBoxFilterNganhHoc(idHocKy, idNamHoc);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn năm học.");
                    return; // Hoặc xử lý lỗi theo cách khác
                }
                LoadComboBoxFilterMonHoc(-1, idHocKy);
                LoadComboBoxFilterLanThi(-1);
                LoadComboBoxFilterSinhVien(-1);
                LoadComboBoxFilterLop(-1);
                FilterDGV();
            }
            else if (cbbFilterByHocKy.SelectedValue is int idHocKyInt)
            {
                int idHocKy = idHocKyInt;
                if (cbbFilterByNamHoc.SelectedValue is NamHoc namHocSelected)
                {
                    int idNamHoc = namHocSelected.Id;
                    LoadComboBoxFilterNganhHoc(idHocKy, idNamHoc);
                }
                else if (cbbFilterByNamHoc.SelectedValue is int idNamHoc)
                {
                    LoadComboBoxFilterNganhHoc(idHocKy, idNamHoc);

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn năm học.");
                    return;
                }
                LoadComboBoxFilterMonHoc(-1, idHocKy);
                LoadComboBoxFilterLanThi(-1);
                LoadComboBoxFilterSinhVien(-1);
                LoadComboBoxFilterLop(-1);
                FilterDGV();
            }

            else
            {

                MessageBox.Show("Vui lòng chọn học kỳ.");


            }
        }
        private void CbbFilterByNganh_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByNganh.SelectedValue is QLDKhoa_CNTT.DAL.Entities.NganhHoc nganhHocSelected)
            {
                int idNganh = nganhHocSelected.Id;


                if (cbbFilterByHocKy.SelectedValue is HocKy hocKySelected)
                {
                    int idHocKy = hocKySelected.Id;
                    LoadComboBoxFilterMonHoc(idNganh, idHocKy);
                }
                else if (cbbFilterByHocKy.SelectedValue is int idHocKy)
                {
                    LoadComboBoxFilterMonHoc(idNganh, idHocKy);

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn học kỳ.");
                    return;
                }



                LoadComboBoxFilterLanThi(-1);
                LoadComboBoxFilterSinhVien(-1);
                LoadComboBoxFilterLop(idNganh);
                FilterDGV();

            }
            else if (cbbFilterByNganh.SelectedValue is int idNganhInt)
            {
                int idNganh = idNganhInt;

                if (cbbFilterByHocKy.SelectedValue is HocKy hocKySelected)
                {
                    int idHocKy = hocKySelected.Id;
                    LoadComboBoxFilterMonHoc(idNganh, idHocKy);
                }
                else if (cbbFilterByHocKy.SelectedValue is int idHocKy)
                {
                    LoadComboBoxFilterMonHoc(idNganh, idHocKy);

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn học kỳ.");
                    return;
                }
                LoadComboBoxFilterLanThi(-1);
                LoadComboBoxFilterSinhVien(-1);
                LoadComboBoxFilterLop(idNganh);
                FilterDGV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngành.");


            }
        }
        private void CbbFilterByMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByMonHoc.SelectedValue is MonHoc monHocSelected)
            {
                int idMonHoc = monHocSelected.Id;
                LoadComboBoxFilterLanThi(idMonHoc);
                LoadComboBoxFilterSinhVien(-1);
                FilterDGV();
            }
            else if (cbbFilterByMonHoc.SelectedValue is int idMonHocInt)
            {
                int idMonHoc = idMonHocInt;
                LoadComboBoxFilterLanThi(idMonHoc);
                LoadComboBoxFilterSinhVien(-1);
                FilterDGV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                // Hoặc bạn có thể reset các ComboBox/DataGridView nếu cần
                LoadComboBoxFilterLanThi(-1); // Reset LanThi ComboBox
                LoadComboBoxFilterSinhVien(-1); // Reset SinhVien ComboBox
                FilterDGV(); // Refresh DataGridView to show all data
            }
        }
        private void CbbFilterByHinhThucThi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && cbbFilterByHinhThucThi.SelectedItem is string hinhThucThi)
            {
                LoadComboBoxFilterLanThi(idMonHoc == -1 ? null : (int?)idMonHoc, hinhThucThi == "Tất Cả" ? null : hinhThucThi);
                LoadComboBoxFilterSinhVien();
                FilterDGV();
            }
        }

        private void CbbFilterByLanThi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByLanThi.SelectedValue is LanThi lanThiSelected)
            {
                int idLanThi = lanThiSelected.Id;
                LoadComboBoxFilterSinhVien(idLanThi);
                FilterDGV();
            }
            else if (cbbFilterByLanThi.SelectedValue is int idLanThiInt)
            {
                int idLanThi = idLanThiInt;
                LoadComboBoxFilterSinhVien(idLanThi);
                FilterDGV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lần thi.");
                // Hoặc bạn có thể reset các ComboBox/DataGridView nếu cần
                LoadComboBoxFilterSinhVien(-1); // Reset SinhVien ComboBox if needed
                FilterDGV(); // Refresh DataGridView to show all data (optional)

            }
        }
        private void CbbFilterBySinhVien_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FilterDGV();
        }
        private void CbbFilterByLop_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByLop.SelectedValue is LopHoc lopHoc)
            {
                int idLop = lopHoc.Id;
                LoadComboBoxFilterSinhVien(null, idLop);
                FilterDGV();
            }
            else if (cbbFilterByLop.SelectedValue is int idLopInt)
            {
                LoadComboBoxFilterSinhVien(null, idLopInt);
                FilterDGV();
            }
        }

        //private void CbbInputLopHoc_SelectedIndexChanged(object? sender, EventArgs e)
        //{
        //    if (cbbInputLopHoc.SelectedValue is int idLop)
        //    {
        //        LoadComboBoxInputSinhVien(idLop);
        //    }
        //    else
        //    {
        //        LoadComboBoxInputSinhVien(null);
        //    }
        //}

        //private void CbbInputHinhThucThi_SelectedIndexChanged(object? sender, EventArgs e)
        //{
        //    if (cbbInputMonHoc.SelectedValue is int idMonHoc && cbbInputHinhThucThi.SelectedItem is string hinhThucThi)
        //    {
        //        LoadComboBoxInputLanThi(idMonHoc, hinhThucThi);
        //    }
        //    else
        //    {
        //        LoadComboBoxInputLanThi(cbbInputMonHoc.SelectedValue as int?);
        //    }
        //}

        //private void CbbInputMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        //{
        //    if (cbbInputMonHoc.SelectedValue != null && cbbInputMonHoc.SelectedValue is int idMonHoc)
        //    {
        //        LoadComboBoxInputHinhThucThi(idMonHoc);
        //        LoadComboBoxInputLanThi(idMonHoc);
        //    }
        //    else
        //    {
        //        cbbInputHinhThucThi.DataSource = null;
        //        LoadComboBoxInputLanThi();
        //    }
        //    cbbInputLanThi.SelectedIndex = -1;
        //}
        #endregion

        #region Filter Data
        private void FilterDGVBySinhVien()
        {
            if (cbbFilterBySinhVien.SelectedIndex == 0 && cbbFilterBySinhVien.SelectedValue is int && (int)cbbFilterBySinhVien.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterBySinhVien.SelectedValue is int idSinhVien)
            {
                //diemService = new();
                dgvDiem.DataSource = _diemService.GetAllDiems().Where(d => d.IdSinhVien == idSinhVien).ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }

            if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
            {
                dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
            {
                dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            }
        }

        private void FilterDGVByLanThi()
        {
            if (cbbFilterByLanThi.SelectedIndex == 0 && cbbFilterByLanThi.SelectedValue is int && (int)cbbFilterByLanThi.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterByLanThi.SelectedValue is int idLanThi)
            {
                //diemService = new();
                dgvDiem.DataSource = _diemService.GetAllDiems().Where(d => d.IdLanThi == idLanThi).ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }

            if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
            {
                dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
            {
                dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            }
        }
        private void FilterDGVByLop()
        {
            if (cbbFilterByLop.SelectedIndex == 0 && cbbFilterByLop.SelectedValue is int && (int)cbbFilterByLop.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterByLop.SelectedValue is int idLop)
            {
                //diemService = new();
                dgvDiem.DataSource = _diemService.GetAllDiems()
                                                 .Where(d => d.IdSinhVienNavigation != null && d.IdSinhVienNavigation.IdLop == idLop)
                                                 .ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }

            if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
            {
                dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
            {
                dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            }
        }

        private void FilterDGVByMonHoc()
        {
            if (cbbFilterByMonHoc.SelectedIndex == 0 && cbbFilterByMonHoc.SelectedValue is int && (int)cbbFilterByMonHoc.SelectedValue == -1)
            {
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterByMonHoc.SelectedValue is int idMonHoc)
            {
                //diemService = new();
                dgvDiem.DataSource = _diemService.GetByMonHoc(idMonHoc);
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }

            if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
            {
                dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
            {
                dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            }
        }
        private void FilterDGV()
        {
            try
            {
                //diemService = new();
                var query = _diemService.GetAllDiems().AsQueryable();

                if (cbbFilterByNamHoc.SelectedValue is int idNamHoc && idNamHoc > -1)
                {
                    query = query.Where(d => d.IdLanThiNavigation != null &&
                                                  d.IdLanThiNavigation.IdMonHocNavigation != null &&
                                                  d.IdLanThiNavigation.IdMonHocNavigation.IdHocKyNavigation != null &&
                                                  d.IdLanThiNavigation.IdMonHocNavigation.IdHocKyNavigation.IdNamHoc == idNamHoc);
                }

                if (cbbFilterByHocKy.SelectedValue is int idHocKy && idHocKy > -1)
                {
                    query = query.Where(d => d.IdLanThiNavigation != null &&
                                d.IdLanThiNavigation.IdMonHocNavigation != null &&
                                 d.IdLanThiNavigation.IdMonHocNavigation.IdHocKy == idHocKy);
                }


                if (cbbFilterByNganh.SelectedValue is int idNganh && idNganh > -1)
                {
                    // Lọc theo ngành học
                    dgvDiem.DataSource = _diemService.GetDiemByNganhHoc(idNganh);
                }
                else if (cbbFilterByLop.SelectedValue is int idLop && idLop > -1)
                {
                    // Lọc theo lớp học
                    var danhSachSinhVien = _sinhVienService.GetAllSinhVien().Where(sv => sv.IdLop == idLop).Select(sv => sv.Id).ToList();

                    query = _diemService.GetAllDiems().Where(d => danhSachSinhVien.Contains(d.IdSinhVien)).AsQueryable();

                    // Apply other filters (MonHoc, HinhThucThi, LanThi, SinhVien) within Lop filter.
                    if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && idMonHoc > -1)
                    {
                        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.IdMonHoc == idMonHoc);
                    }
                    // ... (similarly for HinhThucThi, LanThi, SinhVien filters)

                    dgvDiem.DataSource = query.ToList();
                }
                else
                {
                    if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && idMonHoc > -1)
                    {
                        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.IdMonHoc == idMonHoc);
                    }
                    // ... (similarly for HinhThucThi, LanThi, SinhVien filters)

                    dgvDiem.DataSource = query.ToList();
                }

                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\nChi tiết: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Handle DataGridView Event
        private void dgvDiem_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDiem != null && e.RowIndex >= 0 && e.RowIndex < dgvDiem.Rows.Count)
            {
                if (dgvDiem.Rows[e.RowIndex].DataBoundItem is Diem diem)
                {
                    using (var context = new QuanLyDiemKhoaCnttContext()) // Make sure this context is properly scoped
                    {
                        if (context != null)
                        {
                            // IdSinhVien
                            if (e.ColumnIndex == dgvDiem.Columns["IdSinhVien"].Index && e.Value is int idSinhVien)
                            {
                                e.Value = context.SinhViens
                                    .Where(sv => sv.Id == idSinhVien)
                                    .Select(sv => sv.TenSinhVien)
                                    .FirstOrDefault() ?? "";
                                e.FormattingApplied = true;
                            }

                            // IdLanThi
                            if (e.ColumnIndex == dgvDiem.Columns["IdLanThi"].Index && e.Value is int idLanThi)
                            {
                                e.Value = context.LanThis
                                    .Where(lt => lt.Id == idLanThi)
                                    .Select(lt => lt.LanThi1)
                                    .FirstOrDefault()
                                    .ToString();
                                e.FormattingApplied = true;
                            }

                            // LopHoc
                            if (e.ColumnIndex == dgvDiem.Columns["LopHoc"].Index)
                            {
                                e.Value = (from sv in context.SinhViens
                                           join lh in context.LopHocs on sv.IdLop equals lh.Id
                                           where sv.Id == diem.IdSinhVien
                                           select lh.TenLop).FirstOrDefault() ?? "";
                                e.FormattingApplied = true;
                            }

                            // MonHoc
                            if (e.ColumnIndex == dgvDiem.Columns["MonHoc"].Index)
                            {
                                e.Value = (from lt in context.LanThis
                                           join mh in context.MonHocs on lt.IdMonHoc equals mh.Id
                                           where lt.Id == diem.IdLanThi
                                           select mh.TenMonHoc).FirstOrDefault() ?? "";
                                e.FormattingApplied = true;
                            }

                            // HinhThucThi
                            if (e.ColumnIndex == dgvDiem.Columns["HinhThucThi"].Index)
                            {
                                e.Value = context.LanThis.Where(lt => lt.Id == diem.IdLanThi).Select(lt => lt.HinhThucThi).FirstOrDefault() ?? "";
                                e.FormattingApplied = true;
                            }

                            // NganhHoc
                            if (e.ColumnIndex == dgvDiem.Columns["NganhHoc"].Index)
                            {
                                e.Value = (from sv in context.SinhViens
                                           join lh in context.LopHocs on sv.IdLop equals lh.Id
                                           join nh in context.NganhHocs on lh.IdNganh equals nh.Id
                                           where sv.Id == diem.IdSinhVien
                                           select nh.TenNganhHoc).FirstOrDefault() ?? "";
                                e.FormattingApplied = true;
                            }

                            // NgayThi
                            if (e.ColumnIndex == dgvDiem.Columns["NgayThi"].Index)
                            {
                                e.Value = context.LanThis.Where(lt => lt.Id == diem.IdLanThi).Select(lt => lt.NgayThi).FirstOrDefault().ToShortDateString();
                                e.FormattingApplied = true;
                            }
                        }
                    }
                }
            }
        }


        private void dgvDiem_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow != null && dgvDiem.CurrentRow.DataBoundItem is Diem diem)
            {
                txtOutputId.Text = diem.Id.ToString();
                txtOutputDiem.Text = diem.Diem1.ToString();

                var lanThi = _lanThiService.GetALanThi(diem.IdLanThi);
                if (lanThi != null)
                {
                    txtOutputLanThi.Text = lanThi.LanThi1.ToString();
                }
                else
                {
                    txtOutputLanThi.Text = string.Empty;
                }


                var sinhVien = _sinhVienService.GetAnSinhVien(diem.IdSinhVien);
                if (sinhVien != null)
                {
                    txtOutputSinhVien.Text = sinhVien.TenSinhVien;
                }
                else
                {
                    txtOutputSinhVien.Text = string.Empty;
                }
            }
            else
            {
                MakeBlankOfTextBox();
            }
        }
        #endregion


        #region Handle Button

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("add_student"))
            {
                MessageBox.Show("Bạn không có quyền thêm điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var detailForm = new DiemDetailForm(_diemService, _lanThiService, _sinhVienService, _monHocService, _lopHocService))
            {
                detailForm.SetForAdd();
                detailForm.DataSaved += DetailForm_DataSaved; // Subscribe to the event
                detailForm.ShowDialog();
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("edit_student"))
            {
                MessageBox.Show("Bạn không có quyền sửa điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvDiem.CurrentRow != null && dgvDiem.CurrentRow.DataBoundItem is Diem diem)
            {
                using (var detailForm = new DiemDetailForm(_diemService, _lanThiService, _sinhVienService, _monHocService, _lopHocService))
                {
                    detailForm.SetForEdit(diem.Id);
                    detailForm.DataSaved += DetailForm_DataSaved; // Subscribe to the event
                    detailForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Handle TextBox, Clear Textbox
        private void HideTextBoxOutput()
        {
            txtOutputId.Enabled = false;
            txtOutputDiem.Enabled = false;
            txtOutputSinhVien.Enabled = false;
            txtOutputLanThi.Enabled = false;
        }
        private void HideTextBoxInput() { } //This is no longer needed as input is in separate form


        private void MakeBlankOfTextBox()
        {
            txtOutputId.Clear();
            txtOutputDiem.Clear();
            txtOutputSinhVien.Clear();
            txtOutputLanThi.Clear();
        }


        #endregion



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("delete_student"))
            {
                MessageBox.Show("Bạn không có quyền xóa điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvDiem.CurrentRow != null && dgvDiem.CurrentRow.DataBoundItem is Diem diem)
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm của sinh viên {diem.IdSinhVienNavigation?.TenSinhVien} trong lần thi {diem.IdLanThiNavigation?.LanThi1} môn {diem.IdLanThiNavigation?.IdMonHocNavigation?.TenMonHoc}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _diemService.DeleteADiem(diem.Id);
                        MessageBox.Show("Xóa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FilterDGV(); // Refresh DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn điểm cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ... (btnThoat_Click, btnRefresh_Click, and btnXemDanhSachDiem_Click remain the same)



      
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // ... (Existing btnRefresh_Click logic)
        }

        private void btnXemDanhSachDiem_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("view_student"))
            {
                MessageBox.Show("Bạn không có quyền xem danh sách điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReportForm reportForm = new ReportForm("xdsd");
            reportForm.ShowDialog();
        }


        private void DetailForm_DataSaved(object sender, EventArgs e)
        {
            FilterDGV();  // Refresh the DataGridView
        }
        #endregion

    }
}