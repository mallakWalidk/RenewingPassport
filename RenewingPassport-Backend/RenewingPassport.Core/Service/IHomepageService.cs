using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IHomepageService
    {
         List<HomePage> GetAllHomePage();
         bool CreateHomePage(HomePage homepage);
         bool UpdateHomePage(HomePage homepage);
         bool DeleteHomePage(int id);
         HomePage GetHomePageByID(int id);
         HomePage GetCurrentPage();

    }
}
