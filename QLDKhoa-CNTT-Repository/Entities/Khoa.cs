using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class Khoa
{
    public int Id { get; set; }

    public string TenKhoa { get; set; } = null!;

    public virtual ICollection<NganhHoc> NganhHocs { get; set; } = new List<NganhHoc>();
}
