
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;

namespace ThucPham.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {

    }
    public class TagRepository:RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository (IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
