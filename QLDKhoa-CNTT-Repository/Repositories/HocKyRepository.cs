using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class HocKyRepository
    {
        private QuanLyDiemKhoaCnttContext _context;

        public HocKy Get (int id )
        {
            _context = new QuanLyDiemKhoaCnttContext();
            return _context.HocKies.Find(id);
        }

        public List<HocKy> GetAll()
        {
            _context = new QuanLyDiemKhoaCnttContext();
            return _context.HocKies.ToList();

        }
        public void Create(HocKy hocKy)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            _context.HocKies.Add(hocKy);
            _context.SaveChanges();

        }

        public void Update(HocKy hocKi)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            _context.HocKies.Update(hocKi);
            _context.SaveChanges();
        }
        public bool Delete (int id)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            var hocKi = _context.HocKies.FirstOrDefault(h => h.Id == id);
            if (hocKi != null)
            {
                try
                {
                    _context.HocKies.Remove(hocKi);
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
        
    }
}
