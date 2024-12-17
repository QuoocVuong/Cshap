using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class HinhThuc
{
    public int Id { get; set; }

    public string HinhThuc1 { get; set; } = null!;

    public int IdHocKy { get; set; }

    public virtual HocKy IdHocKyNavigation { get; set; } = null!;

    public virtual ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();
}
