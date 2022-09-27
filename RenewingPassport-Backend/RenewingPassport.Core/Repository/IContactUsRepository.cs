using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IContactUsRepository
    {
         List<ContactUsPage> GetAllContactUsPage();
         bool CreateContactUsPage(ContactUsPage contactuspage);
         bool UpdateContactUsPage(ContactUsPage contactuspage);
         bool DeleteContactUsPage(int id);
         ContactUsPage GetContactUsPageByID(int id);
         ContactUsPage GetCurrentPage();

    }
}
