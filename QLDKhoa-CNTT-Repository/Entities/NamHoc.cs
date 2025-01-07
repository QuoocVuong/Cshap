using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLDKhoa_CNTT.DAL.Entities;

[Table("NamHoc")]
public partial class NamHoc
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string TenNamHoc { get; set; } = null!;

    [InverseProperty("IdNamHocNavigation")]
    public virtual ICollection<HocKy> HocKies { get; set; } = new List<HocKy>();
}
