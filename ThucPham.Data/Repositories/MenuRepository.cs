using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;


namespace ThucPham.Data.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {

    }
    public class MenuRepository :RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository (IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
