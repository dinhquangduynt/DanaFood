using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;

namespace ThucPham.Data.Repositories
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {

    }
    public class RoleGroupRepository : RepositoryBase<RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
