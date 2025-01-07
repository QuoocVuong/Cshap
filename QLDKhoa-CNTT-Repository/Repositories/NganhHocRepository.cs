

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
        private QuanLyDiemKhoaCNTTContext _context;
        public NganhHoc Get(int id)
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            return _context.NganhHocs.Find(id);
        }
        public List<NganhHoc> GetAll()
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            return _context.NganhHocs.ToList();
        }
        public void Create(NganhHoc nganhHoc)
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            _context.NganhHocs.Add(nganhHoc);
            _context.SaveChanges();
        }
        //public bool Delete(int id)
        //{
        //    //_context = new QuanLyDiemKhoaCnttContext();
        //    //var nganhHoc = _context.NganhHocs.FirstOrDefault(nh => nh.Id == id);
        //    //if (nganhHoc != null)
        //    //{
        //    //    try
        //    //    {
        //    //        _context.NganhHocs.Remove(nganhHoc);
        //    //        _context.SaveChanges();
        //    //        return true; // Trả về true nếu thành công
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        return false; // Trả về false nếu có lỗi xảy ra
        //    //    }

        //    //}

        //    //return false; // Trả về false nếu không tìm thấy 
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var hocKis = _context.HocKies.Where(hk => hk. == id).ToList();
        //            _context.HocKies.RemoveRange(hocKis);




        //            // 2. Xóa Nganh hoc
        //            var nganhHoc = _context.NganhHocs.Find(id);
        //            if (nganhHoc != null)
        //            {
        //                _context.NganhHocs.Remove(nganhHoc);
        //            }

        //            _context.SaveChanges();
        //            transaction.Commit();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            return false;
        //        }
        //    }
        //}
        public bool Delete(int id)
        {
            _context = new QuanLyDiemKhoaCNTTContext(); // Khởi tạo _context
            var nganhHoc = _context.NganhHocs.FirstOrDefault(nh => nh.Id == id); // Tìm NganhHoc theo ID

            if (nganhHoc != null)
            {
                _context.NganhHocs.Remove(nganhHoc);
                _context.SaveChanges();
                return true;
            }

            return false; // Trả về false nếu không tìm thấy NganhHoc
        }

        public void Update(NganhHoc nganhHoc)
        {
            _context = new QuanLyDiemKhoaCNTTContext();
            _context.NganhHocs.Update(nganhHoc);
            _context.SaveChanges();
        }
    }
}
