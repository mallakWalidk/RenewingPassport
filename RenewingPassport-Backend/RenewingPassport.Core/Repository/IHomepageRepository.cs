using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IHomepageRepository
    {
         List <HomePage> GetAllHomePage();
         bool CreateHomePage(HomePage homepage);
         bool UpdateHomePage(HomePage homepage);
         bool DeleteHomePage(int id);
         HomePage GetHomePageByID(int id);
         HomePage GetCurrentPage();

    }
}
