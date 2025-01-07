using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("NganhHoc")]
public partial class NganhHoc
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    public string TenNganhHoc { get; set; } = null!;

    [Column("ID_Khoa")]
    public int IdKhoa { get; set; }

    [ForeignKey("IdKhoa")]
    [InverseProperty("NganhHocs")]
    public virtual Khoa IdKhoaNavigation { get; set; } = null!;

    [InverseProperty("IdNganhNavigation")]
    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
