// DAL/Repositories/GiangVienRepository.cs

using QLDKhoa_CNTT.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class GiangVienRepository
    {
        private readonly QuanLyDiemKhoaCnttContext _context;

        public GiangVienRepository(QuanLyDiemKhoaCnttContext context)
        {
            _context = context;
        }

        public IEnumerable<GiangVien> GetAll()
        {
            return _context.GiangViens.ToList();
        }

        public GiangVien GetById(int id)
        {
            return _context.GiangViens.Find(id);
        }

        public void Add(GiangVien giangVien)
        {
            _context.GiangViens.Add(giangVien);
            _context.SaveChanges();
        }

        public void Update(GiangVien giangVien)
        {
            _context.GiangViens.Update(giangVien);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var giangVien = _context.GiangViens.Find(id);
            if (giangVien != null)
            {
                _context.GiangViens.Remove(giangVien);
                _context.SaveChanges();
            }
        }
    }
}