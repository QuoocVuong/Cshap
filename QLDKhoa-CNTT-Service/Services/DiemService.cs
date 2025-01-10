// Trong DiemService.cs
using QLDKhoa_CNTT.DAL;
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq; // Add this for LINQ operations

namespace QLDKhoa_CNTT.BLL.Services
{
    public class DiemService
    {
        private DiemRepository diemRepository;

        public DiemService()
        {
            diemRepository = new DiemRepository();
        }

        public List<Diem> GetAllDiems()
        {
            return diemRepository.GetAllIncluding(d => d.IdSinhVienNavigation, d => d.IdLanThiNavigation); // Load related entities
        }
        public Diem GetADiem(int id)
        {

            return diemRepository.GetIncluding(id, d => d.IdSinhVienNavigation, d => d.IdLanThiNavigation); // Load related entities
        }
        public void CreateADiem(Diem diem)
        {
            diemRepository.Create(diem);
        }
        public void UpdataADiem(Diem diem)
        {

            diemRepository.Update(diem);
        }
        public void DeleteADiem(int id)
        {

            diemRepository.Delete(id);
        }
        public List<Diem> GetBySinhVien(int idSinhVien)
        {
            return diemRepository.FindBy(d => d.IdSinhVien == idSinhVien).ToList();
        }

        // Add this method to filter by MonHoc
        public List<Diem> GetByMonHoc(int idMonHoc)
        {
            return diemRepository.FindBy(d => d.IdLanThiNavigation.IdMonHoc == idMonHoc).ToList();
        }
        public List<Diem> GetDiemByNganhHoc(int idNganhHoc)
        {
            using (var context = new QuanLyDiemKhoaCnttContext())
            {
                var danhSachDiem = context.Diems
                   .Where(d => d.IdSinhVienNavigation.IdLopNavigation.IdNganh == idNganhHoc)
                    .ToList();
                return danhSachDiem;
            }
        }
    }
}