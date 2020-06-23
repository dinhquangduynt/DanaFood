using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Data.Infrastructure;
using ThucPham.Data.Repositories;
using ThucPham.Model.Models;

namespace ThucPham.Service
{
    public interface IOrderTotalService
    {
        OrderTotal Delete(int id);
    }

    public class OrderTotalService : IOrderTotalService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;

        public OrderTotalService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }


        public OrderTotal Delete(int id)
        {
            OrderTotal orderTotal = new OrderTotal();
             IEnumerable<OrderDetail> orderDetails= _orderDetailRepository.DeleteMulti(x => x.OrderID == id);
            _unitOfWork.Commit();

            Order order = _orderRepository.Delete(id);
            //_unitOfWork.Commit();
            orderTotal.Order = order;
            orderTotal.OrderDetails = orderDetails;
            return orderTotal;
        }
    }
}
