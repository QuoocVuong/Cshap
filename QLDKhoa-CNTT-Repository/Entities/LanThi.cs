using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.DAL.Entities;

public partial class LanThi
{
    public int Id { get; set; }

    public int LanThi1 { get; set; }

    public DateOnly NgayThi { get; set; }

    public int IdMonHoc { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual MonHoc IdMonHocNavigation { get; set; } = null!;
}
