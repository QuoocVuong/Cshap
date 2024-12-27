using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class LopHocService
    {
        private LopHocRepository _repository = new();
        public List<LopHoc> GetAllLopHocs()
        {
            return _repository.GetAll();
        }
        public LopHoc? GetALopHoc(int id)
        {
            return _repository.Get(id);
        }
        public void AddALopHoc(LopHoc lopHoc)
        {
            _repository.Create(lopHoc);
        }
        //public void UpdataALopHoc1(LopHoc lopHoc)
        //{
        //    if (!_repository.Update(lopHoc))
        //    {
        //        throw new Exception("The lop hoc was not updated successfully");
        //    }
        //}
        public void UpdataALopHoc(LopHoc lopHoc)
        {
            _repository.Update(lopHoc);
        }
        public void DeleteALopHoc(int id)
        {
           _repository.Delete(id);
        }
    }
}
