using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class Diem
{
    public int Id { get; set; }

    public int IdSinhVien { get; set; }

    public int IdLanThi { get; set; }

    public double? Diem1 { get; set; }

    public virtual LanThi IdLanThiNavigation { get; set; } = null!;

    public virtual SinhVien IdSinhVienNavigation { get; set; } = null!;
}
