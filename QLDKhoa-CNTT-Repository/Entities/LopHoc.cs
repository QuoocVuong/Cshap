using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("LopHoc")]
public partial class LopHoc
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string TenLop { get; set; } = null!;

    [Column("ID_Nganh")]
    public int IdNganh { get; set; }

    [ForeignKey("IdNganh")]
    [InverseProperty("LopHocs")]
    public virtual NganhHoc IdNganhNavigation { get; set; } = null!;

    [InverseProperty("IdLopNavigation")]
    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
