// QLDKhoa_CNTT.DAL/Repositories/UserRoleRepository.cs
using QLDKhoa_CNTT.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class UserRoleRepository
    {
        private readonly QuanLyDiemKhoaCnttContext _context;

        public UserRoleRepository()
        {
            _context = new QuanLyDiemKhoaCnttContext();
        }

        public IEnumerable<UserRole> GetUserRolesByUserId(int userId)
        {
            return _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .ToList();
        }

        public UserRole? GetUserRoleById(int userRoleId)
        {
            return _context.UserRoles.Find(userRoleId);
        }

        public void AddAnUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void UpdateAnUserRole(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
        }

        public void DeleteAnUserRole(int userRoleId)
        {
            var userRoleToDelete = _context.UserRoles.Find(userRoleId);
            if (userRoleToDelete != null)
            {
                _context.UserRoles.Remove(userRoleToDelete);
                _context.SaveChanges();
            }
        }
        public void DeleteUserRolesByUserId(int userId)
        {
            var userRolesToDelete = _context.UserRoles
                .Where(ur => ur.UserId == userId);
            _context.UserRoles.RemoveRange(userRolesToDelete);
            _context.SaveChanges();
        }
    }
}