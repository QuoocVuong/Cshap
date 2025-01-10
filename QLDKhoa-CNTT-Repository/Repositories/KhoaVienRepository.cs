using QLDKhoa_CNTT.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class KhoaVienRepository
    {
        private readonly QuanLyDiemKhoaCnttContext _context;

        public KhoaVienRepository(QuanLyDiemKhoaCnttContext context)
        {
            _context = context;
        }

        public IEnumerable<KhoaVien> GetAll()
        {
            return _context.KhoaViens.ToList();
        }

        public KhoaVien GetById(int id)
        {
            return _context.KhoaViens.Find(id);
        }

        public void Add(KhoaVien khoaVien)
        {
            _context.KhoaViens.Add(khoaVien);
            _context.SaveChanges();
        }

        public void Update(KhoaVien khoaVien)
        {
            _context.KhoaViens.Update(khoaVien);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var khoaVien = _context.KhoaViens.Find(id);
            if (khoaVien != null)
            {
                _context.KhoaViens.Remove(khoaVien);
                _context.SaveChanges();
            }
        }
    }
}