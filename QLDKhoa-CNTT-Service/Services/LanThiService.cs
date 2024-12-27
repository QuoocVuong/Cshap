using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class LanThiService
    {
        private LanThiRepository lanThiRepository;

        public List<LanThi> GetAllLanThis()
        {
            lanThiRepository = new();
            return lanThiRepository.GetAll();
        }
        public LanThi GetALanThi(int id)
        {
            lanThiRepository = new();
            return lanThiRepository.Get(id);
        }
        public void CreateALanThi(LanThi lanThi)
        {
            lanThiRepository = new();
            lanThiRepository.Create(lanThi);
        }
        public void UpdataALanThi(LanThi lanThi)
        {
            lanThiRepository = new();
            lanThiRepository.Update(lanThi);
        }
        public void DeleteALanThi(int id)
        {
            lanThiRepository = new();
            lanThiRepository.Delete(id);
        }
    }
}