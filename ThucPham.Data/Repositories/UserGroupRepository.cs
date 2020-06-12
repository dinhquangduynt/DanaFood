using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;

namespace ThucPham.Data.Repositories
{
    public interface IUserGroupRepository : IRepository<UserGroup>
    {

    }
    public class UserGroupRepository : RepositoryBase<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
