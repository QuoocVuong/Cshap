// QLDKhoa_CNTT.BLL/Services/RolesService.cs
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System.Collections.Generic;
using System.Data;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class RolesService
    {
        private readonly RolesRepository _rolesRepository;

        public RolesService()
        {
            _rolesRepository = new RolesRepository();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _rolesRepository.GetAllRoles();
        }

        public Role? GetRoleById(int roleId)
        {
            return _rolesRepository.GetRoleById(roleId);
        }

        public void AddARole(Role role)
        {
            _rolesRepository.AddARole(role);
        }

        public void UpdateARole(Role role)
        {
            _rolesRepository.UpdateARole(role);
        }

        public void DeleteARole(int roleId)
        {
            _rolesRepository.DeleteARole(roleId);
        }
    }
}