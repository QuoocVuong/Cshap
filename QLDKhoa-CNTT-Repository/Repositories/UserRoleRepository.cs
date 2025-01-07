// YourDALProject/Repositories/UserRoleRepository.cs
using QLDKhoa_CNTT.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class UserRoleRepository
    {
        private readonly QuanLyDiemKhoaCNTTContext _context;

        public UserRoleRepository()
        {
            _context = new QuanLyDiemKhoaCNTTContext();
        }

        public IEnumerable<UserRole> GetUserRolesByUserId(int userId)
        {
            return _context.UserRoles
                 .Where(ur => ur.RoleId == userId)
                 .ToList();
        }
    }
}