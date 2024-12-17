using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL.Services
{
   
    public class HocKyService
    {

        private HocKyRepository hocKyRepository = new();
        public List<HocKy> GetAllHocKys()
        {
            return hocKyRepository.GetAll();
        }
        public bool DeleteHocKy (int id)
        {
            return hocKyRepository.Delete(id);
        }
        public HocKy? GetAHocKy (int id)
        {
            return hocKyRepository.Get(id);
        }
        public void AddHocKy(HocKy hocKy)
        {
            hocKyRepository.Create(hocKy);

        }
        public void UpdateHocKy(HocKy hocKy, int id)
        {
            hocKyRepository.Update(hocKy);   
        }
    }
}
