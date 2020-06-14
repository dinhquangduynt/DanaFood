using System.Linq;
using System.Collections.Generic;
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;
namespace ThucPham.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagId);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Product> GetListProductByTag(string tagId)
        {
            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagId
                        select p;

            return query;
        }
    }
}
