using QLDKhoa_CNTT.DAL;
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
    }
}