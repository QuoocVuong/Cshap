using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class DiemService
    {
        private DiemRepository diemRepository;

        public List<Diem> GetAllDiems()
        {
            diemRepository = new();
            return diemRepository.GetAll();
        }
        public Diem GetADiem(int id)
        {
            diemRepository = new();
            return diemRepository.Get(id);
        }
        public void CreateADiem(Diem diem)
        {
            diemRepository = new();
            diemRepository.Create(diem);
        }
        public void UpdataADiem(Diem diem)
        {
            diemRepository = new();
            diemRepository.Update(diem);
        }
        public void DeleteADiem(int id)
        {
            diemRepository = new();
            diemRepository.Delete(id);
        }
        public List<Diem> GetBySinhVien(int idSinhVien)
        {
            diemRepository = new();
            return diemRepository.GetBySinhVien(idSinhVien);
        }
    }
}