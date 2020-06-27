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
    public interface ISupportOnlineService
    {
        SupportOnline Create(SupportOnline feedback);

        IEnumerable<SupportOnline> GetAll();

        SupportOnline Update(int id);

        void Save();
    }
    public class SupportOnlineService : ISupportOnlineService
    {

        ISupportOnlineRepository _supportOnlineRepository;
        IUnitOfWork _unitOfWork;

        public SupportOnlineService(ISupportOnlineRepository supportOnlineRepository,
        IUnitOfWork unitOfWork){
            _supportOnlineRepository = supportOnlineRepository;
            _unitOfWork = unitOfWork;
            }

        public SupportOnline Create(SupportOnline feedback)
        {
            return _supportOnlineRepository.Add(feedback);

        }

        public IEnumerable<SupportOnline> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public SupportOnline Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
