using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class TaiKhoan
{
    public int Id { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int? Quyen { get; set; }

    public int? IdNguoiDung { get; set; }

    public int? LoaiNguoiDung { get; set; }

    public string? GhiChu { get; set; }
}
