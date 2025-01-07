using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("LanThi")]
public partial class LanThi
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("LanThi")]
    public int LanThi1 { get; set; }

    public DateOnly NgayThi { get; set; }

    [Column("ID_MonHoc")]
    public int IdMonHoc { get; set; }

    [StringLength(50)]
    public string? HinhThucThi { get; set; }

    [InverseProperty("IdLanThiNavigation")]
    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    [ForeignKey("IdMonHoc")]
    [InverseProperty("LanThis")]
    public virtual MonHoc IdMonHocNavigation { get; set; } = null!;
}
