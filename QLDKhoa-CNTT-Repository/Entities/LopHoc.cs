using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class LopHoc
{
    public int Id { get; set; }

    public string TenLop { get; set; } = null!;

    public int IdNganh { get; set; }

    public virtual NganhHoc IdNganhNavigation { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();

}
