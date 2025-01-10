using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class NamHoc
{
    public int Id { get; set; }

    public string TenNamHoc { get; set; } = null!;

    public virtual ICollection<HocKy> HocKies { get; set; } = new List<HocKy>();
}
