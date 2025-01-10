// QLDKhoa_CNTT.DAL/Repositories/UserRepository.cs
using QLDKhoa_CNTT.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class UserRepository
    {
        private readonly QuanLyDiemKhoaCnttContext _context;

        public UserRepository()
        {
            _context = new QuanLyDiemKhoaCnttContext();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
        public User? GetUserByUsername(string username)
        {
            return _context.Users
                .Include(u => u.UserRoles) // Tải thông tin UserRoles
                    .ThenInclude(ur => ur.Role) // Tải thông tin Role từ UserRoles
                .FirstOrDefault(u => u.Username == username);
        }
        //public User? Get(string tendangnhap)
        //{
        //    return _context.Users.FirstOrDefault(x => x.Username == tendangnhap);
        //}
        public void AddAnUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateAnUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteAnUser(int userId)
        {
            var userToDelete = _context.Users.Find(userId);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}