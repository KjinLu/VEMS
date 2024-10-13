using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        private static readonly object InstanceLock = new object();
        private static RoleDAO instance = null;

        public static RoleDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            List<Role> roles = null;
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Roles.ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Role> GetRolesByID(Guid RoleID)
        {
            Role roles = null;
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Roles.SingleOrDefaultAsync(r => r.Id == RoleID);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // public async Task<Role> GetRolesByID(Guid RoleID)
        // {
        //     Role roles = null;
        //     try
        //     {
        //         var context = new VemsContext();
        //         if (context != null)
        //         {
        //             return await context.Roles.SingleOrDefaultAsync(r => r.Id == RoleID);
        //         }
        //         return null;
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        // }
    }
}
