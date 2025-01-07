// YourDALProject/Repositories/RolePermissionRepository.cs
using QLDKhoa_CNTT.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class RolePermissionRepository
    {
        private readonly QuanLyDiemKhoaCNTTContext _context;

        public RolePermissionRepository()
        {
            _context = new QuanLyDiemKhoaCNTTContext();
        }

        public IEnumerable<RolePermission> GetPermissionsByRoleId(int roleId)
        {
            return _context.RolePermissions
                    .Where(rp => rp.RoleId == roleId)
                    .Include(rp => rp.Permission)
                    .ToList();
        }
    }
}