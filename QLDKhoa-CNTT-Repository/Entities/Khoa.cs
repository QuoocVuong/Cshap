using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("Khoa")]
public partial class Khoa
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    public string TenKhoa { get; set; } = null!;

    [InverseProperty("IdKhoaNavigation")]
    public virtual ICollection<NganhHoc> NganhHocs { get; set; } = new List<NganhHoc>();
}
