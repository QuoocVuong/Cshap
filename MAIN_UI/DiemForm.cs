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
    public partial class DiemForm : Form
    {

        private readonly QuanLyDiemKhoaCnttContext _dbContext;
        //private readonly UserRepository _userRepository;
        //private readonly UserRoleRepository _userRoleRepository;
        //private readonly RolePermissionRepository _rolePermissionRepository;
        //private readonly NganhHocRepository _nganhHocRepository;
        private DiemService diemService = new();
        private LanThiService lanThiService = new();
        private SinhVienService sinhVienService = new();
        private MonHocService monHocService = new(); // Add MonHocService
        private LopHocService lopHocService = new(); // Thêm LopHocService
        private NganhHocService nganhHocService = new(); // Thêm NganhHocService
        private HocKyService hockyService = new();
        private NamHocService namHocService = new();

        // private readonly UserService _userService= new ();
        private readonly UserRoleService _userRoleService = new();
        private readonly RolePermissionService _rolePermissionService = new();





        private bool isAddingNew = false;
        private int? idLanThiInput = null;
        private int? idSinhVienInput = null;
        private bool isEditing = false;
        private int? currentEditId = null;
        //private readonly NganhHocService _nganhHocService;
        private int _currentUserId;
        private readonly UserService _userService;


        private List<string> userPermissions = new List<string>();

        public DiemForm(int currentUserId, UserService userService) // Nhận ID người dùng trong constructor
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            _userService = userService; // Lưu trữ UserService instance
            LoadUserPermissions();
            // ... phần còn lại của constructor ...
            LoadUserPermissions();
        }

        #region Load Data
        private void DiemForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            InitializeDataGridView();
            HideTextBoxInput();
            HideTextBoxOutput();
            SetupEventHandlers();
            FilterDGV();
            LoadUserPermissions();
        }

        //private void LoadComboBoxes()
        //{
        //    LoadComboBoxFilterNamHoc();
        //    LoadComboBoxFilterHocKy(); // Load Học kỳ đầu tiên
        //    LoadComboBoxFilterNganhHoc();
        //    LoadComboBoxInputLop(); // Load thông tin Lớp
        //    //LoadComboBoxInputSinhVien();
        //    LoadComboBoxInputMonHoc();
        //    //LoadComboBoxInputLanThi();
        //    LoadComboBoxFilterSinhVien();
        //    LoadComboBoxFilterLanThi();
        //    LoadComboBoxFilterLop(); // Load Lọc Theo Lớp
        //    LoadComboBoxFilterMonHoc(); // Load Lọc Theo Môn Học
        //}

        private void LoadUserPermissions()
        {

            // Assuming the user is logged in and you have access to the current userId
            // Replace with your actual user retrieval logic
            var userRoles = _userRoleService.GetUserRolesByUserId(_currentUserId).ToList();
            //// Fetch user's roles

            //var userRoles = _userRoleService.GetUserRolesByUserId(currentUserId).ToList();
            //var userRoles = _userRoleService.GetUserRolesByUserId(_currentUserId).ToList();
            // Fetch all permissions associated with these roles

            if (userRoles.Any())
            {
                foreach (var userRole in userRoles)
                {
                    userPermissions.AddRange(_rolePermissionService.GetPermissionsByRoleId(userRole.RoleId).Select(p => p.Permission.PermissionName));
                }

                // Enable or disable controls according to permissions

                // Buttons
                btnThem.Enabled = userPermissions.Contains("add_student");
                btnSua.Enabled = userPermissions.Contains("edit_student");
                btnXoa.Enabled = userPermissions.Contains("delete_student");

                // Menu items, etc
                btnXemDanhSachDiem.Enabled = userPermissions.Contains("view_course"); // assuming you have a view diem permission.
            }
            else
            {
                // Disable all the buttons if the user has not permissions.
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
            LoadComboBoxInputLop(); // Load thông tin Lớp

            LoadComboBoxInputMonHoc();
            FilterDGV();

        }
        private void LoadComboBoxFilterNamHoc()
        {
            namHocService = new();
            List<NamHoc> namHocs = namHocService.GetAllNamHocs().ToList();
            namHocs.Insert(0, new NamHoc { Id = -1, TenNamHoc = "Tất Cả" });
            cbbFilterByNamHoc.DataSource = namHocs;
            cbbFilterByNamHoc.DisplayMember = "TenNamHoc";
            cbbFilterByNamHoc.ValueMember = "Id";
            cbbFilterByNamHoc.SelectedIndex = 0;
        }

        private void LoadComboBoxFilterHocKy(int? idNamHoc = null)
        {
            hockyService = new();
            List<HocKy> hocKys;

            if (idNamHoc.HasValue && idNamHoc > 0)
            {
                hocKys = hockyService.GetAllHocKys()
                    .Where(hk => hk.IdNamHoc == idNamHoc)
                    .ToList();
            }
            else
            {
                hocKys = hockyService.GetAllHocKys().ToList();
            }

            hocKys.Insert(0, new HocKy { Id = -1, TenHocKy = "Tất Cả" });
            cbbFilterByHocKy.DataSource = hocKys;
            cbbFilterByHocKy.DisplayMember = "TenHocKy";
            cbbFilterByHocKy.ValueMember = "Id";
            cbbFilterByHocKy.SelectedIndex = 0;
        }

        //private void LoadComboBoxFilterNganhHoc(int? idHocKy = null)
        //{
        //    nganhHocService = new();
        //    List<NganhHoc> nganhHocs;

        //    if (idHocKy.HasValue && idHocKy > 0)
        //    {
        //        nganhHocs = (from n in nganhHocService.GetAllNganhHocs()
        //                     where n.LopHocs.Any(lop => lop.SinhViens.Any(sv => sv.Diems.Any(d => d.IdLanThiNavigation.IdMonHocNavigation.IdHocKy == idHocKy)))
        //                     select n)
        //                    .Distinct()
        //                    .ToList();
        //    }
        //    else
        //    {
        //        nganhHocs = nganhHocService.GetAllNganhHocs().ToList();
        //    }

        //    nganhHocs.Insert(0, new NganhHoc { Id = -1, TenNganhHoc = "Tất Cả" });
        //    cbbFilterByNganh.DataSource = nganhHocs;
        //    cbbFilterByNganh.DisplayMember = "TenNganhHoc";
        //    cbbFilterByNganh.ValueMember = "Id";
        //    cbbFilterByNganh.SelectedIndex = 0;
        //}
        //private void LoadComboBoxFilterNganhHoc(int? idHocKy = null)
        //{
        //    nganhHocService = new();
        //    List<QLDKhoa_CNTT.DAL.Entities.NganhHoc> nganhHocs;

        //    if (idHocKy.HasValue && idHocKy > 0)
        //    {
        //        nganhHocs = nganhHocService.GetAllNganhHocs()
        //            .Where(n => n.LopHocs.Any(lop => lop.SinhViens.Any(sv => sv.Diems.Any(d =>
        //                     d.IdLanThiNavigation != null &&
        //                     d.IdLanThiNavigation.IdMonHocNavigation != null &&
        //                     d.IdLanThiNavigation.IdMonHocNavigation.IdHocKy == idHocKy))))
        //            .Distinct()
        //            .ToList();
        //    }
        //    else
        //    {
        //        nganhHocs = nganhHocService.GetAllNganhHocs().ToList();
        //    }

        //    nganhHocs.Insert(0, new QLDKhoa_CNTT.DAL.Entities.NganhHoc { Id = -1, TenNganhHoc = "Tất Cả" });
        //    cbbFilterByNganh.DataSource = nganhHocs;
        //    cbbFilterByNganh.DisplayMember = "TenNganhHoc";
        //    cbbFilterByNganh.ValueMember = "Id";
        //    cbbFilterByNganh.SelectedIndex = 0;
        //}
        private void LoadComboBoxFilterNganhHoc(int? idHocKy = null, int? idNamHoc = null)
        {
            nganhHocService = new();
            List<QLDKhoa_CNTT.DAL.Entities.NganhHoc> nganhHocs;


            if (!(idHocKy.HasValue && idHocKy > 0) && !(idNamHoc.HasValue && idNamHoc > 0))
            {
                nganhHocs = nganhHocService.GetAllNganhHocs().ToList();
            }
            else if (idHocKy.HasValue && idHocKy > 0 && !(idNamHoc.HasValue && idNamHoc > 0))
            {
                nganhHocs = nganhHocService.GetAllNganhHocs()
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
                nganhHocs = nganhHocService.GetAllNganhHocs()
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
                nganhHocs = nganhHocService.GetAllNganhHocs().ToList();
            }

            nganhHocs.Insert(0, new QLDKhoa_CNTT.DAL.Entities.NganhHoc { Id = -1, TenNganhHoc = "Tất Cả" });
            cbbFilterByNganh.DataSource = nganhHocs;
            cbbFilterByNganh.DisplayMember = "TenNganhHoc";
            cbbFilterByNganh.ValueMember = "Id";
            cbbFilterByNganh.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterMonHoc(int? idNganh = null, int? idHocKy = null)
        {
            monHocService = new();
            List<MonHoc> monHocs;

            if (idNganh.HasValue && idNganh > 0 && idHocKy.HasValue && idHocKy > 0)
            {
                monHocs = monHocService.GetAllMonHocs()
                    .Where(mh => mh.IdHocKy == idHocKy &&
                                 nganhHocService.GetAllNganhHocs().Any(nh => nh.Id == idNganh &&
                                                                            nh.LopHocs.Any(lop => sinhVienService.GetAllSinhVien().Any(sv => sv.IdLop == lop.Id &&
                                                                                                                                   diemService.GetAllDiems().Any(d => d.IdLanThiNavigation.IdMonHoc == mh.Id)))))
                    .ToList();
            }
            else if (idHocKy.HasValue && idHocKy > 0)
            {
                monHocs = monHocService.GetAllMonHocs().Where(mh => mh.IdHocKy == idHocKy).ToList();
            }
            else
            {
                monHocs = monHocService.GetAllMonHocs().ToList();
            }

            monHocs.Insert(0, new MonHoc { Id = -1, TenMonHoc = "Tất Cả" });
            cbbFilterByMonHoc.DataSource = monHocs;
            cbbFilterByMonHoc.DisplayMember = "TenMonHoc";
            cbbFilterByMonHoc.ValueMember = "Id";
            cbbFilterByMonHoc.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterHinhThucThi(int? idMonHoc = null)
        {
            lanThiService = new();
            List<string> hinhThucThis;

            if (idMonHoc.HasValue && idMonHoc > 0)
            {
                hinhThucThis = lanThiService.GetAllLanThis()
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
            lanThiService = new();
            List<LanThi> lanThis;

            if (idMonHoc.HasValue && idMonHoc > 0 && !string.IsNullOrEmpty(hinhThucThi) && hinhThucThi != "Tất Cả")
            {
                lanThis = lanThiService.GetAllLanThis()
                    .Where(lt => lt.IdMonHoc == idMonHoc && lt.HinhThucThi == hinhThucThi)
                    .ToList();
            }
            else if (idMonHoc.HasValue && idMonHoc > 0)
            {
                lanThis = lanThiService.GetAllLanThis()
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
            sinhVienService = new();
            List<SinhVien> sinhViens;

            if (idLanThi.HasValue && idLanThi > 0)
            {
                sinhViens = sinhVienService.GetAllSinhVien()
                    .Where(sv => sv.Diems.Any(d => d.IdLanThi == idLanThi))
                    .ToList();

                if (idLop.HasValue && idLop > 0)
                {
                    sinhViens = sinhViens.Where(sv => sv.IdLop == idLop).ToList();
                }

            }
            else if (idLop.HasValue && idLop > 0)
            {
                sinhViens = sinhVienService.GetAllSinhVien()
                     .Where(sv => sv.IdLop == idLop)
                    .ToList();
            }
            else
            {
                sinhViens = sinhVienService.GetAllSinhVien().ToList();
            }

            sinhViens.Insert(0, new SinhVien { Id = -1, TenSinhVien = "Tất Cả" });
            cbbFilterBySinhVien.DataSource = sinhViens;
            cbbFilterBySinhVien.DisplayMember = "TenSinhVien";
            cbbFilterBySinhVien.ValueMember = "Id";
            cbbFilterBySinhVien.SelectedIndex = 0;
        }
        private void LoadComboBoxFilterLop(int? idNganh = null)
        {
            lopHocService = new();
            List<LopHoc> lopHocs;

            if (idNganh.HasValue && idNganh > 0)
            {
                lopHocs = lopHocService.GetAllLopHocs().Where(l => l.IdNganh == idNganh).ToList();
            }
            else
            {
                lopHocs = lopHocService.GetAllLopHocs().ToList();
            }

            lopHocs.Insert(0, new LopHoc { Id = -1, TenLop = "Tất Cả" });
            cbbFilterByLop.DataSource = lopHocs;
            cbbFilterByLop.DisplayMember = "TenLop";
            cbbFilterByLop.ValueMember = "Id";
            cbbFilterByLop.SelectedIndex = 0;
        }








        private void LoadComboBoxInputLop()
        {
            lopHocService = new();
            cbbInputLopHoc.DataSource = lopHocService.GetAllLopHocs();
            cbbInputLopHoc.DisplayMember = "TenLop";
            cbbInputLopHoc.ValueMember = "Id";
            cbbInputLopHoc.SelectedIndex = -1; // Không chọn mặc định
        }
        private void LoadComboBoxInputSinhVien(int? idLop)
        {
            sinhVienService = new();
            cbbInputSinhVien.DataSource = null;
            if (idLop.HasValue)
            {
                var lop = sinhVienService.GetAllSinhVien()
                                         .Where(sv => sv.IdLop == idLop)
                                         .ToList();
                cbbInputSinhVien.DataSource = lop;
            }
            else
            {
                cbbInputSinhVien.DataSource = sinhVienService.GetAllSinhVien(); // Nếu không có lớp nào được chọn, hiển thị tất cả
            }
            cbbInputSinhVien.DisplayMember = "TenSinhVien";
            cbbInputSinhVien.ValueMember = "Id";
            cbbInputSinhVien.SelectedIndex = -1;
        }
        private void LoadComboBoxInputMonHoc()
        {
            monHocService = new();
            cbbInputMonHoc.DataSource = monHocService.GetAllMonHocs();
            cbbInputMonHoc.DisplayMember = "TenMonHoc";
            cbbInputMonHoc.ValueMember = "Id";
            cbbInputMonHoc.SelectedIndex = -1;
        }
        private void LoadComboBoxInputHinhThucThi(int? idMonHoc)
        {
            cbbInputHinhThucThi.DataSource = null;
            if (idMonHoc.HasValue)
            {
                var hinhThucThis = lanThiService.GetAllLanThis()
                                              .Where(lt => lt.IdMonHoc == idMonHoc)
                                              .Select(lt => lt.HinhThucThi)
                                              .Distinct()
                                              .ToList();
                cbbInputHinhThucThi.DataSource = hinhThucThis;
            }
            cbbInputHinhThucThi.SelectedIndex = -1;
        }
        private void LoadComboBoxInputLanThi(int? idMonHoc = null, string hinhThucThi = null)
        {
            lanThiService = new();
            List<LanThi> lanThi;
            if (idMonHoc.HasValue && !string.IsNullOrEmpty(hinhThucThi))
            {
                lanThi = lanThiService.GetAllLanThis()
                                      .Where(lt => lt.IdMonHoc == idMonHoc.Value && lt.HinhThucThi == hinhThucThi)
                                      .ToList();
            }
            else
            {
                lanThi = new List<LanThi>();
            }
            cbbInputLanThi.DataSource = null;
            cbbInputLanThi.DataSource = lanThi;
            cbbInputLanThi.DisplayMember = "LanThi1";
            cbbInputLanThi.ValueMember = "Id";
            cbbInputLanThi.SelectedIndex = -1;
        }



        private void InitializeDataGridView()
        {
            dgvDiem.SelectionChanged -= dgvDiem_SelectionChanged;
            dgvDiem.DataSource = null;
            // Thêm các cột mới vào DataGridView chỉ một lần
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
            diemService = new();
            dgvDiem.DataSource = diemService.GetAllDiems().ToList(); ;
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
            cbbInputMonHoc.SelectedIndexChanged += CbbInputMonHoc_SelectedIndexChanged;
            cbbInputHinhThucThi.SelectedIndexChanged += CbbInputHinhThucThi_SelectedIndexChanged;
            cbbInputLopHoc.SelectedIndexChanged += CbbInputLopHoc_SelectedIndexChanged;
            cbbFilterByLop.SelectedIndexChanged += CbbFilterByLop_SelectedIndexChanged;
            cbbFilterByMonHoc.SelectedIndexChanged += CbbFilterByMonHoc_SelectedIndexChanged;
            cbbFilterByHinhThucThi.SelectedIndexChanged += CbbFilterByHinhThucThi_SelectedIndexChanged;


        }



        private void CbbFilterByNamHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int idNamHoc = Convert.ToInt32(cbbFilterByNamHoc.SelectedValue);
            LoadComboBoxFilterHocKy(idNamHoc);
            LoadComboBoxFilterNganhHoc(-1, idNamHoc);
            LoadComboBoxFilterMonHoc(-1, -1);
            LoadComboBoxFilterLanThi(-1);
            LoadComboBoxFilterSinhVien(-1);
            LoadComboBoxFilterLop(-1);
            FilterDGV();
        }
        private void CbbFilterByHocKy_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int idHocKy = Convert.ToInt32(cbbFilterByHocKy.SelectedValue);
            int idNamHoc = Convert.ToInt32(cbbFilterByNamHoc.SelectedValue);
            LoadComboBoxFilterNganhHoc(idHocKy, idNamHoc);
            LoadComboBoxFilterMonHoc(-1, idHocKy);
            LoadComboBoxFilterLanThi(-1);
            LoadComboBoxFilterSinhVien(-1);
            LoadComboBoxFilterLop(-1);
            FilterDGV();
        }
        private void CbbFilterByNganh_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int idNganh = Convert.ToInt32(cbbFilterByNganh.SelectedValue);
            int idHocKy = Convert.ToInt32(cbbFilterByHocKy.SelectedValue);
            LoadComboBoxFilterMonHoc(idNganh, idHocKy);
            LoadComboBoxFilterLanThi(-1);
            LoadComboBoxFilterSinhVien(-1);
            LoadComboBoxFilterLop(idNganh);
            FilterDGV();
        }
        private void CbbFilterByMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int idMonHoc = Convert.ToInt32(cbbFilterByMonHoc.SelectedValue);
            LoadComboBoxFilterLanThi(idMonHoc);
            LoadComboBoxFilterSinhVien(-1);
            FilterDGV();
        }
        private void CbbFilterByHinhThucThi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && cbbFilterByHinhThucThi.SelectedItem is string hinhThucThi)
            {
                LoadComboBoxFilterLanThi(idMonHoc == -1 ? null : (int?)idMonHoc, hinhThucThi == "Tất Cả" ? null : hinhThucThi);
                // Reset combobox con
                LoadComboBoxFilterSinhVien();
                FilterDGV();
            }
        }

        private void CbbFilterByLanThi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int idLanThi = Convert.ToInt32(cbbFilterByLanThi.SelectedValue);
            LoadComboBoxFilterSinhVien(idLanThi);
            FilterDGV();
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
                LoadComboBoxFilterSinhVien(null, idLop); // Pass the selected Lop id here
                FilterDGV();
            }
            else if (cbbFilterByLop.SelectedValue is int idLopInt)
            {
                LoadComboBoxFilterSinhVien(null, idLopInt);
                FilterDGV();
            }
        }







        private void CbbInputLopHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbInputLopHoc.SelectedValue is int idLop)
            {
                LoadComboBoxInputSinhVien(idLop);
            }
            else
            {
                LoadComboBoxInputSinhVien(null); // Nếu không có lớp nào được chọn, hiển thị tất cả sinh viên
            }
        }

        private void CbbInputHinhThucThi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbInputMonHoc.SelectedValue is int idMonHoc && cbbInputHinhThucThi.SelectedItem is string hinhThucThi)
            {
                LoadComboBoxInputLanThi(idMonHoc, hinhThucThi);
            }
            else
            {
                LoadComboBoxInputLanThi(cbbInputMonHoc.SelectedValue as int?); // Load based on monhoc only
            }
        }

        private void CbbInputMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbInputMonHoc.SelectedValue != null && cbbInputMonHoc.SelectedValue is int idMonHoc)
            {
                LoadComboBoxInputHinhThucThi(idMonHoc);
                LoadComboBoxInputLanThi(idMonHoc); //  tất cả lanthi cho monhoc này
            }
            else
            {
                cbbInputHinhThucThi.DataSource = null;
                LoadComboBoxInputLanThi();
            }
            cbbInputLanThi.SelectedIndex = -1; // Reset Lan Thi combobox
        }
        #endregion

        #region Filter Data


        //private void FilterDGVByLanThi()
        //{
        //    if (cbbFilterByLanThi.SelectedIndex == 0 && cbbFilterByLanThi.SelectedValue is int && (int)cbbFilterByLanThi.SelectedValue == -1)
        //    {
        //        LoadDataIntoDataGridView();
        //        return;
        //    }
        //    if (cbbFilterByLanThi.SelectedValue is int idLanThi)
        //    {
        //        diemService = new();
        //        dgvDiem.DataSource = diemService.GetAllDiems().Where(mh => mh.IdLanThi == idLanThi).ToList();
        //        ReNameAndHideCollumn();
        //        dgvDiem.CurrentCell = null;
        //        dgvDiem_SelectionChanged(null, null);
        //    }
        //    else if (cbbFilterByLanThi.SelectedValue is LanThi lanThi)
        //    {
        //        diemService = new();
        //        dgvDiem.DataSource = diemService.GetAllDiems().Where(mh => mh.IdLanThi == lanThi.Id).ToList();
        //        ReNameAndHideCollumn();
        //        dgvDiem.CurrentCell = null;
        //        dgvDiem_SelectionChanged(null, null);
        //    }
        //    if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
        //    {
        //        dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
        //    }
        //    if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
        //    {
        //        dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
        //    }
        //}

        //private void FilterDGVBySinhVien()
        //{
        //    if (cbbFilterBySinhVien.SelectedIndex == 0 && cbbFilterBySinhVien.SelectedValue is int && (int)cbbFilterBySinhVien.SelectedValue == -1)
        //    {
        //        LoadDataIntoDataGridView();
        //        return;
        //    }
        //    if (cbbFilterBySinhVien.SelectedValue is int idSinhVien)
        //    {
        //        diemService = new();
        //        dgvDiem.DataSource = diemService.GetBySinhVien(idSinhVien);
        //        ReNameAndHideCollumn();
        //        dgvDiem.CurrentCell = null;
        //        dgvDiem_SelectionChanged(null, null);

        //    }
        //    else if (cbbFilterBySinhVien.SelectedValue is SinhVien sinhVien)
        //    {
        //        diemService = new();
        //        dgvDiem.DataSource = diemService.GetBySinhVien(sinhVien.Id);
        //        ReNameAndHideCollumn();
        //        dgvDiem.CurrentCell = null;
        //        dgvDiem_SelectionChanged(null, null);
        //    }
        //    if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
        //    {
        //        dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
        //    }
        //    if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
        //    {
        //        dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
        //    }
        //}
        private void FilterDGVBySinhVien()
        {
            if (cbbFilterBySinhVien.SelectedIndex == 0 && cbbFilterBySinhVien.SelectedValue is int && (int)cbbFilterBySinhVien.SelectedValue == -1)
            {
                // Nếu chọn "Tất Cả", hiển thị tất cả dữ liệu
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterBySinhVien.SelectedValue is int idSinhVien)
            {
                diemService = new();
                // Lấy danh sách điểm theo Id Sinh Viên và chuyển đổi sang List
                dgvDiem.DataSource = diemService.GetAllDiems().Where(d => d.IdSinhVien == idSinhVien).ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }
            // Bạn có thể bỏ phần này nếu không muốn xử lý trường hợp chọn một đối tượng SinhVien trực tiếp
            //else if (cbbFilterBySinhVien.SelectedValue is SinhVien sinhVien)
            //{
            //    diemService = new();
            //    dgvDiem.DataSource = diemService.GetAllDiems().Where(d => d.IdSinhVien == sinhVien.Id).ToList();
            //    ReNameAndHideCollumn();
            //    dgvDiem.CurrentCell = null;
            //    dgvDiem_SelectionChanged(null, null);
            //}

            // Đảm bảo các cột Navigation không hiển thị
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
                // Nếu chọn "Tất Cả", hiển thị tất cả dữ liệu
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterByLanThi.SelectedValue is int idLanThi)
            {
                diemService = new();
                // Lấy danh sách điểm theo Id Lần Thi và chuyển đổi sang List
                dgvDiem.DataSource = diemService.GetAllDiems().Where(d => d.IdLanThi == idLanThi).ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }
            // Bạn có thể bỏ phần này nếu không muốn xử lý trường hợp chọn một đối tượng LanThi trực tiếp
            //else if (cbbFilterByLanThi.SelectedValue is LanThi lanThi)
            //{
            //    diemService = new();
            //    dgvDiem.DataSource = diemService.GetAllDiems().Where(d => d.IdLanThi == lanThi.Id).ToList();
            //    ReNameAndHideCollumn();
            //    dgvDiem.CurrentCell = null;
            //    dgvDiem_SelectionChanged(null, null);
            //}

            // Đảm bảo các cột Navigation không hiển thị
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
                // Nếu chọn "Tất Cả", hiển thị tất cả dữ liệu
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterByLop.SelectedValue is int idLop)
            {
                diemService = new();
                // Lấy danh sách điểm của các sinh viên thuộc lớp được chọn và chuyển đổi sang List
                dgvDiem.DataSource = diemService.GetAllDiems()
                                                 .Where(d => d.IdSinhVienNavigation != null && d.IdSinhVienNavigation.IdLop == idLop)
                                                 .ToList();
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }

            // Đảm bảo các cột Navigation không hiển thị
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
                // Nếu chọn "Tất Cả", hiển thị tất cả dữ liệu
                LoadDataIntoDataGridView();
                return;
            }

            if (cbbFilterByMonHoc.SelectedValue is int idMonHoc)
            {
                diemService = new();
                // Sử dụng phương thức GetByMonHoc mới
                dgvDiem.DataSource = diemService.GetByMonHoc(idMonHoc);
                ReNameAndHideCollumn();
                dgvDiem.CurrentCell = null;
                dgvDiem_SelectionChanged(null, null);
            }

            // Đảm bảo các cột Navigation không hiển thị
            if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
            {
                dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
            }
            if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
            {
                dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
            }
        }
        //private void FilterDGV()
        //{
        //    diemService = new();
        //    var query = diemService.GetAllDiems().ToList();

        //    if (cbbFilterByHocKy.SelectedValue is int idHocKy && idHocKy > 0)
        //    {
        //        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.IdMonHocNavigation != null && d.IdLanThiNavigation.IdMonHocNavigation.IdHocKy == idHocKy);
        //    }

        //    if (cbbFilterByNganh.SelectedValue is int idNganh && idNganh > 0)
        //    {
        //        query = query.Where(d => d.IdSinhVienNavigation != null && d.IdSinhVienNavigation.IdLopNavigation != null && d.IdSinhVienNavigation.IdLopNavigation.IdNganh == idNganh);
        //    }

        //    if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && idMonHoc > 0)
        //    {
        //        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.IdMonHoc == idMonHoc);
        //    }

        //    if (cbbFilterByLop.SelectedValue is int idLop && idLop > 0)
        //    {
        //        query = query.Where(d => d.IdSinhVienNavigation != null && d.IdSinhVienNavigation.IdLop == idLop);
        //    }

        //    if (cbbFilterBySinhVien.SelectedValue is int idSinhVien && idSinhVien > 0)
        //    {
        //        query = query.Where(d => d.IdSinhVien == idSinhVien);
        //    }

        //    if (cbbFilterByLanThi.SelectedValue is int idLanThi && idLanThi > 0)
        //    {
        //        query = query.Where(d => d.IdLanThi == idLanThi);
        //    }

        //    dgvDiem.DataSource = query.ToList();
        //    ReNameAndHideCollumn();
        //    dgvDiem.CurrentCell = null;
        //    dgvDiem_SelectionChanged(null, null);

        //    if (dgvDiem.Columns.Contains("IdSinhVienNavigation"))
        //    {
        //        dgvDiem.Columns["IdSinhVienNavigation"].Visible = false;
        //    }
        //    if (dgvDiem.Columns.Contains("IdLanThiNavigation"))
        //    {
        //        dgvDiem.Columns["IdLanThiNavigation"].Visible = false;
        //    }
        //}
        private void FilterDGV()
        {
            try
            {
                diemService = new();
                var query = diemService.GetAllDiems().AsQueryable();

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
                    dgvDiem.DataSource = diemService.GetDiemByNganhHoc(idNganh);
                }
                else if (cbbFilterByLop.SelectedValue is int idLop && idLop > -1)
                {
                    // Lọc theo lớp học
                    // Lấy danh sách sinh viên thuộc lớp học đã chọn
                    var danhSachSinhVien = sinhVienService.GetAllSinhVien().Where(sv => sv.IdLop == idLop).Select(sv => sv.Id).ToList();

                    // Lọc điểm của các sinh viên thuộc lớp học đã chọn
                    query = diemService.GetAllDiems().Where(d => danhSachSinhVien.Contains(d.IdSinhVien)).AsQueryable();
                    // Apply other filters
                    if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && idMonHoc > -1)
                    {
                        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.IdMonHoc == idMonHoc);
                    }
                    if (cbbFilterByHinhThucThi.SelectedItem is string hinhThucThi && hinhThucThi != "Tất Cả")
                    {
                        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.HinhThucThi == hinhThucThi);
                    }
                    if (cbbFilterByLanThi.SelectedValue is int idLanThi && idLanThi > -1)
                    {
                        query = query.Where(d => d.IdLanThi == idLanThi);
                    }
                    if (cbbFilterBySinhVien.SelectedValue is int idSinhVien && idSinhVien > -1)
                    {
                        query = query.Where(d => d.IdSinhVien == idSinhVien);
                    }


                    dgvDiem.DataSource = query.ToList();
                }

                else
                {
                    // Nếu không lọc theo ngành hoặc lớp cụ thể, tiếp tục lọc theo các tiêu chí khác
                    query = diemService.GetAllDiems().AsQueryable();

                    if (cbbFilterByMonHoc.SelectedValue is int idMonHoc && idMonHoc > -1)
                    {
                        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.IdMonHoc == idMonHoc);
                    }
                    if (cbbFilterByHinhThucThi.SelectedItem is string hinhThucThi && hinhThucThi != "Tất Cả")
                    {
                        query = query.Where(d => d.IdLanThiNavigation != null && d.IdLanThiNavigation.HinhThucThi == hinhThucThi);
                    }

                    if (cbbFilterByLanThi.SelectedValue is int idLanThi && idLanThi > -1)
                    {
                        query = query.Where(d => d.IdLanThi == idLanThi);
                    }
                    if (cbbFilterBySinhVien.SelectedValue is int idSinhVien && idSinhVien > -1)
                    {
                        query = query.Where(d => d.IdSinhVien == idSinhVien);
                    }
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
                    using (var context = new QuanLyDiemKhoaCnttContext())
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

                // Lấy đối tượng lan thi
                lanThiService = new();
                var lanThi = lanThiService.GetALanThi(diem.IdLanThi);
                if (lanThi != null)
                {
                    txtOutputLanThi.Text = lanThi.LanThi1.ToString();
                }
                else
                {
                    txtOutputLanThi.Text = string.Empty;
                }
                // Lấy đối tượng sinh vien
                sinhVienService = new();
                var sinhVien = sinhVienService.GetAnSinhVien(diem.IdSinhVien);
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

        #region Handle TextBox, Clear Textbox
        private void HideTextBoxOutput()
        {
            txtOutputId.Enabled = false;
            txtOutputDiem.Enabled = false;
            txtOutputSinhVien.Enabled = false;
            txtOutputLanThi.Enabled = false;

        }
        private void HideTextBoxInput()
        {
            txtInputId.Enabled = false;

        }
        private void MakeBlankOfTextBox()
        {
            txtOutputId.Clear();
            txtOutputDiem.Clear();
            txtOutputSinhVien.Clear();
            txtOutputLanThi.Clear();

        }
        private void ClearInputTextbox()
        {
            txtInputId.Clear();
            txtInputDiem.Clear();
            cbbInputSinhVien.SelectedIndex = -1;

            cbbInputMonHoc.SelectedIndex = -1; // Reset MonHoc ComboBox
            cbbInputHinhThucThi.DataSource = null;

            cbbInputHinhThucThi.SelectedIndex = -1;
            cbbInputLanThi.DataSource = null;
            cbbInputLanThi.SelectedIndex = -1;
            cbbInputLopHoc.SelectedIndex = -1;
        }
        #endregion

        #region Validate Input
        private bool ValidateInput()
        {
            // Validate dữ liệu

            if (cbbInputLopHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Lớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }

            if (cbbInputSinhVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Sinh Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            int idSinhVien;

            if (!int.TryParse(cbbInputSinhVien.SelectedValue.ToString(), out idSinhVien))
            {
                MessageBox.Show("Sinh Viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputSinhVien.Focus();
                return false; // Thoát nếu không hợp lệ
            }

            if (cbbInputMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputMonHoc.Focus();
                return false;
            }
            if (cbbInputHinhThucThi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Hình thức thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputHinhThucThi.Focus();
                return false;
            }

            if (cbbInputLanThi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Lần thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputLanThi.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            int idLanThi;
            if (!int.TryParse(cbbInputLanThi.SelectedValue.ToString(), out idLanThi))
            {
                MessageBox.Show("Lần thi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbInputLanThi.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            if (string.IsNullOrWhiteSpace(txtInputDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputDiem.Focus();
                return false; // Thoát nếu không hợp lệ
            }
            // Validate điểm là số thực
            if (!double.TryParse(txtInputDiem.Text, out double diem))
            {
                MessageBox.Show("Điểm phải là một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputDiem.Focus();
                return false;
            }
            return true;
        }
        private bool IsDuplicateDiem(int idSinhVien, int idLanThi, int? currentDiemId = null)
        {
            diemService = new();
            return diemService.GetAllDiems().Any(d =>
                d.IdSinhVien == idSinhVien &&
                d.IdLanThi == idLanThi &&
                (!currentDiemId.HasValue || d.Id != currentDiemId.Value)
            );
        }
        #endregion

        #region Handle Button
        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    isAddingNew = true;
        //    if (ValidateInput() == false) return;
        //    if (isAddingNew) // Thêm mới
        //    {
        //        try
        //        {
        //            // lấy id

        //            int idMonHoc = (int)cbbInputMonHoc.SelectedValue;

        //            int idLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
        //            int idSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());
        //            idLanThiInput = idLanThi;
        //            idSinhVienInput = idSinhVien;
        //            Diem diem = new()
        //            {
        //                IdLanThi = idLanThi,
        //                IdSinhVien = idSinhVien,
        //                Diem1 = double.Parse(txtInputDiem.Text),

        //            };
        //            diemService.CreateADiem(diem);

        //            MessageBox.Show("Thêm điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            ClearInputTextbox();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        finally
        //        {
        //            FilterDGVBySinhVien();
        //            FilterDGVByLanThi();
        //            FilterDGVByLop();
        //            FilterDGVByMonHoc();
        //            isAddingNew = false;
        //            //ClearInputTextbox();
        //            if (idLanThiInput.HasValue) cbbFilterByLanThi.SelectedValue = idLanThiInput;
        //            if (idSinhVienInput.HasValue) cbbFilterBySinhVien.SelectedValue = idSinhVienInput;
        //            //LoadDataIntoDataGridView();
        //        }
        //    }
        //}
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            if (!userPermissions.Contains("add_student"))
            {
                MessageBox.Show("Bạn không có quyền thêm điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidateInput()) return;

            int idLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
            int idSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());

            if (IsDuplicateDiem(idSinhVien, idLanThi))
            {
                MessageBox.Show("Điểm cho sinh viên này trong môn học và lần thi này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAddingNew) // Thêm mới
            {
                try
                {
                    // lấy id
                    int idMonHoc = (int)cbbInputMonHoc.SelectedValue;
                    idLanThiInput = idLanThi;
                    idSinhVienInput = idSinhVien;
                    Diem diem = new()
                    {
                        IdLanThi = idLanThi,
                        IdSinhVien = idSinhVien,
                        Diem1 = double.Parse(txtInputDiem.Text),
                    };
                    diemService.CreateADiem(diem);

                    MessageBox.Show("Thêm điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //FilterDGVBySinhVien();
                    //FilterDGVByLanThi();
                    //FilterDGVByLop();
                    //FilterDGVByMonHoc();

                    FilterDGV();

                    isAddingNew = false;
                    if (idLanThiInput.HasValue) cbbFilterByLanThi.SelectedValue = idLanThiInput;
                    if (idSinhVienInput.HasValue) cbbFilterBySinhVien.SelectedValue = idSinhVienInput;
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("edit_student"))
            {
                MessageBox.Show("Bạn không có quyền sửa điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isEditing)
            {
                // Lấy thông tin lần thi
                diemService = new();
                Diem diem = diemService.GetADiem(id);

                if (diem == null)
                {
                    MessageBox.Show("Không Tìm Thấy Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đưa dữ liệu lên các ô input
                txtInputId.Text = diem.Id.ToString();
                txtInputDiem.Text = diem.Diem1.ToString();
                //cbbInputLanThi.SelectedValue = diem.IdLanThi;
                //cbbInputSinhVien.SelectedValue = diem.IdSinhVien;
                //Lấy LanThi tương ứng để chọn MonHoc

                // Lấy đối tượng SinhVien để lấy IdLop
                var sinhVien = sinhVienService.GetAnSinhVien(diem.IdSinhVien);
                if (sinhVien != null)
                {
                    // **Đặt cbbInputLopHoc TRƯỚC**
                    cbbInputLopHoc.SelectedValue = sinhVien.IdLop;

                    // **Sau đó đặt cbbInputSinhVien**
                    cbbInputSinhVien.SelectedValue = diem.IdSinhVien;
                }

                var lanThi = lanThiService.GetALanThi(diem.IdLanThi);
                if (lanThi != null)
                {
                    cbbInputMonHoc.SelectedValue = lanThi.IdMonHoc;
                    LoadComboBoxInputHinhThucThi(lanThi.IdMonHoc);
                    cbbInputHinhThucThi.SelectedItem = lanThi.HinhThucThi;
                    LoadComboBoxInputLanThi(lanThi.IdMonHoc, lanThi.HinhThucThi);
                    cbbInputLanThi.SelectedValue = diem.IdLanThi;
                }

                // Đặt trạng thái sửa và lưu ID
                isEditing = true;
                currentEditId = id;
                // Đổi text nút sửa để biết đang ở trạng thái edit
                btnSua.Text = "Cập nhật";
                btnXoa.Enabled = false;
                btnThem.Enabled = false;

                return; // Thoát khỏi hàm để chờ người dùng chỉnh sửa
            }
            else
            {
                // Validate dữ liệu
                if (!ValidateInput())
                {
                    return;
                }
                try
                {
                    diemService = new();
                    Diem diem = diemService.GetADiem((int)currentEditId);
                    if (diem == null)
                    {
                        MessageBox.Show("Không Tìm Thấy Điểm Để Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Cập nhật thông tin điểm
                    diem.Diem1 = double.Parse(txtInputDiem.Text);
                    diem.IdLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
                    diem.IdSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());
                    int? selectedValuedLanThi = int.Parse(cbbInputLanThi.SelectedValue.ToString());
                    int? selectedValuedSinhVien = int.Parse(cbbInputSinhVien.SelectedValue.ToString());

                    // Gọi service để cập nhật
                    diemService.UpdataADiem(diem);

                    MessageBox.Show("Sửa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputTextbox(); // Xóa thông tin trong các ô input
                                         // Set the selected value for the filter combobox before filtering
                    if (selectedValuedLanThi.HasValue)
                    {
                        cbbFilterByLanThi.SelectedValue = selectedValuedLanThi;
                    }
                    if (selectedValuedSinhVien.HasValue)
                    {
                        cbbFilterBySinhVien.SelectedValue = selectedValuedSinhVien;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //FilterDGVBySinhVien();
                    //FilterDGVByLanThi();
                    //FilterDGVByLop();
                    //FilterDGVByMonHoc();


                    FilterDGV();

                    isEditing = false;
                    currentEditId = null;
                    btnSua.Text = "Sửa";
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("delete_student"))
            {
                MessageBox.Show("Bạn không có quyền xóa điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtOutputId.Text, out int id))
            {
                MessageBox.Show("Vui Lòng Chọn Điểm Để Xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                diemService = new();
                var diem = diemService.GetADiem(id);
                if (diem == null)
                {
                    MessageBox.Show("Không tìm thấy điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin sinh viên
                var sinhVien = sinhVienService.GetAnSinhVien(diem.IdSinhVien);
                string tenSinhVien = sinhVien?.TenSinhVien ?? "Unknown";

                // co id roi bat dau xoa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa điểm {diem.Diem1} của sinh viên: {tenSinhVien} ?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int? selectedValuedLanThi = diem.IdLanThi;
                    int? selectedValuedSinhVien = diem.IdSinhVien;

                    diemService.DeleteADiem(id);
                    MessageBox.Show("Xoa điểm Thanh Cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //FilterDGVBySinhVien();
                    //FilterDGVByLanThi();
                    //FilterDGVByLop();
                    //FilterDGVByMonHoc();


                    FilterDGV();

                    //if (cbbLocTheoLop.Items.Count > 0 && selectedValuedLops != null)
                    //{
                    cbbFilterByLanThi.SelectedValue = selectedValuedLanThi;
                    cbbFilterBySinhVien.SelectedValue = selectedValuedSinhVien;
                    //}
                    MakeBlankOfTextBox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            MakeBlankOfTextBox();
            ClearInputTextbox();
            cbbFilterByNamHoc.SelectedValue = -1;
            cbbFilterByHocKy.SelectedValue = -1;
            cbbFilterByNganh.SelectedValue = -1;
            cbbFilterByLanThi.SelectedValue = -1;
            cbbFilterBySinhVien.SelectedValue = -1;
            cbbFilterByLop.SelectedValue = -1;  // Reset Lọc Theo Lớp
            cbbFilterByMonHoc.SelectedValue = -1; // Reset Lọc Theo Môn Học

            cbbInputMonHoc.SelectedIndex = -1;
            cbbInputLanThi.DataSource = null;
            cbbInputLanThi.SelectedIndex = -1;
            cbbInputSinhVien.SelectedValue = -1;
        }

        #endregion

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

        private void btnxemdiembangdiem_Click(object sender, EventArgs e)
        {
            if (!userPermissions.Contains("view_student"))
            {
                MessageBox.Show("Bạn không có quyền  điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReportForm reportForm = new ReportForm("xemdiem");
            reportForm.ShowDialog();
        }
    }
}