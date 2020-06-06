using System;
using System.Collections.Generic;
using System.Linq;
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;
namespace ThucPham.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        //IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByTag(string tag);
    }
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetAllByTag(string tag)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status
                        orderby p.CreatedDate descending
                        select p;

            return query;
        }
    }
}
