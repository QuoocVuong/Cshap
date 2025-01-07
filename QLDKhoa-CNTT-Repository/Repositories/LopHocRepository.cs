using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class LopHocRepository
    {
        private QuanLyDiemKhoaCNTTContext _context;
        public List<LopHoc> GetAll()
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            return _context.LopHocs.ToList();
        }
        public LopHoc Get(int id)
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            return _context.LopHocs.Find(id);
        }
        public void Create(LopHoc lopHoc)
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            _context.LopHocs.Add(lopHoc);
            _context.SaveChanges();
        }
        public void Update(LopHoc lopHoc)
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            _context.LopHocs.Update(lopHoc);
            _context.SaveChanges();
        }

        //public bool Update(LopHoc lopHoc)
        //{
        //    try
        //    {
        //        using (var _context = new QuanLyDiemKhoaCnttContext())
        //        {
        //            _context.LopHocs.Update(lopHoc);
        //            _context.SaveChanges();
        //            return true; // Trả về true nếu thành công
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false; // Trả về false nếu xảy ra lỗi
        //    }
        //}
        public bool Delete(int id)
        {

            try
            {
                _context = new QuanLyDiemKhoaCNTTContext();
                var lopHoc = _context.LopHocs.FirstOrDefault(lh => lh.Id == id);
                if (lopHoc != null)
                {
                    _context.LopHocs.Remove(lopHoc);
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
