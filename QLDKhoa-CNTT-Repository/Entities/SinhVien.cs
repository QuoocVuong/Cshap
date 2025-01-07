using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("SinhVien")]
[Index("MaSinhVien", Name = "UC_MaSinhVien", IsUnique = true)]
[Index("MaSinhVien", Name = "UQ__SinhVien__939AE7745FBEFB86", IsUnique = true)]
public partial class SinhVien
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string MaSinhVien { get; set; } = null!;

    [StringLength(255)]
    public string TenSinhVien { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    [Column("ID_Lop")]
    public int IdLop { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("IdSinhVienNavigation")]
    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    [ForeignKey("IdLop")]
    [InverseProperty("SinhViens")]
    public virtual LopHoc IdLopNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("SinhViens")]
    public virtual User? User { get; set; }
}
