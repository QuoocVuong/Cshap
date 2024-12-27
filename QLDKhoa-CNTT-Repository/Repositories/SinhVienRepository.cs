using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class SinhVienRepository
    {
        private QuanLyDiemKhoaCnttContext _context;
        public List<SinhVien> GetAll()
        {
            _context = new();
            return _context.SinhViens.ToList();
        }
        public SinhVien Get(int id)
        {
            _context = new();
            return _context.SinhViens.Find(id);
        }
        public void Create(SinhVien sinhVien)
        {
            _context = new();
            _context.SinhViens.Add(sinhVien);
            _context.SaveChanges();
        }
        public void Update(SinhVien sinhVien)
        {
            _context = new();
            _context.SinhViens.Update(sinhVien);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {

            try
            {
                _context = new();
                var sinhVien = _context.SinhViens.FirstOrDefault(sv => sv.Id == id);
                if (sinhVien != null)
                {
                    _context.SinhViens.Remove(sinhVien);
                    _context.SaveChanges();
                    return true;
                }
                return false; // Học kỳ không tồn tại
            }
            catch (Exception)
            {

                return false; // Xóa thất bại
            }
        }
    }
}
