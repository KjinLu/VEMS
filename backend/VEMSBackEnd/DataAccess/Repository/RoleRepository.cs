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
        public List<Role> GetAllRoles();
        public Role GetRoleById(Guid roleId);
    }
    public class RoleRepository : IRoleRepository
    {
        public List<Role> GetAllRoles() => RoleDAO.Instance.GetAllRoles();
         
        public Role GetRoleById(Guid roleId) => RoleDAO.Instance.GetRolesByID(roleId);
        
    }
}
