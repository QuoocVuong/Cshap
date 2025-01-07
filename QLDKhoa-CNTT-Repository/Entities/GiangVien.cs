using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("GiangVien")]
[Index("MaGiangVien", Name = "UQ__GiangVie__C03BEEBB000B30CE", IsUnique = true)]
public partial class GiangVien
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string MaGiangVien { get; set; } = null!;

    [StringLength(255)]
    public string TenGiangVien { get; set; } = null!;

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("GiangViens")]
    public virtual User? User { get; set; }

    [ForeignKey("IdGiangVien")]
    [InverseProperty("IdGiangViens")]
    public virtual ICollection<MonHoc> IdMonHocs { get; set; } = new List<MonHoc>();
}
