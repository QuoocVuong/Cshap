using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class NganhHoc
{
    public int Id { get; set; }

    public string TenNganhHoc { get; set; } = null!;

    public int IdKhoa { get; set; }

    public virtual ICollection<HocKy> HocKies { get; set; } = new List<HocKy>();

    public virtual KhoaHoc IdKhoaNavigation { get; set; } = null!;

    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
