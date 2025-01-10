using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDKhoa_CNTT.DAL.Entities;
namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class KhoaHocRepository
    {
        private QuanLyDiemKhoaCnttContext _context;

        public Khoa? Get(int id)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            //return _context.KhoaHocs; //tuong duong select * from
            return _context.Khoas.Find(id);
        }
        public List<Khoa> GetAll()
        {
            _context = new QuanLyDiemKhoaCnttContext();
            return _context.Khoas.ToList();

        }
        public void Create(Khoa khoaHoc)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            _context.Khoas.Add(khoaHoc);
            _context.SaveChanges();
        }
        public void Update(Khoa khoaHoc)
        {
            _context = new QuanLyDiemKhoaCnttContext();
            _context.Khoas.Update(khoaHoc);
            _context.SaveChanges();
        }
        //public void Delete(int id)// dung linq
        //{
        //    _context = new QuanLyDiemKhoaCnttContext();
        //    var khoaHoc = _context.Khoas.FirstOrDefault(k => k.Id == id);
        //    if (khoaHoc != null)
        //    {

        //        _context.Khoas.Remove(khoaHoc);
        //        _context.SaveChanges();
        //    }
        //}
        // Trong KhoaHocService.cs (hoặc KhoaHocRepository.cs nếu bạn dùng Repository pattern)
        //public void Delete(int id)
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            // 1. Xóa các NganhHoc liên quan
        //            var nganhHocs = _context.NganhHocs.Where(nh => nh.IdKhoa == id).ToList();
        //            _context.NganhHocs.RemoveRange(nganhHocs);


        //            // 2. Xóa KhoaHoc
        //            var khoaHoc = _context.KhoaHocs.Find(id);
        //            if (khoaHoc != null)
        //            {
        //                _context.KhoaHocs.Remove(khoaHoc);
        //            }

        //            _context.SaveChanges();
        //            transaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            // Xử lý exception
        //            throw; // hoặc re-throw exception sau khi xử lý
        //        }
        //    }
        //}
        //public bool Delete(int id)
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var nganhHocs = _context.NganhHocs.Where(nh => nh.IdKhoa == id).ToList();
        //            _context.NganhHocs.RemoveRange(nganhHocs);


        //            // 2. Xóa KhoaHoc
        //            var khoaHoc = _context.Khoas.Find(id);
        //            if (khoaHoc != null)
        //            {
        //                _context.Khoas.Remove(khoaHoc);
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
            _context = new QuanLyDiemKhoaCnttContext();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var khoaHoc = _context.Khoas.Find(id);
                    if (khoaHoc != null)
                    {
                        _context.Khoas.Remove(khoaHoc);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        return false; // Không tìm thấy KhoaHoc để xóa
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
    }
}
