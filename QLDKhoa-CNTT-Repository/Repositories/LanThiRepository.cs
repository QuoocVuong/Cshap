using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class LanThiRepository
    {
        private QuanLyDiemKhoaCnttContext _context;

        public List<LanThi> GetAll()
        {
            _context = new();
            return _context.LanThis.ToList();
        }
        public LanThi Get(int id)
        {
            _context = new();
            return _context.LanThis.Find(id);
        }
        public void Create(LanThi lanThi)
        {
            _context = new();
            _context.LanThis.Add(lanThi);
            _context.SaveChanges();
        }
        public void Update(LanThi lanThi)
        {
            _context = new();
            _context.LanThis.Update(lanThi);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                _context = new();
                var lanThi = _context.LanThis.FirstOrDefault(lt => lt.Id == id);
                if (lanThi != null)
                {
                    _context.LanThis.Remove(lanThi);
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