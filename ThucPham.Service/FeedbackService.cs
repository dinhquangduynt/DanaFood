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
    public interface IFeedbackService
    {
        Feedback Create(Feedback feedback);

        IEnumerable<Feedback> GetAll();

        Feedback Update(int id);

        Feedback GetByID(int id);

        void Save();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;
        private ISupportOnlineRepository _supportOnlineRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository, 
            IUnitOfWork unitOfWork, ISupportOnlineRepository supportOnlineRepository)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = unitOfWork;
            _supportOnlineRepository = supportOnlineRepository;
        }

        public Feedback Create(Feedback feedback)
        {
            return _feedbackRepository.Add(feedback);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public Feedback Update(int id)
        {
            var feedback = _feedbackRepository.GetSingleById(id);

            feedback.Status = true;
            _feedbackRepository.Update(feedback);

            return feedback;
        }

        public Feedback GetByID(int id)
        {
            return _feedbackRepository.GetSingleById(id);
        }
    }
}
