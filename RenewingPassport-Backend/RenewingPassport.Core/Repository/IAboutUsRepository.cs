using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IAboutUsRepository
    {
        List<AboutUsPage> GetAllAboutUsPage();
        bool CreateAboutUsPage(AboutUsPage aboutuspage);
        bool UpdateAboutUsPage(AboutUsPage aboutuspage);
        bool DeleteAboutUsPage(int id);
        AboutUsPage  GetAboutUsPageByID(int id);
        AboutUsPage GetCurrentPage();

    }
}
