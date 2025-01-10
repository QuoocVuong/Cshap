using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class KhoaVien
{
    public int Id { get; set; }

    public string MaKhoaVien { get; set; } = null!;

    public string TenKhoaVien { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();

    public virtual ICollection<NganhHoc> NganhHocs { get; set; } = new List<NganhHoc>();
}
