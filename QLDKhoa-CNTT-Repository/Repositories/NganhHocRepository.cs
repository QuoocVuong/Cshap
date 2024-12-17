using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class NganhHocRepository
    {
        private QuanLyDiemKhoaCnttContext _context;
        public NganhHoc Get(int id)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            return _context.NganhHocs.Find(id);
        }
        public List<NganhHoc> GetAll()
        {
            _context = new QuanLyDiemKhoaCnttContext();
            return _context.NganhHocs.ToList();
        }
        public void Create(NganhHoc nganhHoc)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            _context.NganhHocs.Add(nganhHoc);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            var nganhHoc = _context.NganhHocs.FirstOrDefault(nh => nh.Id == id);
            if (nganhHoc != null)
            {
                try
                {
                    _context.NganhHocs.Remove(nganhHoc);
                    _context.SaveChanges();
                    return true; // Trả về true nếu thành công
                }
                catch (Exception)
                {
                    return false; // Trả về false nếu có lỗi xảy ra
                }

            }

            return false; // Trả về false nếu không tìm thấy học kỳ
        }
        
        public void Update(NganhHoc nganhHoc)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            _context.NganhHocs.Update(nganhHoc);
            _context.SaveChanges();
        }
    }
}
