using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;


namespace ThucPham.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {


    }
    public class OrderDetailRepository :RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository (IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
