using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL
{
    public class KhoaHocService

    {
        private KhoaHocRepository _repo = new KhoaHocRepository();
        public List<Khoa> GetAllKhoaHocs()
        {
            return _repo.GetAll();
        }
        public void DeletedKhoaHoc(int id)
        {
            _repo.Delete(id);
        }

    }
}
