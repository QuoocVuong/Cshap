// QLDKhoa_CNTT.BLL/Services/UserRoleService.cs
using QLDKhoa_CNTT.DAL.Entities;
using QLDKhoa_CNTT.DAL.Repositories;
using System.Collections.Generic;

namespace QLDKhoa_CNTT.BLL.Services
{
    public class UserRoleService
    {
        private readonly UserRoleRepository _userRoleRepository;

        public UserRoleService()
        {
            _userRoleRepository = new UserRoleRepository();
        }
        public IEnumerable<UserRole> GetUserRolesByUserId(int userId)
        {
            return _userRoleRepository.GetUserRolesByUserId(userId);
        }
        public UserRole? GetUserRoleById(int userRoleId)
        {
            return _userRoleRepository.GetUserRoleById(userRoleId);
        }
        public void AddAnUserRole(UserRole userRole)
        {
            _userRoleRepository.AddAnUserRole(userRole);
        }

        public void UpdateAnUserRole(UserRole userRole)
        {
            _userRoleRepository.UpdateAnUserRole(userRole);
        }

        public void DeleteAnUserRole(int userRoleId)
        {
            _userRoleRepository.DeleteAnUserRole(userRoleId);
        }
        public void DeleteUserRolesByUserId(int userId)
        {
            _userRoleRepository.DeleteUserRolesByUserId(userId);
        }
    }
}