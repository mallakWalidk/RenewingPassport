using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedBackRepository;
        public FeedBackService(IFeedBackRepository feedBackRepository)
        {
            _feedBackRepository = feedBackRepository;
        }
        public bool CreateFeedBack(FeedBack feedBack)
        {
            return _feedBackRepository.CreateFeedBack(feedBack);
        }

        public bool DeleteFeedBack(int Id)
        {
            return _feedBackRepository.DeleteFeedBack(Id);
        }

        public List<FeedBack> GetAllFeedBack()
        {
            return _feedBackRepository.GetAllFeedBack();
        }

        public List<FeedBack> GetFeedBackById(int Id)
        {
            return _feedBackRepository.GetFeedBackById(Id);
        }

        public bool UpdateFeedBack(FeedBack feedBack)
        {
            return _feedBackRepository.UpdateFeedBack(feedBack);
        }
    }
}
