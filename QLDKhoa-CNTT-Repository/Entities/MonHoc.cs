using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("MonHoc")]
[Index("MaMonHoc", Name = "UQ__MonHoc__4127737E3AA595E0", IsUnique = true)]
public partial class MonHoc
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string MaMonHoc { get; set; } = null!;

    [StringLength(255)]
    public string TenMonHoc { get; set; } = null!;

    public int? SoGio { get; set; }

    [Column("ID_HocKy")]
    public int IdHocKy { get; set; }

    [ForeignKey("IdHocKy")]
    [InverseProperty("MonHocs")]
    public virtual HocKy IdHocKyNavigation { get; set; } = null!;

    [InverseProperty("IdMonHocNavigation")]
    public virtual ICollection<LanThi> LanThis { get; set; } = new List<LanThi>();

    [ForeignKey("IdMonHoc")]
    [InverseProperty("IdMonHocs")]
    public virtual ICollection<GiangVien> IdGiangViens { get; set; } = new List<GiangVien>();
}
