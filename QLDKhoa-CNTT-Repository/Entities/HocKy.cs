using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class HocKy
{
    public int Id { get; set; }

    public string TenHocKy { get; set; } = null!;

    public int IdNganhHoc { get; set; }

    public virtual ICollection<HinhThuc> HinhThucs { get; set; } = new List<HinhThuc>();

    public virtual NganhHoc IdNganhHocNavigation { get; set; } = null!;
}
