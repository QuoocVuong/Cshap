using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class NamHocService
    {
        private NamHocRepository repo = new();
        public List<NamHoc> GetAllNamHocs()
        {
            return repo.GetAll();
        }
    }
}
