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
    public interface IOrderService
    {
        IEnumerable<Order> GetAll(string keyword = null);
        Order GetById(int orderId);

        IEnumerable<OrderDetail> GetOrderById(int id);
        Order Create(ref Order order, List<OrderDetail> orderDetails);
        void UpdateStatus(int orderId);

        Order Delete(int id);
        void Save();
    }
    public class OrderService : IOrderService
    {

        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAll(string keyword = null)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _orderRepository.GetMulti(x => x.CustomerName.Contains(keyword));
            }
            return _orderRepository.GetAll();
        }

        public Order GetById(int orderID)
        {
            
            return _orderRepository.GetSingleById(orderID);
        }

        public IEnumerable<OrderDetail> GetOrderById(int id)
        {
            return _orderDetailRepository.GetMulti(x => x.OrderID == id);
        }

        public Order Create(ref Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();

                foreach(var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailRepository.Add(orderDetail);
                }

                return order;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Order Delete(int id)
        {
            //var listOrderDetail = _orderDetailRepository.GetMulti(x => x.OrderID == id);

             _orderDetailRepository.DeleteMulti(x => x.OrderID == id);
            _unitOfWork.Commit();
            return _orderRepository.Delete(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateStatus(int orderId)
        {
            var order = _orderRepository.GetSingleById(orderId);

            order.Status = true;
            _orderRepository.Update(order);
        }
    }
}
