

using QLDKhoa_CNTT.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class UserRepository
    {
        private readonly QuanLyDiemKhoaCNTTContext _context;

        public UserRepository()
        {
            _context = new QuanLyDiemKhoaCNTTContext();
        }

       

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public User? Get(string tendangnhap)
        {
            QuanLyDiemKhoaCNTTContext db = new QuanLyDiemKhoaCNTTContext();
            return db.Users.FirstOrDefault(x => x.Username == tendangnhap);

        }
    }
}