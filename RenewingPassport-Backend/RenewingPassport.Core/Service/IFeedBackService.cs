using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IFeedBackService
    {
        bool CreateFeedBack(FeedBack feedBack);
        bool UpdateFeedBack(FeedBack feedBack);
        bool DeleteFeedBack(int Id);
        List<FeedBack> GetAllFeedBack();
        List<FeedBack> GetFeedBackById(int Id);
    }
}
