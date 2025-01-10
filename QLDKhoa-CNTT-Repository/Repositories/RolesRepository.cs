// QLDKhoa_CNTT.DAL/Repositories/RolesRepository.cs
using QLDKhoa_CNTT.DAL.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLDKhoa_CNTT.DAL.Repositories
{
    public class RolesRepository
    {
        private readonly QuanLyDiemKhoaCnttContext _context;

        public RolesRepository()
        {
            _context = new QuanLyDiemKhoaCnttContext();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role? GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void AddARole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void UpdateARole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void DeleteARole(int roleId)
        {
            var roleToDelete = _context.Roles.Find(roleId);
            if (roleToDelete != null)
            {
                _context.Roles.Remove(roleToDelete);
                _context.SaveChanges();
            }
        }
    }
}