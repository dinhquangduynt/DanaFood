using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;

namespace ThucPham.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {

    }
    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository (IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
