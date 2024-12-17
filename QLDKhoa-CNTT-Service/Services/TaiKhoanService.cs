using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL
{
    public class TaiKhoanService
    {
        public TaiKhoan? CheckLogin(string username, string password)
        {
            TaiKhoanRepository repo = new TaiKhoanRepository();
            TaiKhoan acc = repo.Get(username);
            //if (acc == null)
            //    return null;
            //if (acc.MatKhau == password)
            //    return acc;
            //return null;
            return acc != null && acc.MatKhau == password ? acc : null;
        }

    }
}
