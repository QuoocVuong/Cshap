using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class SinhVienService
    {
        private SinhVienRepository _repository;
        public List<SinhVien> GetAllSinhVien()
        {
            _repository = new();
            return _repository.GetAll();
        }
        public SinhVien GetAnSinhVien(int id)
        {
            _repository = new();
            return _repository.Get(id);
        }
        public void CreateAnSinhvien(SinhVien sinhVien)
        {
            _repository = new();
            _repository.Create(sinhVien);
        }
        public void UpdateAnSinhVien(SinhVien sinhVien)
        {
            _repository = new();
            _repository.Update(sinhVien);
        }
        public void DeleteAnSinhVien(int id)
        {
            _repository = new();
            _repository.Delete(id);
        }
    }
}
