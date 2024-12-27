using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class MonHocService
    {
        private MonHocRepository monHocRepository;
        public List<MonHoc> GetAllMonHocs()
        {
            monHocRepository = new();
            return monHocRepository.GetAll();
        }
        public MonHoc GetAMonHoc(int id)
        {
            monHocRepository = new();
            return monHocRepository.Get(id);
        }
        public void CreateAMonHoc(MonHoc monHoc)
        {
            monHocRepository = new();
            monHocRepository.Create(monHoc);
        }
        public void UpdataAMonHoc(MonHoc monHoc)
        {
            monHocRepository = new();
            monHocRepository.Update(monHoc);
        }
        public void DeleteAMonHoc(int id)
        {
            monHocRepository = new();
            monHocRepository.Delete(id);
        }
    }
}
