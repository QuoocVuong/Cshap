using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("Diem")]
public partial class Diem
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_SinhVien")]
    public int IdSinhVien { get; set; }

    [Column("ID_LanThi")]
    public int IdLanThi { get; set; }

    [Column("Diem")]
    public double? Diem1 { get; set; }

    [ForeignKey("IdLanThi")]
    [InverseProperty("Diems")]
    public virtual LanThi IdLanThiNavigation { get; set; } = null!;

    [ForeignKey("IdSinhVien")]
    [InverseProperty("Diems")]
    public virtual SinhVien IdSinhVienNavigation { get; set; } = null!;
}
