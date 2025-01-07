// YourBLLProject/Services/RolePermissionService.cs
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class RolePermissionService
    {
        private readonly RolePermissionRepository _rolePermissionRepository;

        public RolePermissionService()
        {
            _rolePermissionRepository = new RolePermissionRepository();
        }

        public IEnumerable<RolePermission> GetPermissionsByRoleId(int roleId)
        {
            return _rolePermissionRepository.GetPermissionsByRoleId(roleId);
        }
    }
}