using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class DiemRepository
    {
        private QuanLyDiemKhoaCnttContext _context;

        public List<Diem> GetAll()
        {
            _context = new();
            return _context.Diems.ToList();
        }
        public Diem Get(int id)
        {
            _context = new();
            return _context.Diems.Find(id);
        }
        public List<Diem> GetBySinhVien(int idSinhVien)
        {
            _context = new();
            return _context.Diems.Where(d => d.IdSinhVien == idSinhVien).ToList();
        }
        public void Create(Diem diem)
        {
            _context = new();
            _context.Diems.Add(diem);
            _context.SaveChanges();
        }
        public void Update(Diem diem)
        {
            _context = new();
            _context.Diems.Update(diem);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                _context = new();
                var diem = _context.Diems.FirstOrDefault(lt => lt.Id == id);
                if (diem != null)
                {
                    _context.Diems.Remove(diem);
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