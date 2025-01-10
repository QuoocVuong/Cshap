using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class MonHocRepository
    {
        private QuanLyDiemKhoaCnttContext _context;
        public List<MonHoc> GetAll()
        {
            _context = new();
            return _context.MonHocs.ToList();
        }
        public MonHoc Get(int id)
        {
            _context = new();
            return _context.MonHocs.Find(id);
        }
        public void Create(MonHoc monHoc)
        {
            _context = new();
            _context.MonHocs.Add(monHoc);
            _context.SaveChanges();
        }
        public void Update(MonHoc monHoc)
        {
            _context = new();
            _context.MonHocs.Update(monHoc);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                _context = new();
                var monHoc = _context.MonHocs.FirstOrDefault(mh => mh.Id == id);
                if (monHoc != null)
                {
                    _context.MonHocs.Remove(monHoc);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
