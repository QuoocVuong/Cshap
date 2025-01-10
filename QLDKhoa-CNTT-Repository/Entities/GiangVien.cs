using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class GiangVien
{
    public int Id { get; set; }

    public string MaGiangVien { get; set; } = null!;

    public string TenGiangVien { get; set; } = null!;

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? IdKhoaVien { get; set; }

    public virtual KhoaVien? IdKhoaVienNavigation { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<MonHoc> IdMonHocs { get; set; } = new List<MonHoc>();
}
