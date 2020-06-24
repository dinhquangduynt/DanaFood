using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;

namespace ThucPham.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
       // IEnumerable<Role> GetListRoleGroupId(int groupId);
    }
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        //public IEnumerable<Role> GetListRoleGroupId(int groupId)
        //{
        //    var query = from r in DbContext.appRoles
        //                join rg in DbContext.RoleGroups
        //                on r.Id equals rg.RoleId
        //                where rg.GroupId == groupId
        //                select r;
        //    return query;
        //}
    }
}
