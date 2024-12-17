using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class TaiKhoanRepository
    {
        //ham crud
        //repo choi voi db
        public TaiKhoan? Get(string tendangnhap)
        {
            QuanLyDiemKhoaCnttContext db = new QuanLyDiemKhoaCnttContext();
            return db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == tendangnhap);

        }
    }
}
