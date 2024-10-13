using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRoles();
        public Task<Role> GetRoleById(Guid roleId);
        // public Task<Role> GetRoleByName(string roleName);
    }
    public class RoleRepository : IRoleRepository
    {
        public async Task<List<Role>> GetAllRoles() => await RoleDAO.Instance.GetAllRoles();

        public async Task<Role> GetRoleById(Guid roleId) => await RoleDAO.Instance.GetRolesByID(roleId);
        // public async Task<Role> GetRoleByName(string roleName) => await RoleDAO.Instance.GetRoleByName(roleName);

    }
}
