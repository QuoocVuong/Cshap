using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class KhoaVienService
    {
        private readonly KhoaVienRepository _khoaVienRepository;

        public KhoaVienService(KhoaVienRepository khoaVienRepository)
        {
            _khoaVienRepository = khoaVienRepository;
        }

        public IEnumerable<KhoaVien> GetAllKhoaVien()
        {
            return _khoaVienRepository.GetAll();
        }

        public KhoaVien GetAKhoaVien(int id)
        {
            return _khoaVienRepository.GetById(id);
        }

        public void CreateAKhoaVien(KhoaVien khoaVien)
        {
            _khoaVienRepository.Add(khoaVien);
        }

        public void UpdateAKhoaVien(KhoaVien khoaVien)
        {
            _khoaVienRepository.Update(khoaVien);
        }

        public void DeleteAKhoaVien(int id)
        {
            _khoaVienRepository.Delete(id);
        }
    }
}