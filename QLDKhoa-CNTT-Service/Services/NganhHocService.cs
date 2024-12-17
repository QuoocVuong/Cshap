using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL
{
    public class NganhHocService
    {
        private NganhHocRepository _repo = new NganhHocRepository();
        public List<NganhHoc> GetAllNganhHocs()
        {
            return _repo.GetAll();
        } 
        /// <summary>
        /// ham nay search cuon sach theo tieu chi: ten nganh hoc
        /// search theo kieu contain tuc la ten nganh hoc chua key vua go khong phai la so sanh hai chuoi bang nhau ma tim gan dung
        /// neu khong thay ten sang cot khac tim  tiep
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<NganhHoc> SearchNganhHocs(string key)
        {
            return _repo.GetAll().Where(n => n.TenNganhHoc.ToLower().Contains (key.ToLower())).ToList();

        }
        public bool DeletedNganhHoc(int id)
        {
           return _repo.Delete(id);
        }
        public NganhHoc? GetANganhHoc(int id)
        {
            return _repo.Get(id);
        }
        public void AddANganhHoc(NganhHoc nganhHoc)
        {
            _repo.Create(nganhHoc);
        }
        public void UpdateANganhHoc(NganhHoc nganhHoc)
        {
            _repo.Update(nganhHoc);
        }
    }
}
