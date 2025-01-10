using QLDKhoa_CNTT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class NamHocRepository
    {
        private QuanLyDiemKhoaCnttContext context = new();
        public List<NamHoc> GetAll()
        {
            return context.NamHocs.ToList();
        }
        public NamHoc? Get(int id)
        {
            return context.NamHocs.Find(id);
        }
        public void Create(NamHoc namHoc)
        {
            context.NamHocs.Add(namHoc);
            context.SaveChanges();
        }
        public void Update(NamHoc namHoc)
        {
            context.NamHocs.Update(namHoc);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var namHoc = context.NamHocs.FirstOrDefault(nh => nh.Id == id);
            if (namHoc != null)
            {
                context.NamHocs.Remove(namHoc);
                context.SaveChanges();
            }
        }
    }
}
