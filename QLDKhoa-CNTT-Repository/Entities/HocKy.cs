using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class HocKy
{
    public int Id { get; set; }

    public string TenHocKy { get; set; } = null!;

    public int IdNamHoc { get; set; }

    public virtual NamHoc IdNamHocNavigation { get; set; } = null!;

    public virtual ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();
}
