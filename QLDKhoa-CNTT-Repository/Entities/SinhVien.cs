using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class SinhVien
{
    public int Id { get; set; }

    public string MaSinhVien { get; set; } = null!;

    public string TenSinhVien { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public int IdLop { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual LopHoc IdLopNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
