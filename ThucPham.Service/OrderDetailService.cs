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
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail Delete(int id);

        void Save();

    }
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public OrderDetail Delete(int id)
        {
            return _orderDetailRepository.Delete(id);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _orderDetailRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
