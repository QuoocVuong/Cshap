using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class GiangVien
{
    public int Id { get; set; }

    public string MaGiangVien { get; set; } = null!;

    public string TenGiangVien { get; set; } = null!;

    public virtual ICollection<MonHoc> IdMonHocs { get; set; } = new List<MonHoc>();
}
