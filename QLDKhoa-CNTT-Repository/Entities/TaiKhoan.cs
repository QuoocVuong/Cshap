using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("TaiKhoan")]
[Index("TenDangNhap", Name = "UQ__TaiKhoan__55F68FC096E6CC06", IsUnique = true)]
public partial class TaiKhoan
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string TenDangNhap { get; set; } = null!;

    [StringLength(50)]
    public string MatKhau { get; set; } = null!;

    public int? Quyen { get; set; }

    [Column("ID_NguoiDung")]
    public int? IdNguoiDung { get; set; }

    public int? LoaiNguoiDung { get; set; }

    [StringLength(255)]
    public string? GhiChu { get; set; }
}
