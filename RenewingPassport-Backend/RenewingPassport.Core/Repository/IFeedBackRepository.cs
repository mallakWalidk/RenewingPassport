using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
   public interface IFeedBackRepository
    {
        bool CreateFeedBack(FeedBack feedBack);
        bool UpdateFeedBack(FeedBack feedBack);
        bool DeleteFeedBack(int Id);
        List<FeedBack> GetAllFeedBack();
        List<FeedBack> GetFeedBackById(int Id);
    }
}
