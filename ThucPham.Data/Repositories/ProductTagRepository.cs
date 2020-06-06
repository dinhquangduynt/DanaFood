
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;


namespace ThucPham.Data.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {

    }
    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository (IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
