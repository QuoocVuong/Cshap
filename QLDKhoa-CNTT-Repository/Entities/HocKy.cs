using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("HocKy")]
public partial class HocKy
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string TenHocKy { get; set; } = null!;

    [Column("ID_NamHoc")]
    public int IdNamHoc { get; set; }

    [ForeignKey("IdNamHoc")]
    [InverseProperty("HocKies")]
    public virtual NamHoc IdNamHocNavigation { get; set; } = null!;

    [InverseProperty("IdHocKyNavigation")]
    public virtual ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();
}
