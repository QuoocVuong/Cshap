using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class Diem
{
    public int Id { get; set; }

    public int IdSinhVien { get; set; }

    public int IdMonHoc { get; set; }

    public double? Diem1 { get; set; }

    public int IdlanThi { get; set; }

    public virtual MonHoc IdMonHocNavigation { get; set; } = null!;

    public virtual SinhVien IdSinhVienNavigation { get; set; } = null!;

    public virtual LanThi IdlanThiNavigation { get; set; } = null!;
}
