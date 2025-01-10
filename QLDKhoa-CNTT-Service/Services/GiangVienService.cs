// BLL/Services/GiangVienService.cs
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class GiangVienService
    {
        private readonly GiangVienRepository _giangVienRepository;

        public GiangVienService(GiangVienRepository giangVienRepository)
        {
            _giangVienRepository = giangVienRepository;
        }

        public IEnumerable<GiangVien> GetAllGiangVien()
        {
            return _giangVienRepository.GetAll();
        }

        public GiangVien GetAGiangVien(int id)
        {
            return _giangVienRepository.GetById(id);
        }

        public void CreateAGiangVien(GiangVien giangVien)
        {
            _giangVienRepository.Add(giangVien);
        }

        public void UpdateAGiangVien(GiangVien giangVien)
        {
            _giangVienRepository.Update(giangVien);
        }

        public void DeleteAGiangVien(int id)
        {
            _giangVienRepository.Delete(id);
        }
    }
}
