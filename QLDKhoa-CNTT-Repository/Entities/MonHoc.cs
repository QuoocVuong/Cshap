using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class MonHoc
{
    public int Id { get; set; }

    public string MaMonHoc { get; set; } = null!;

    public string TenMonHoc { get; set; } = null!;

    public int? SoGio { get; set; }

    public int IdHinhThuc { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual HinhThuc IdHinhThucNavigation { get; set; } = null!;

    public virtual ICollection<LanThi> LanThis { get; set; } = new List<LanThi>();
}
